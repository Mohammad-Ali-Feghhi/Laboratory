# گزارش روز نهم پروژه - بهینه‌سازی عملکرد Entity Framework

**تاریخ:** ۱۴۰۳/۰۸/۱۴  
**شماره روز:** ۹  
**موضوع:** اصلاح عملکردی اول - افزودن `AsNoTracking` به متدهای فقط‌خواندنی

---

## ۱. هدف روز نهم

اجرای اولین اصلاح عملکردی با اولویت بالا از بین مشکلات شناسایی‌شده در تحلیل عملکرد دیتابیس (Performance Analysis). هدف: کاهش مصرف حافظه و Overhead Change Tracking در تمام متدهای Read-Only لایه DataAccess.

**مشکل هدف:** عدم استفاده از `AsNoTracking` در ۳۱ متد فقط‌خواندنی در ۱۰ Repository (به جز EmployeeRepository که قبلاً در Phase 2 اصلاح شده بود).

---

## ۲. مشکلات عملکردی شناسایی‌شده (از تحلیل قبلی)

| اولویت | مشکل | شدت | وضعیت پیش از روز نهم |
|--------|------|-----|---------------------|
| ۱ | Context Lifetime / Connection Leak | 🔴 Critical | chưa اصلاح |
| ۲ | **عدم AsNoTracking در متدهای Read-Only** | 🔴 Critical | **هدف امروز** |
| ۳ | N+1 Query Risk (بدون Include) | 🔴 Critical | chưa اصلاح |
| ۴ | Over-fetching (Entity کامل به جای DTO) | 🔴 Critical | chưa اصلاح |
| ۵ | عدم Pagination در لیست‌های حجیم | 🔴 Critical | chưa اصلاح |
| ۶ | فقط Sync (بدون Async) | 🟡 High | chưa اصلاح |
| ۷ | کوئری تکراری (DoctorRepository) | 🟡 High | chưa اصلاح |
| ۸ | SaveChanges در هر عملیات (بدون Batch) | 🟡 High | chưa اصلاح |
| ۹ | Missing Indexes روی FK | 🟡 High | chưa اصلاح |

---

## ۳. مسیر فایل‌ها و متدهای بررسی‌شده

### Repositoryها و متدهای هدف (۳۱ متد در ۱۰ فایل)

| فایل | متدهای اصلاح‌شده | تعداد |
|------|------------------|-------|
| `DataAccess/DoctorRepository.cs` | `GetDoctorByDoctorId`, `GetDoctorByMedicalLicenseNumber`, `GetAllDoctors`, `GetAllDeactiveDoctors`, `SearchDoctor`, `GetAllTestAcceptionsByDoctorId` | ۶ |
| `DataAccess/PatientRepository.cs` | `GetPatientByPatientId`, `GetAllPatients`, `GetPatientTestListByPatientId`, `SearchPatient`, `PatientCheckingValidation` | ۵ |
| `DataAccess/TestRepository.cs` | `GetByTestId`, `GetTestItemsByTestId`, `GetAllTests`, `TestSearch` | ۴ |
| `DataAccess/TestAcceptionRepository.cs` | `GetItemByTestAcceptionItemId`, `GetAllTestAcceptionHeaders`, `GetAllTestAcceptionItems`, `HasExistTestAcceptionItem` | ۴ |
| `DataAccess/TestCategoryRepository.cs` | `GetAllTestCategories` | ۱ |
| `DataAccess/TestMethodRepository.cs` | `GetAllTestMethods` | ۱ |
| `DataAccess/TestRangeRepository.cs` | `GetAllTestRanges` | ۱ |
| `DataAccess/UnitRepository.cs` | `GetAllUnits` | ۱ |
| `DataAccess/ResponseTypeRepository.cs` | `GetAllResponseTypes` | ۱ |
| `DataAccess/SampleTypeRepository.cs` | `GetAllSampleTypes` | ۱ |
| **مجموع** | | **۳۱** |

> **نکته:** `EmployeeRepository` (۵ متد) قبلاً در Phase 2 Refactoring با AsNoTracking اصلاح شده بود.

---

## ۴. مشکلات Entity Framework 6 (نه EF Core)

> **مهم:** پروژه از **Entity Framework 6.5.2** استفاده می‌کند (خیر EF Core). مشکلات و اصلاحات بر اساس رفتار EF6 ارزیابی شده‌اند.

| مشکل EF6 | توضیح | راهکار امروز |
|----------|-------|-------------|
| **Change Tracking Overhead** | EF6 به‌صورت پیش‌فرض تمام Entityهای برگردانده‌شده را در `ObjectStateManager` Track می‌کند | `AsNoTracking()` غیرفعال‌سازی Tracking |
| **Snapshot Storage** | برای هر Entity Track شده، کپی از مقادیر اصلی نگهداری می‌شود (برای DetectChanges) | حذف Snapshot با AsNoTracking |
| **DetectChanges در SaveChanges** | هر فراخوانی SaveChanges تمام Entityهای Track شده را اسکن می‌کند | کاهش Entityهای Track شده |
| **Lazy Loading در Tracked Entities** | Navigation Properties به‌صورت Lazy Load فعال هستند | با AsNoTracking، Navigationها Null می‌مانند (Exception-safe در کد موجود) |
| **Materialization Cost** | ایجاد Object کامل + StateEntry + Snapshot | فقط ایجاد Entity ساده |

---

## ۵. اصلاحات انجام‌شده

### تغییرات در هر فایل Repository (الگوی یکسان):

**۱. اضافه کردن namespace موردنیاز:**
```csharp
using System.Data.Entity;  // برای Extension Method AsNoTracking()
```

**۲. اضافه کردن `.AsNoTracking()` قبل از Materialization:**

```csharp
// الگوی Before
var doctor = _db.Doctor.FirstOrDefault(x => x.DoctorId == doctorId && x.IsDeleted == false);

// الگوی After
var doctor = _db.Doctor.AsNoTracking().FirstOrDefault(x => x.DoctorId == doctorId && x.IsDeleted == false);
```

**۳. برای متدهای LINQ Query Syntax:**
```csharp
// Before
var q = from d in _db.Doctor where ... select ...;

// After
var q = from d in _db.Doctor.AsNoTracking() where ... select ...;
```

**۴. برای Joinها (TestAcceptionRepository):**
```csharp
// After - تمام مصادر Query با AsNoTracking
var query = from testAcceptionItem in _db.TestAcceptionItem.AsNoTracking()
            join method in _db.TestMethod.AsNoTracking() on ...
            join unit in _db.Unit.AsNoTracking() on ...
```

### متدهای **شامل نشده** از اصلاح (به‌خاطر نیاز به Tracking):

| Repository | متدها | دلیل |
|------------|-------|------|
| همه | `AddNew*`, `Update*`, `Delete*`, `Enable*` | نیاز به Tracking برای SaveChanges |
| Doctor | `HasExistMedicalLicenseNumber` | برگرداندن scalar (bool)، نه Entity |
| Patient | `HasExistNationalCode` | برگرداندن scalar |
| Test | `HasExistTestName` | برگرداندن scalar |
| TestAcception | `AddNew*`, `Delete*`, `Update*` | عملیات نوشتن |

---

## ۶. فایل‌های تغییرکرده

### فایل‌های DataAccess (۱۰ فایل اصلی):

| فایل | خطوط اضافه | خطوط حذف | تغییرات کلیدی |
|------|------------|----------|--------------|
| `DoctorRepository.cs` | +9 | -6 | ۶ AsNoTracking + using |
| `PatientRepository.cs` | +6 | -4 | ۵ AsNoTracking + using |
| `TestRepository.cs` | +5 | -4 | ۴ AsNoTracking + using |
| `TestAcceptionRepository.cs` | +10 | -8 | ۴ AsNoTracking + Joinها + using |
| `TestCategoryRepository.cs` | +2 | 0 | ۱ AsNoTracking + using |
| `TestMethodRepository.cs` | +2 | 0 | ۱ AsNoTracking + using |
| `TestRangeRepository.cs` | +2 | -1 | ۱ AsNoTracking + using |
| `UnitRepository.cs` | +2 | 0 | ۱ AsNoTracking + using |
| `ResponseTypeRepository.cs` | +2 | 0 | ۱ AsNoTracking + using |
| `SampleTypeRepository.cs` | +2 | 0 | ۱ AsNoTracking + using |

### فایل دیگر (تغییر پیش‌ازین - uncommitted):
| فایل | توضیح |
|------|-------|
| `Laboratory/Forms/Tests/frmNewTestParameter.cs` | اصلاح typo `SamplyeTypeId` → `SampleTypeId` (از روزهای قبل) |

---

## ۷. نتیجه Build و Test

### Build Results

| Configuration | DomainModel | DataAccess | Framework | Laboratory | نتیجه کلی |
|--------------|-------------|------------|-----------|------------|-----------|
| **Debug** | ✅ Success | ✅ Success | ✅ Success | ✅ Success | **موفق** |
| **Release** | ✅ Success | ✅ Success | ✅ Success | ❌ Failed | **مخفق (پیش‌ازین)** |

**علت شکست Release:** خطای `CS0246: The type or namespace name 'Atf' could not be found` - مربوط به DLLهای خارجی `DateTimeSelector` و `FarsiLibrary` که در Repository موجود نیستند. این مسئله **پیش از تغییرات امروز** وجود داشته و در `runbook.md` مستند شده است.

### هشدارهای Build (پیش‌ازین - Phase 3-3):
```
CS0618: 'EmployeeRepository.EmployeeRepository()' is obsolete
```
- ۱۰ هشدار در Forms مختلف - مربوط به Constructor Injection در EmployeeRepository

### Runtime Test

| تست | نتیجه | توضیح |
|------|-------|-------|
| **Application Startup (Debug)** | ✅ Pass | `Laboratory.exe` اجرا شد، فرم Login نمایش داده شد (~۳۴ MB Working Set) |
| **Unit Tests** | N/A | پروژه تست واحد وجود ندارد |
| **Integration Tests** | N/A | تست یکپارچگی اتوماتیک وجود ندارد |
| **UI Functional Test** | ⚠️ Partial | فقط استارتاپ تست شد - فرم‌های خاص (Doctors, Patients, Tests) به‌صورت کامل تست نشدند |

---

## ۸. نتایج اندازه‌گیری عملکرد قبل و بعد

> **مهم:** هیچ ابزار اندازه‌گیری واقعی (Memory Profiler، SQL Profiler، BenchmarkDotNet) در این روز اجرا نشده است. نتایج زیر **تنها بر اساس تحلیل فنی و نظریه EF6** است.

### متریک‌های با داده واقعی: **ندارد** (ابزار اجرا نشده)

### متریک‌های احتمالی/نظری (بر اساس مستندات EF6):

| متریک | سناریو ۱۰،۰۰۰ رکورد | پیش از اصلاح | بعد از اصلاح (نظری) | بهبود احتمالی |
|-------|-------------------|--------------|-------------------|-------------|
| **حافظه کلاینت (Entity + State)** | `GetAllPatients()` | ~۴۰-۶۰ MB | ~۱۵-۲۰ MB | **۶۰-۷۰٪ کاهش** |
| **Snapshot Dictionary Entries** | هر Entity یک Entry | ۱۰،۰۰۰ Entry | ۰ Entry | **۱۰۰٪ حذف** |
| **StateEntry Objects** | هر Entity یک Object | ۱۰،۰۰۰ Object | ۰ Object | **۱۰۰٪ حذف** |
| **Materialization CPU Time** | ایجاد Object کامل | پایه | ~۳۰-۵۰٪ سریع‌تر | **معنادار** |
| **GC Gen 0 Collections** | با حجم داده بالا | بیشتر | کمتر | **کاهش** |
| **DetectChanges Overhead** | در SaveChanges بعد | اسکن ۱۰،۰۰۰ Entity | فقط Entityهای Dirty | **متناسب با Read/Write Ratio** |

### کوئری‌های دیتابیس (بدون تغییر - تأیید شده در نظر):

| متریک | قبل | بعد | تفاوت |
|-------|-----|-----|--------|
| **SQL Query Text** | یکسان | یکسان | **۰** |
| **Round-trips** | یکسان | یکسان | **۰** |
| **Network Payload** | یکسان | یکسان | **۰** |
| **Execution Plan** | یکسان | یکسان | **۰** |

> **نتیجه:** `AsNoTracking` تنها بر **Client-side Materialization و Memory** تأثیر دارد، نه بر SQL تولیدشده یا انتقال شبکه.

---

## ۹. مشکلاتی که هنوز اصلاح نشده‌اند

| اولویت | مشکل | فایل/مکان | تلاش تخمینی |
|--------|------|-----------|-------------|
| 🔴 ۱ | **Context Lifetime / DI Container** | تمام Forms، Program.cs | ۲-۳ روز |
| 🔴 ۲ | **N+1 Query (بدون Include)** | ۶+ Repository | ۱-۲ روز |
| 🔴 ۳ | **Over-fetching / Missing Projection** | ۳۰+ متد GetAll*/GetById | ۲-۳ روز |
| 🔴 ۴ | **Pagination غایب** | تمام GetAll* متدها | ۱-۲ روز |
| 🟡 ۵ | **Async/Await (ToListAsync و...)** | تمام Repositoryها | ۱ روز |
| 🟡 ۶ | **Duplicate Query (DoctorRepository)** | `GetAllTestAcceptionsByDoctorId` | <۱ ساعت |
| 🟡 ۷ | **SaveChanges Batch / TransactionScope** | ۱۵ متد Write | ۱-۲ روز |
| 🟡 ۸ | **Missing Indexes روی FK** | LabContext + Migration | ۱ روز (پس از Migration) |
| 🟢 ۹ | **Connection Resiliency** | LabContext Constructor | <۱ ساعت |
| 🟢 ۱۰ | **Logging Framework (Serilog)** | BaseRepository + همه جا | ۱ روز |

---

## ۱۰. پیشنهادهای روزهای آینده

### روز ۱۰ (اولویت ۱): Context Lifetime و DI Container
1. اضافه کردن `Microsoft.Extensions.DependencyInjection` NuGet
2. ثبت `LabContext` به‌عنوان **Scoped**
3. ثبت تمام ۱۱ Repository به‌عنوان Scoped
4. به‌روزرسانی `Program.cs` و تمام Forms برای Constructor Injection
5. این **پیش‌نیاز** برای Pagination صحیح و Async است

### روز ۱۱-۱۲ (اولویت ۲): Projection و Pagination
1. تعریف DTOهای `*ListItem`، `*DetailDto`، `*EditDto` در DomainModel
2. تبدیل ۱۱ متد `GetAll*` به `GetPaged(page, size)` با `Select` به DTO
3. اضافه کردن Paging کنترل در UI (DataGridView VirtualMode یا Pager)

### روز ۱۳ (اولویت ۳): N+1 Query و Include
1. اضافه کردن `.Include()` در متدهای Detail/Edit
2. بررسی Lazy Load در کدهای UI موجود
3. در صورت نیاز، Projection برای Navigation در List DTOها

### روز ۱۴: Async و Batch SaveChanges
1. تبدیل متدها به `async Task<T>`
2. استفاده از `ToListAsync()`, `FirstOrDefaultAsync()`, `SaveChangesAsync()`
3. اضافه کردن `TransactionScope` برای عملیات چند Entity (Header + Items)

### پیوسته: ابزارهای پیشنهادی برای اندازه‌گیری واقعی
| ابزار | کاربرد | اولویت |
|------|---------|--------|
| **dotMemory / ANTS Memory Profiler** | مقایسه حافظه قبل/بعد AsNoTracking | بالا |
| **SQL Profiler / Extended Events** | تأیید عدم تغییر SQL، یافتن N+1 | بالا |
| **BenchmarkDotNet** | اندازه‌گیری Materialization Time | متوسط |
| **MiniProfiler (ASP.NET/WinForms)** | مانیتور کوئری در Runtime | متوسط |
| **VS Diagnostic Tools** | CPU/Memory در حین Debug | بالا |

---

## جمع‌بندی روز نهم

✅ **انجام شده:** اولین اصلاح عملکردی (AsNoTracking در ۳۱ متد / ۱۰ Repository) با موفقیت اعمال، Build Debug موفق، Runtime Startup تأیید شد.

⚠️ **بدون داده واقعی:** بهبود حافظه و CPU تنها **نظری/فنی** است - نیاز به Memory Profiler برای تأیید کمی.

🔴 **باقی‌مانده:** ۹ مشکل Critical/High دیگر که Context Lifetime (DI Container) بلوک‌کننده اکثر اصلاحات بعدی است.

📋 **فایل‌های به‌روزرسانی شده:** ۱۰ فایل در `DataAccess/` + مستندات در این گزارش.
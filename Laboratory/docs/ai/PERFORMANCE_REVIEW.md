# بررسی عملکرد - Laboratory Management System

## 📋 هدف و دامنه

این سند پیاده‌سازی‌های فعلی مرتبط با عملکرد، بهینه‌سازی‌های اعمال شده، و ریسک‌های بالقوه عملکردی را بر اساس تحلیل کد منبع مستند می‌کند. **هیچ پروفایلینگ، بنچمارک، یا đo đo Runtime انجام نشده است.**

**آخرین تأیید:** ۱۴۰۳/۰۸/۱۷ (۲۰۲۶/۱۱/۰۷)  
**منبع:** تحلیل مستقیم کد منبع، Commit History، Database Performance Analysis Doc  
**روش:** Static Code Inspection فقط

---

## ✅ بهینه‌سازی پیاده‌سازی شده (Implemented Optimization)

### AsNoTracking در ۳۱ متد Read-Only (Commit 6631dfb)

**تاریخ:** ۱۴۰۳/۰۸/۱۴  
**Commit:** `6631dfb` — "perf: add AsNoTracking to 31 read-only methods across 10 repositories"  
**تغییرات:** ۱۰ فایل، +۳۱ خط، -۰ خط

| Repository | متدها | تعداد |
|------------|-------|-------|
| **DoctorRepository** | GetById، GetAll، GetDeactive، Search، GetTestAcceptionsByDoctor | ۶ |
| **PatientRepository** | GetById، GetAll، GetTestList، Search، Validation | ۵ |
| **TestRepository** | GetById، GetItems، GetAll، Search | ۴ |
| **TestAcceptionRepository** | GetItem، GetAllHeaders، GetAllItems، HasExist | ۴ |
| **TestCategoryRepository** | GetAll | ۱ |
| **TestMethodRepository** | GetAll | ۱ |
| **TestRangeRepository** | GetAll | ۱ |
| **UnitRepository** | GetAll | ۱ |
| **ResponseTypeRepository** | GetAll | ۱ |
| **SampleTypeRepository** | GetAll | ۱ |
| **مجموع** | | **۳۱** |

**الگوی تغییر:**
```csharp
// قبل
return _db.Doctor.Where(x => x.IsDeleted == false).OrderBy(x => x.DoctorName).ToList();

// بعد
return _db.Doctor.AsNoTracking().Where(x => x.IsDeleted == false).OrderBy(x => x.DoctorName).ToList();
```

**متدهای مستثنی (نیاز به Tracking):**
- تمام متدهای Write: `AddNew*`، `Update*`، `Delete*`، `Enable*`
- کوئری‌های Scalar: `HasExist*` برگردانده `bool`
- Join‌های پیچیده در TestAcceptionRepository: AsNoTracking روی تمام منابع Join

**Build Verification:**
- ✅ Debug Build: تمام ۴ پروژه موفق
- ⚠️ Release Build: Failed — Pre-existing `Atf` namespace missing (External DLLs)
- ✅ Runtime Startup: `Laboratory.exe` launches successfully (~34MB Working Set)

---

## ⚠️ ریسک‌های بالقوه عملکردی (Potential Performance Risks)

### ۱. N+1 Query Risk (ریسک کوئری N+1)

**طبقه‌بندی:** Potential Risk (قربله/نظری) — **هیچ đo đo تکرار کوئری وجود ندارد**

**محل‌های احتمالی:**
| Repository | متد | Navigation Property | ریسک |
|------------|------|---------------------|------|
| `DoctorRepository` | `GetDoctorByDoctorId` (line 94) | `TestAcceptionHeader` | Entity Return + Tracking در متدهای GetById قدیمی |
| `PatientRepository` | `GetPatientByPatientId` (line 114) | `TestAcceptionHeader` | مشابه |
| `EmployeeRepository` | `GetEmployeeByEmployeeId` (line 108) | `LoginHistory`، `TestAcceptionHeader` | مشابه |
| `TestAcceptionRepository` | `GetAllTestAcceptionItems` | Join‌های صریح با AsNoTracking | ✅ کاهش یافته |

**تحلیل:**
- متدهای `GetAll*` و `Search*` با `AsNoTracking()` → Lazy Load غیرفعال → N+1 پیشگیری شده
- متدهای `GetById` (Entity Return) در Repositoryهای قدیمی (Doctor، Patient، Employee) **Tracking فعال** دارند
- در صورت دسترسی به Navigation Property در کد Consumer: Lazy Load → کوئری اضافه_per_entity
- **TestLazyLoad Project** (`TestLazyLoad/Program.cs`) برای تأیید این رفتار ساخته شده — اجرا شده، دیتابیس خالی، Exception مشاهده نشد

**وضعیت:** ⚠️ Potential Risk — نیاز به Runtime Verification با داده واقعی

---

### ۲. Missing Pagination (عدم صفحه‌بندی)

**طبقه‌بندی:** Confirmed Implementation Gap (خلأ پیاده‌سازی تأییدشده)

**متدهای تحت تأثیر (نمونه):**
| Repository | متد | خط | بازگشت |
|------------|------|-----|---------|
| `EmployeeRepository` | `GetAllEmployees()` | 148 | `List<Employee>` — تمام رکوردها |
| `EmployeeRepository` | `GetInactiveEmployees()` | 152 | `List<Employee>` |
| `EmployeeRepository` | `GetDeletedEmployees()` | 156 | `List<Employee>` |
| `DoctorRepository` | `GetAllDoctors()` | 144 | `List<Doctor>` |
| `DoctorRepository` | `GetAllDeactiveDoctors()` | 151 | `List<Doctor>` |
| `PatientRepository` | `GetAllPatients()` | 189 | `List<Patient>` |
| `TestCategoryRepository` | `GetAll()` | - | `List<TestCategory>` |
| `TestMethodRepository` | `GetAll()` | - | `List<TestMethod>` |
| `TestRangeRepository` | `GetAll()` | - | `List<TestRange>` |
| `UnitRepository` | `GetAll()` | - | `List<Unit>` |
| `ResponseTypeRepository` | `GetAll()` | - | `List<ResponseType>` |
| `SampleTypeRepository` | `GetAll()` | - | `List<SampleType>` |

**تأثیر احتمالی:**
- جداول بزرگ (Employee، Patient، TestAcception): Memory Pressure در Client
- UI DataBind Volume بالا → Freeze/ Lag
- Network Payload زیاد

**راهکار پیشنهادی:** `GetAll(int page, int pageSize)` با `.Skip((page-1)*pageSize).Take(pageSize)`

---

### ۳. Over-fetching Complete Entities (بازگرداندن Entity کامل)

**طبقه‌بندی:** Confirmed Implementation Gap

**مقایسه Patternها:**

| Pattern | Repository/متد | وضعیت |
|---------|----------------|-------|
| **Projection/Select (خوب)** | `PatientRepository.GetPatientTestListByPatientId()` (line 196-209) | ✅ ۴ متد — DTO Return |
| **Projection/Select (خوب)** | `DoctorRepository.SearchDoctor()` (line 159-174) | ✅ `DoctorSearchListItem` |
| **Projection/Select (خوب)** | `PatientRepository.SearchPatient()` (line 213-232) | ✅ `PatientSearchListItem` |
| **Projection/Select (خوب)** | `EmployeeRepository.SearchEmployee()` (line 159-179) | ✅ `EmployeeSearchListItem` — **اما Password شامل است!** |
| **Entity Return (ریسک)** | `GetAllDoctors()`, `GetAllEmployees()`, `GetAllPatients()` | ⚠️ ۱۰+ متد — Entity کامل |

**متدهای Over-fetching:**
- تمام `GetAll*()` — Entity با همه Columns برمی‌گردانند
- `GetById()` متدها — Entity کامل + Navigation Properties (Tracking فعال در برخی)

**تأثیر احتمالی:**
- Columns غیرضروری (Description، Address، UpdateTime، Navigation Collections) ترنسفر می‌شوند
- Memory Usage بالا در Client
- Lazy Load Risk (در Entity Return با Tracking)

---

### ۴. Long-lived DbContext (عمر طولانی Context)

**طبقه‌بندی:** Confirmed Implementation — Architectural Pattern

**جزئیات:** در بخش [TECHNICAL_DEBT.md#DB-001](../TECHNICAL_DEBT.md#db-001-long-lived-labcontext--form-lifetime-context) مفصل مستند شده

**خلاصه تأثیر عملکردی:**
- ChangeTracker نگهداری Entityهای بارگذاری شده → Memory Retention
- Stale Data در جلسات طولانی (Form باز مانده)
- Connection Pooling: Context Dispose تا بسته شدن Form

---

## 📊 دسته‌بندی نتایج (Classification Summary)

| دسته | تعداد | مثال‌ها |
|-------|-------|---------|
| **Confirmed Implementation** (پیاده‌سازی تأییدشده) | ۱ | AsNoTracking ۳۱ متد (Commit 6631dfb) |
| **Confirmed Implementation Gap** (خلأ تأییدشده) | ۳ | Missing Pagination، Over-fetching، Long-lived Context |
| **Potential Performance Risk** (ریسک بالقوه) | ۱ | N+1 Query Risk (Navigation Properties در GetById) |
| **Measured Performance Issue** (مشکل đo đo شده) | ۰ | **هیچ** — Profiling/Benchmark انجام نشده |

---

## 📈 ادعاهای قبلی vs واقعیت (Claims vs Reality)

| ادعای قبلی | واقعیت تأییدشده |
|------------|----------------|
| "AsNoTracking به ۳۱ متد اضافه شده" | ✅ **تأیید شده** — Commit 6631dfb |
| "Client Memory 40-60MB → 15-20MB" | ❌ **نظری/تئوریک** — هیچ đo đo dotMemory وجود ندارد |
| "Materialization CPU 30-50% faster" | ❌ **نظری** — هیچ BenchmarkDotNet وجود ندارد |
| "Snapshot Entries Eliminated" | ✅ **تأیید شده مفهومی** — AsNoTracking ChangeTracker entries ایجاد نمی‌کند |
| "SQL Round-trips Unchanged" | ✅ **تأیید شده** — AsNoTracking کوئری SQL را تغییر نمی‌دهد |
| "N+1 Query Risk وجود دارد" | ⚠️ **قربله** — فقط در GetById Entity Return با Tracking |

---

## 🧪 تست Lazy Load (TestLazyLoad Project)

**محل:** `TestLazyLoad/Program.cs`  
**نوع:** Manual Console Application — **نه تست اتوماتیک**  
**هدف:** تأیید رفتار AsNoTracking روی Navigation Properties

**منطق تست:**
```csharp
var doctors = repo.GetAllDoctors();  // با AsNoTracking
var firstDoctor = doctors[0];
var count = firstDoctor.TestAcceptionHeader?.Count ?? 0;  // انتظار: 0 یا Null
```

**نتیجه اجرا:**
- ✅ برنامه استارت می‌شود
- ⚠️ دیتابیس خالی (بدون داده تست) — تست منطقی انجام شد
- ✅ هیچ Runtime Exception (Lazy Load) مشاهده نشد

**محدودیت‌ها:**
- داده تستی وجود ندارد
- فقط ۳ Repository تست شده (Doctor، Patient، Employee)
- Manual Execution — در CI/CD قابل اجرا نیست
- Assertion خالص ندارد — فقط Console.WriteLine

---

## 🔮 برنامه‌های پیشنهادی اندازه‌گیری (Measurement Plan)

| اولویت | اقدام | ابزار پیشنهادی |
|--------|-------|----------------|
| P1 | Memory Profiling قبل/بعد AsNoTracking | dotMemory، Visual Studio Diagnostic Tools |
| P1 | Benchmark کوئری‌های GetAll/GetById | BenchmarkDotNet |
| P2 | Query Plan Analysis برای کوکدهای پیچیده | SQL Server Execution Plan، EF Core Logging (اگر Migration) |
| P2 | Load Test UI DataBind با حجم داده بالا | Custom Script یا NBomber |
| P3 | N+1 Verification با داده واقعی | MiniProfiler، EF6 Logging |

---

## ⚠️ محدودیت‌های این تحلیل

1. **Static Analysis فقط** — Runtime Behavior ممکن است متفاوت باشد
2. **داده Production موجود نیست** — جداول خالی/کم‌داده در Dev
3. **External DLLs** — Release Build Fail، تست کامل UI محدود
4. **هیچ Baseline Performance Metric وجود ندارد** — مقایسه Before/After ممکن نیست

---

*این سند بر اساس Static Code Inspection و Commit History تهیه شده. هیچ Profiling، Benchmark، یا Load Testing انجام نشده است. تمام ریسک‌ها "Potential" یا "Confirmed Gap" هستند، نه "Measured Issue".*
# دیتابیس و دسترسی به داده - Laboratory Management System

## 🗄 تکنولوژی دیتابیس

| مورد | مقدار | توضیح |
|------|-------|-------|
| **Database Engine** | Microsoft SQL Server | LocalDB / Express / Full Edition |
| **ORM** | Entity Framework 6.5.2 | Database First / Code First Hybrid |
| **Connection String** | `data source=.;initial catalog=Lab;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework` | در `Laboratory/App.config` |
| **Provider** | `System.Data.SqlClient` | ADO.NET Provider |
| **Migrations** | ❌ غیرفعال | Schema Changes نیاز به SQL دستی یا فعال‌سازی Migration |

---

## 🔧 کانفیگ Entity Framework

### App.config (Laboratory/App.config)
```xml
<connectionStrings>
  <add name="LabContext" 
       connectionString="data source=.;initial catalog=Lab;integrated security=True;
                         MultipleActiveResultSets=True;App=EntityFramework" 
       providerName="System.Data.SqlClient" />
</connectionStrings>

<entityFramework>
  <providers>
    <provider invariantName="System.Data.SqlClient" 
              type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
  </providers>
</entityFramework>
```

### LabContext (DomainModel/Models/LabContext.cs)
```csharp
public partial class LabContext : DbContext
{
    public LabContext() : base("name=LabContext") { }

    // 13 DbSet برای جداول
    public virtual DbSet<Doctor> Doctor { get; set; }
    public virtual DbSet<Employee> Employee { get; set; }
    public virtual DbSet<LoginHistory> LoginHistory { get; set; }
    public virtual DbSet<Patient> Patient { get; set; }
    public virtual DbSet<ResponseType> ResponseType { get; set; }
    public virtual DbSet<SampleType> SampleType { get; set; }
    public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    public virtual DbSet<Test> Test { get; set; }
    public virtual DbSet<TestAcceptionHeader> TestAcceptionHeader { get; set; }
    public virtual DbSet<TestAcceptionItem> TestAcceptionItem { get; set; }
    public virtual DbSet<TestCategory> TestCategory { get; set; }
    public virtual DbSet<TestMethod> TestMethod { get; set; }
    public virtual DbSet<TestRange> TestRange { get; set; }
    public virtual DbSet<Unit> Unit { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // تمام Cascade Deleteها روی false
        // Foreign Keyهای صریح تعریف شده
    }
}
```

---

## 📋 موجودیت‌ها و جداول (Entities)

### 13 موجودیت اصلی

| موجودیت | جدول | Primary Key | توضیحات |
|---------|-------|-------------|---------|
| **Doctor** | Doctor | DoctorId | پزشکان، مجوز پزشکی |
| **Employee** | Employee | EmployeeId | کارمندان، احراز هویت، Soft Delete |
| **Patient** | Patient | PatientId | بیماران، اطلاعات демوگرافیک |
| **Test** | Test | TestId | آزمایش‌ها، FK به Category/Method/Unit/Range/SampleType/ResponseType |
| **TestCategory** | TestCategory | TestCategoryId | دسته‌بندی آزمایش‌ها |
| **TestMethod** | TestMethod | TestMethodId | روش‌های آزمایش |
| **TestRange** | TestRange | TestRangeId | محدوده‌های مرجع آزمایش |
| **Unit** | Unit | UnitId | واحدهای اندازه‌گیری |
| **SampleType** | SampleType | SampleTypeId | انواع نمونه‌گیری |
| **ResponseType** | ResponseType | ResponseTypeId | انواع پاسخ آزمایش |
| **TestAcceptionHeader** | TestAcceptionHeader | TestAcceptionHeaderId | هدر پذیرش آزمایش (FK: Patient, Doctor, Employee) |
| **TestAcceptionItem** | TestAcceptionItem | TestAcceptionItemId | آیتم‌های پذیرش (FK: Header, Test) |
| **LoginHistory** | LoginHistory | LoginHistoryId | لاگ ورود کارمندان (FK: Employee) |
| **sysdiagrams** | sysdiagrams | diagram_id | System Table (SQL Server Diagrams) |

---

## 🔗 روابط و Foreign Keys

### دیاگرام روابط (استنباط‌شده از Fluent API)

```
Employee (1) ─────< (N) LoginHistory
Employee (1) ─────< (N) TestAcceptionHeader [RegistrationEmployeeId]
Employee (1) ─────< (N) TestAcceptionHeader [ConfirmationEmployeeId]

Patient (1) ──────< (N) TestAcceptionHeader

Doctor (1) ───────< (N) TestAcceptionHeader

TestAcceptionHeader (1) ──< (N) TestAcceptionItem

TestCategory (1) ────< (N) Test
TestMethod (1) ──────< (N) Test
Unit (1) ────────────< (N) Test
SampleType (1) ──────< (N) Test  ← FIXED: SamplyeTypeId → SampleTypeId
ResponseType (1) ────< (N) Test

Test (1) ────────────< (N) TestAcceptionItem
Test (1) ────────────< (N) TestRange
```

### جزئیات Fluent API (LabContext.OnModelCreating)

```csharp
// Doctor → TestAcceptionHeader
modelBuilder.Entity<Doctor>()
    .HasMany(e => e.TestAcceptionHeader)
    .WithRequired(e => e.Doctor)
    .WillCascadeOnDelete(false);

// Employee → LoginHistory
modelBuilder.Entity<Employee>()
    .HasMany(e => e.LoginHistory)
    .WithRequired(e => e.Employee)
    .WillCascadeOnDelete(false);

// Employee → TestAcceptionHeader (Registration)
modelBuilder.Entity<Employee>()
    .HasMany(e => e.TestAcceptionHeader)
    .WithRequired(e => e.Employee)
    .HasForeignKey(e => e.RegistrationEmployeeId)
    .WillCascadeOnDelete(false);

// Patient → TestAcceptionHeader
modelBuilder.Entity<Patient>()
    .HasMany(e => e.TestAcceptionHeader)
    .WithRequired(e => e.Patient)
    .WillCascadeOnDelete(false);

// SampleType → Test  ← TYPO FIXED
modelBuilder.Entity<SampleType>()
    .HasMany(e => e.Test)
    .WithRequired(e => e.SampleType)
    .HasForeignKey(e => e.SampleTypeId)  // بود: SamplyeTypeId
    .WillCascadeOnDelete(false);

// Test → TestAcceptionItem
modelBuilder.Entity<Test>()
    .HasMany(e => e.TestAcceptionItem)
    .WithRequired(e => e.Test)
    .WillCascadeOnDelete(false);

// Test → TestRange
modelBuilder.Entity<Test>()
    .HasMany(e => e.TestRange)
    .WithRequired(e => e.Test)
    .WillCascadeOnDelete(false);

// TestAcceptionHeader → TestAcceptionItem
modelBuilder.Entity<TestAcceptionHeader>()
    .HasMany(e => e.TestAcceptionItem)
    .WithRequired(e => e.TestAcceptionHeader)
    .WillCascadeOnDelete(false);

// TestCategory → Test
modelBuilder.Entity<TestCategory>()
    .HasMany(e => e.Test)
    .WithRequired(e => e.TestCategory)
    .WillCascadeOnDelete(false);

// TestMethod → Test
modelBuilder.Entity<TestMethod>()
    .HasMany(e => e.Test)
    .WithRequired(e => e.TestMethod)
    .WillCascadeOnDelete(false);

// Unit → Test
modelBuilder.Entity<Unit>()
    .HasMany(e => e.Test)
    .WithRequired(e => e.Unit)
    .WillCascadeOnDelete(false);
```

**نکته مهم:** تمام Cascade Deleteها روی `false` تنظیم شده‌اند. حذف نرم (Soft Delete) با فیلد `IsDeleted` پیاده‌سازی شده.

---

## 🏷 ستون‌های مشترک (Audit Fields)

بیشتر موجودیت‌ها دارای فیلدهای زیر هستند:

| ستون | نوع | توضیح |
|-------|-----|-------|
| `IsDeleted` | `bool` | Soft Delete Flag |
| `IsEnabled` | `bool?` | فعال/غیرفعال (Employee, Doctor) |
| `IsUpdated` | `bool` | نشان‌دهنده ویرایش |
| `UpdateTime` | `DateTime?` | زمان آخرین ویرایش |

---

## 📝 DTOs / ViewModels (BussinessModel)

| DTO | استفاده در | فیلدهای کلیدی |
|-----|-----------|---------------|
| `DoctorSearchListItem` | جستجوی پزشک | DoctorId, DoctorName, MedicalLicenseNumber, Description, IsEnabled |
| `PatientSearchListItem` | جستجوی بیمار | PatientId, PatientName, NationalCode, PhoneNumber, BirthDate, Gender |
| `EmployeeSearchListItem` | جستجوی کارمند | EmployeeId, EmployeeName, Username, **Password**, PhoneNumber, IsEnabled |
| `PatientTestListItem` | لیست تست‌های بیمار | PatientTestListItem fields + DoctorName, RegistrationEmployeeName |
| `TestAcceptionListItem` | لیست پذیرش | HeaderId, PatientName, DoctorName, RegistrationDate, Status |
| `TestAcceptionItemViewModel` | جزئیات پذیرش | TestName, UnitName, SampleTypeName, MethodName, Range, Result |
| `AddNewPatientTestItem` | افزودن تست به بیمار | TestId, TestName, ParameterTemp, ResponseTypeId |
| `PatientCheckingValidationItem` | اعتبارسنجی بیمار | Validation Rules |
| `TestParameterTemp` | پارامتر موقت تست | Temp storage |
| `UserPassEmployee` | تغییر رمز کارمند | EmployeeId, Username, OldPassword, NewPassword |

---

## ⚡ بهینه‌سازی‌های اخیر (کامیت 6631dfb)

### AsNoTracking روی ۳۱ متد Read-only

| Repository | متدها | تعداد |
|------------|-------|-------|
| **DoctorRepository** | GetById, GetAll, GetDeactive, Search, GetTestAcceptionsByDoctor | ۶ |
| **PatientRepository** | GetById, GetAll, GetTestList, Search, Validation | ۵ |
| **TestRepository** | GetById, GetItems, GetAll, Search | ۴ |
| **TestAcceptionRepository** | GetItem, GetAllHeaders, GetAllItems, HasExist | ۴ |
| **TestCategoryRepository** | GetAll | ۱ |
| **TestMethodRepository** | GetAll | ۱ |
| **TestRangeRepository** | GetAll | ۱ |
| **UnitRepository** | GetAll | ۱ |
| **ResponseTypeRepository** | GetAll | ۱ |
| **SampleTypeRepository** | GetAll | ۱ |
| **مجموع** | | **۳۱** |

**الگو:**
```csharp
// قبل
return _db.Doctor.Where(x => x.IsDeleted == false).OrderBy(x => x.DoctorName).ToList();

// بعد
return _db.Doctor.AsNoTracking().Where(x => x.IsDeleted == false).OrderBy(x => x.DoctorName).ToList();
```

**متدهای مستثنی (نیاز به Tracking):**
- تمام متدهای Write: `AddNew*`، `Update*`، `Delete*`، `Enable*`
- کوئری‌های Scalar: `HasExist*` برگردانده `bool`

---

## 📊 تحلیل عملکرد (Database Performance Analysis)

### ریسک‌های شناسایی‌شده (docs/database-performance-analysis.md)

| سطح ریسک | تعداد | مسائل کلیدی |
|----------|-------|-------------|
| 🔴 **Critical** | ۵ | Context Lifetime Leaks، No AsNoTracking (حالا حل شده)، N+1 Query Risks، No Pagination، Over-fetching |
| 🟡 **High** | ۴ | Duplicate Queries، No Column Selection (Select)، SaveChanges Per Entity، Missing Indexes on FK |
| 🟢 **Medium** | ۳ | FirstOrDefault vs SingleOrDefault، Eager Loading Gaps، Connection Pooling Concerns |

### الگوهای Query موجود

| الگو | نمونه | وضعیت |
|-------|-------|-------|
| **Projection/Select (خوب)** | `PatientRepository.GetPatientTestListByPatientId()` | ✅ ۴ مورد |
| **Entity Return (خطرناک)** | `GetAllDoctors()`, `GetAllEmployees()` | ⚠️ ۱۰+ مورد |

---

## 🛠 ذخیره‌سازی رمز عبور (Security Concern)

### وضعیت فعلی - SEC-001 🔴 Critical
```csharp
// Employee Entity
[Required]
[StringLength(100)]
public string Password { get; set; }  // Plain Text در دیتابیس!

// HashingUtility (Framework/HashingUtility.cs:18)
string key = "b613679a0814d9ec772f95d778c35fc5ff1697c493715653c6c712144292c5ad";  // HARDCODED!

// Login Flow (EmployeeRepository.Login)
if (user.Password != password)  // مقایسه Plain Text
    return Result<Employee>.Fail(ErrorCode.InvalidPassword, "رمز عبور اشتباه است!");
```

**مسائل:**
1. رمزها در دیتابیس **Plain Text** ذخیره می‌شوند
2. کلید HMACSHA256 **هاردکد شده** در سورس
3. UI رمز را هش می‌کند اما DB Plain مقایسه می‌کند → Login Fail

**پیشنهاد:** پیاده‌سازی `IPasswordHasher` با BCrypt/Argon2، مهاجرت رمزهای موجود.

---

## 🔄 Soft Delete Pattern

### پیاده‌سازی فعلی
```csharp
// همه موجودیت‌ها
public bool IsDeleted { get; set; }

// Repository Queries
_db.Employee.Where(x => x.IsDeleted == false)  // تکرار در همه Repositoryها
```

### مشکل: ناهمگونی (QUA-004)
- برخی Repositoryها `IsDeleted == false` چک می‌کنند
- برخی `IsDeleted == true` برای لیست حذف شده‌ها
- هیچ `WhereNotDeleted()` Extension Method یکپارچه وجود ندارد

**پیشنهاد فاز ۳-۴:** اضافه کردن `DeletedAt`، `DeletedBy`، ایجاد `WhereNotDeleted()`، Migration.

---

## 📈 شاخص‌ها (Indexes)

### از Fluent API قابل استنباط
| جدول | Column | نوع Index | منبع |
|-------|--------|-----------|------|
| Employee | Username | Unique (Implicit) | Business Rule |
| Employee | EmployeeId | PK | EF Convention |
| Test | SampleTypeId | FK Index | Fluent API HasForeignKey |
| TestAcceptionHeader | PatientId | FK Index | Fluent API |
| TestAcceptionHeader | DoctorId | FK Index | Fluent API |
| TestAcceptionHeader | RegistrationEmployeeId | FK Index | Fluent API |
| LoginHistory | EmployeeId | FK Index | Fluent API |

**نکته:** Indexهای صریح در Fluent API تعریف نشده - فقط FKها. Index روی Username برای Unique Constraint در DB ایجاد نشده (فقط در Biz Logic چک می‌شود → Race Condition DB-002).

---

## 🧪 تست Lazy Load (TestLazyLoad Project)

### هدف
تأیید رفتار `AsNoTracking` روی Navigation Properties

### منطق تست
```csharp
var doctors = repo.GetAllDoctors();  // با AsNoTracking
var firstDoctor = doctors[0];
var count = firstDoctor.TestAcceptionHeader?.Count ?? 0;  // انتظار: 0 یا Null
```

### نتیجه
- برنامه استارت می‌شود
- دیتابیس خالی (بدون داده) - تست منطقی انجام شد
- هیچ Runtime Exception مشاهده نشد

---

## 🔮 برنامه‌های آینده دیتابیس

| اولویت | کار | پیش‌نیاز |
|--------|-----|----------|
| 🔴 Critical | فعال‌سازی EF6 Migrations | `Enable-Migrations`، `Add-Migration InitialCreate` |
| 🔴 Critical | اضافه کردن Index روی Username | Migration |
| 🟡 Medium | یکپارچه‌سازی Soft Delete (`DeletedAt`, `DeletedBy`, `WhereNotDeleted`) | Migration |
| 🟡 Medium | Audit Fields خودکار (`CreatedAt`, `CreatedBy`) | BaseEntity / Interceptor |
| 🟢 Low | Connection Resiliency / Retry Policy | EF6 Execution Strategy |

---

*آخرین به‌روزرسانی: ۱۴۰۳/۰۸/۱۴ - بر اساس LabContext.cs، Entities، Repositoryها، و database-performance-analysis.md*
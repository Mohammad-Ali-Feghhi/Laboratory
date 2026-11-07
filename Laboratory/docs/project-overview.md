# مستند فنی پروژه - Laboratory Management System

## 📋 معرفی پروژه

**Laboratory Management System** یک برنامه دسکتاپ (Windows Forms) برای مدیریت آزمایشگاه پزشکی است. این سیستم شامل مدیریت بیماران، پزشکان، کارمندان، آزمایش‌ها، پذیرش آزمایش‌ها و گزارش‌گیری می‌باشد. برنامه با معماری چندلایه (N-Layer) و الگوی Repository پیاده‌سازی شده است.

---

## 🛠 تکنولوژی‌ها و نسخه‌ها

| تکنولوژی | نسخه | توضیحات |
|-----------|-------|---------|
| **.NET Framework** | 4.7.2 | پلتفرم اجرایی اصلی |
| **Entity Framework** | 6.5.2 | ORM برای دسترسی به دیتابیس |
| **Windows Forms** | - | لایه ارائه (UI) |
| **SQL Server** | - | دیتابیس (Connection String: LocalDB/Express) |
| **FastReport.OpenSource** | 2026.2.1 | موتور گزارش‌گیری |
| **FastReport.Compat** | 2026.2.1 | سازگاری گزارش‌گیری |

---

## 📁 ساختار Solution

```
Laboratory.sln
├── Laboratory/           # Presentation Layer (WinExe)
├── DataAccess/           # Data Access Layer (Library)
├── DomainModel/          # Domain Layer (Library)
└── Framework/            # Infrastructure Layer (Library)
```

**تنظیمات Solution:**
- Visual Studio 2019 (Format Version 12.00)
- Configurations: Debug \| Any CPU, Release \| Any CPU

---

## 🏗 معرفی پروژه‌ها و مسئولیت هرکدام

### 1. **Laboratory** (Presentation Layer)
- **نوع:** Windows Forms Application (WinExe)
- **نقطه ورود:** `Program.cs` → `frmLogin` → `frmMainBoard` (MDI Parent)
- **مسئولیت‌ها:**
  - احراز هویت کاربران (Login)
  - منوهای اصلی و ناوبری (MDI Child Forms)
  - مدیریت پزشکان (`Forms/Doctors/`)
  - مدیریت کارمندان (`Forms/Employees/`)
  - مدیریت بیماران (`Forms/Patients/`)
  - مدیریت آزمایش‌ها (`Forms/Tests/`)
  - Quick Access Panel
  - نمایش تاریخ/زمان شمسی

### 2. **DataAccess** (Data Access Layer)
- **نوع:** Class Library
- **الگو:** Repository Pattern با Interfaceها
- **Repositories (11 مورد):**
  - `DoctorRepository` / `IDoctorRepository`
  - `EmployeeRepository` / `IEmployeeRepository`
  - `PatientRepository` / `IPatientRepository`
  - `TestRepository` / `ITestRepository`
  - `TestAcceptionRepository` / `ITestAcceptionRepository`
  - `TestCategoryRepository` / `ITestCategoryRepository`
  - `TestMethodRepository` / `ITestMethodRepository`
  - `TestRangeRepository` / `ITestRangeRepository`
  - `UnitRepository` / `IUnitRepository`
  - `ResponseTypeRepository` / `IResponseTypeRepository`
  - `SampleTypeRepository` / `ISampleTypeRepository`
- **مسئولیت‌ها:**
  - عملیات CRUD برای موجودیت‌ها
  - جستجو و فیلترها
  - اعتبارسنجی‌های تجاری (Business Validation)
  - بازگرداندن `Result<T>` برای یکپارچه‌سازی مدیریت خطا

### 3. **DomainModel** (Domain Layer)
- **نوع:** Class Library
- **محتویات:**
  - **Models/ (13 Entity):** `Doctor`, `Patient`, `Employee`, `Test`, `TestAcceptionHeader`, `TestAcceptionItem`, `TestCategory`, `TestMethod`, `TestRange`, `Unit`, `SampleType`, `ResponseType`, `LoginHistory`, `sysdiagrams`
  - **LabContext:** `DbContext` با Fluent API Configuration
  - **BussinessModel/ (10 DTO/ViewModel):** `DoctorSearchListItem`, `PatientSearchListItem`, `EmployeeSearchListItem`, `PatientTestListItem`, `TestAcceptionListItem`, `TestAcceptionItemViewModel`, `AddNewPatientTestItem`, `PatientCheckingValidationItem`, `TestParameterTemp`, `UserPassEmployee`
  - **Results/:** `Result<T>` (Generic Result Pattern)، `ErrorCode` Enum

### 4. **Framework** (Infrastructure/Utilities)
- **نوع:** Class Library
- **کلاس‌ها:**
  - `HashingUtility` - HMACSHA256 با کلید ثابت
  - `PersianDateTime` - تبدیل تاریخ میلادی به شمسی (Solar Hijri)
  - `UIHelper` - کمکی‌های WinForms (رگ‌بازی، Opacity، رنگ‌ها)

---

## 🔗 ارتباط بین لایه‌ها

```
┌─────────────────────────────────────────────────────────────┐
│  Laboratory (Presentation)                                   │
│  ├── ارجاع به: DataAccess, DomainModel, Framework            │
└──────────────────────────┬──────────────────────────────────┘
                           │ Dependency Direction
                           ▼
┌─────────────────────────────────────────────────────────────┐
│  DataAccess (Data Access)                                    │
│  ├── ارجاع به: DomainModel                                    │
│  ├── پیاده‌سازی Interfaceهای Services                         │
└──────────────────────────┬──────────────────────────────────┘
                           │ Dependency Direction
                           ▼
┌─────────────────────────────────────────────────────────────┐
│  DomainModel (Domain)                                        │
│  ├── بدون ارجاع به سایر پروژه‌ها (Independent)               │
│  ├── Entities, DTOs, Context, Results                        │
└─────────────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────────┐
│  Framework (Infrastructure)                                  │
│  ├── بدون ارجاع به سایر پروژه‌ها (Independent)               │
│  └── Utilities: Hashing, PersianDate, UI Helpers             │
└─────────────────────────────────────────────────────────────┘
```

**Project References (Laboratory.csproj):**
```xml
<ProjectReference Include="..\DataAccess\DataAccess.csproj" />
<ProjectReference Include="..\DomainModel\DomainModel.csproj" />
<ProjectReference Include="..\Framework\Framework.csproj" />
```

---

## 🗄 نحوه دسترسی به دیتابیس

### ORM & Configuration
- **Entity Framework 6.5.2** (Database First / Code First Hybrid)
- **Connection String** در `Laboratory/App.config`:
```xml
<connectionStrings>
  <add name="LabContext" 
       connectionString="data source=.;initial catalog=Lab;integrated security=True;
                         MultipleActiveResultSets=True;App=EntityFramework" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

### LabContext (DomainModel/Models/LabContext.cs)
- ارث‌بری از `DbContext`
- ۱۳ `DbSet<T>` برای جداول
- **Fluent API** در `OnModelCreating`:
  - تمام Cascade Deleteها روی `false` تنظیم شده
  - Foreign Keyهای صریح تعریف شده
  - **نکته:** Typo در `Test.SamplyeTypeId` (باید `SampleTypeId` باشد)

### Repository Pattern Implementation
```csharp
public class DoctorRepository : IDoctorRepository
{
    private readonly LabContext _db;
    
    public DoctorRepository()
    {
        _db = new LabContext();
    }
    
    public void Dispose() => _db.Dispose();
}
```
- **عمر Context = عمر Repository** (نه کوتاه‌مدت/Per Request)
- `IDisposable` پیاده‌سازی شده

---

## 🔧 نحوه ثبت Dependencyها

**وضعیت:** **بدون DI Container** — Manual Instantiation (Service Locator Pattern)

```csharp
// در frmDoctors.cs
private readonly DoctorRepository _repo;
public frmDoctors() { _repo = new DoctorRepository(); }

// در frmLogin.cs
private readonly EmployeeRepository _repo;
private readonly HashingUtility _secret;
public frmLogin() { _repo = new EmployeeRepository(); _secret = new HashingUtility(); }
```

- Interfaceها تعریف شده‌اند اما Concrete classes مستقیم `new` می‌شوند
- Constructor Injection محدود فقط برای `Employee currentUser`
- هیچ IoC Containerی استفاده نشده

---

## ▶️ نحوه اجرای برنامه

**Entry Point:** `Laboratory/Program.cs`
```csharp
[STAThread]
static void Main()
{
    Application.EnableVisualStyles();
    Thread.CurrentThread.CurrentUICulture = new CultureInfo("fa-IR");
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new frmLogin());
}
```

**جریان اجرا:**
1. `Program.Main()` اجرا می‌شود
2. Culture فارسی (`fa-IR`) تنظیم می‌شود
3. `frmLogin` نمایش داده می‌شود
4. پس از Login موفق → `frmMainBoard` به عنوان **MDI Parent** باز می‌شود
5. منوهای اصلی → باز کردن فرم‌های **MDI Child**

---

## 📦 Packageهای مهم

| Package | نسخه | پروژه‌ها | منبع |
|---------|-------|----------|------|
| EntityFramework | 6.5.2 | Laboratory, DataAccess, DomainModel | NuGet |
| EntityFramework.SqlServer | 6.5.2 | Laboratory, DataAccess, DomainModel | NuGet |
| FastReport.OpenSource | 2026.2.1 | Laboratory | NuGet |
| FastReport.Compat | 2026.2.1 | Laboratory | NuGet |
| DateTimeSelector | 1.1.2 | Laboratory | External DLL (`..\..\Component\`) |
| FarsiLibrary.Win | - | Laboratory | External DLL (`..\..\Component\`) |

---

## ❓ نکات معتبر و خلأهای شناخته‌شده

| حوزه | وضعیت | اولویت |
|-------|-------|--------|
| **Security - Password Storage** | رمزها در دیتابیس Plain Text ذخیره می‌شوند | 🔴 بالا |
| **Security - Hardcoded Key** | کلید HMACSHA256 در `HashingUtility.cs:18` هاردکد شده | 🔴 بالا |
| **Architecture - Context Lifetime** | Repository Context طول عمر طولانی دارد | 🔴 بالا |
| **Architecture - DI Container** | عدم استفاده از DI Container | 🟡 متوسط |
| **Data - Typo in FK** | `Test.SamplyeTypeId` به جای `SampleTypeId` | 🟡 متوسط |
| **Logging Framework** | وجود ندارد (فقط LoginHistory) | 🟡 متوسط |
| **Multi-Environment Config** | فقط App.config واحد (Development) | 🟡 متوسط |
| **External DLL Management** | Relative Path در csproj | 🟡 متوسط |

---

*این مستند بر اساس تحلیل سورس‌کد پروژه تهیه شده است.*
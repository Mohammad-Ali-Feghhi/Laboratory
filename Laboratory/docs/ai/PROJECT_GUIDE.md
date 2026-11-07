# راهنمای پروژه - Laboratory Management System

## 📋 معرفی پروژه

**Laboratory Management System** یک برنامه دسکتاپ (Windows Forms) برای مدیریت آزمایشگاه پزشکی است. این سیستم شامل مدیریت بیماران، پزشکان، کارمندان، آزمایش‌ها، پذیرش آزمایش‌ها و گزارش‌گیری می‌باشد. برنامه با معماری چندلایه (N-Layer) و الگوی Repository پیاده‌سازی شده است.

---

## 🎯 هدف پروژه

ارائه یک سیستم جامع برای:
- مدیریت اطلاعات بیماران (ثبت، جستجو، ویرایش، حذف نرم)
- مدیریت پزشکان و مجوزهای پزشکی
- مدیریت کارمندان، احراز هویت و کنترل دسترسی
- مدیریت تست‌های آزمایشگاهی، دسته‌بندی‌ها، روش‌ها، واحدها و محدوده‌های مرجع
- پذیرش و ردیابی آزمایش‌های بیمار
- گزارش‌گیری با FastReport

---

## 🛠 تکنولوژی‌ها و نسخه‌ها

| تکنولوژی | نسخه | توضیحات | منبع |
|-----------|-------|---------|------|
| **.NET Framework** | 4.7.2 | پلتفرم اجرایی اصلی | Microsoft |
| **Entity Framework** | 6.5.2 | ORM برای دسترسی به دیتابیس | NuGet |
| **Windows Forms** | - | لایه ارائه (UI) | .NET Framework |
| **SQL Server** | LocalDB/Express/Full | دیتابیس پشتیبان | Microsoft |
| **FastReport.OpenSource** | 2026.2.1 | موتور گزارش‌گیری | NuGet |
| **FastReport.Compat** | 2026.2.1 | سازگاری گزارش‌گیری | NuGet |
| **DateTimeSelector** | 1.1.2 | کنترل انتخاب تاریخ شمسی | External DLL |
| **FarsiLibrary.Win** | - | کنترل‌های تقویم فارسی | External DLL |

---

## 🏗 ساختار Solution

```
Laboratory.sln
├── Laboratory/           # Presentation Layer (WinExe)
├── DataAccess/           # Data Access Layer (Library)
├── DomainModel/          # Domain Layer (Library)
├── Framework/            # Infrastructure Layer (Library)
└── TestLazyLoad/         # Test Project (Console App)
```

### تنظیمات Solution
- **Visual Studio 2019** (Format Version 12.00)
- **Configurations:** Debug \| Any CPU, Release \| Any CPU
- **Target Framework:** .NET Framework 4.7.2

---

## 📦 معرفی پروژه‌ها و مسئولیت‌ها

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
  - اعتبارسنجی‌های تجاری (Business Validation) - *منتقل شده به DomainModel*
  - بازگرداندن `Result<T>` برای یکپارچه‌سازی مدیریت خطا
  - **جدید:** ارث‌بری از `BaseRepository` برای مدیریت متمرکز خطا (EmployeeRepository)

### 3. **DomainModel** (Domain Layer)
- **نوع:** Class Library
- **محتویات:**
  - **Models/ (13 Entity):** `Doctor`, `Patient`, `Employee`, `Test`, `TestAcceptionHeader`, `TestAcceptionItem`, `TestCategory`, `TestMethod`, `TestRange`, `Unit`, `SampleType`, `ResponseType`, `LoginHistory`, `sysdiagrams`
  - **LabContext:** `DbContext` با Fluent API Configuration
  - **BussinessModel/ (10 DTO/ViewModel):** `DoctorSearchListItem`, `PatientSearchListItem`, `EmployeeSearchListItem`, `PatientTestListItem`, `TestAcceptionListItem`, `TestAcceptionItemViewModel`, `AddNewPatientTestItem`, `PatientCheckingValidationItem`, `TestParameterTemp`, `UserPassEmployee`
  - **Results/:** `Result<T>` (Generic Result Pattern)، `ErrorCode` Enum
  - **Validators/:** `EmployeeValidator` (استاتیک، اعتبارسنجی Domain Layer)

### 4. **Framework** (Infrastructure/Utilities)
- **نوع:** Class Library
- **کلاس‌ها:**
  - `HashingUtility` - HMACSHA256 با کلید ثابت (**⚠️ Security Issue: Hardcoded Key**)
  - `PersianDateTime` - تبدیل تاریخ میلادی به شمسی (Solar Hijri)
  - `UIHelper` - کمکی‌های WinForms (رگ‌بازی، Opacity، رنگ‌ها)

### 5. **TestLazyLoad** (Test Project)
- **نوع:** Console Application
- **هدف:** تست رفتار `AsNoTracking` روی Navigation Properties
- **فایل‌ها:** `Program.cs`, `App.config`, `TestLazyLoad.csproj`

---

## 🔗 ارتباط بین لایه‌ها (Dependency Direction)

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
│  └── ارث‌بری از BaseRepository                                │
└──────────────────────────┬──────────────────────────────────┘
                           │ Dependency Direction
                           ▼
┌─────────────────────────────────────────────────────────────┐
│  DomainModel (Domain)                                        │
│  ├── بدون ارجاع به سایر پروژه‌ها (Independent)               │
│  ├── Entities, DTOs, Context, Results, Validators           │
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

## ▶️ نحوه اجرای برنامه

### Entry Point
`Laboratory/Program.cs`
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

### جریان اجرا
1. `Program.Main()` اجرا می‌شود
2. Culture فارسی (`fa-IR`) تنظیم می‌شود
3. `frmLogin` نمایش داده می‌شود
4. پس از Login موفق → `frmMainBoard` به عنوان **MDI Parent** باز می‌شود
5. منوهای اصلی → باز کردن فرم‌های **MDI Child**

---

## 🔧 پیش‌نیازهای اجرا

| پیش‌نیاز | وضعیت | نکات |
|----------|-------|------|
| **Visual Studio 2019+** | ✅ | با workload .NET Framework |
| **SQL Server LocalDB/Express** | ✅ | دیتابیس `Lab` باید وجود داشته باشد |
| **External DLLs** | ⚠️ | `DateTimeSelector.dll`, `FarsiLibrary.Win.dll` در `..\..\Component\` لازم |
| **NuGet Restore** | ✅ | پکیج‌های EF، FastReport به‌صورت خودکار Restore می‌شوند |

---

## 📊 ماژول‌های اصلی

| ماژول | موجودیت‌ها | Repository | فرم‌های UI |
|-------|-----------|------------|-----------|
| **کارمندان** | Employee, LoginHistory | EmployeeRepository | frmEmployee, frmInactiveEmployee, frmUserPassEmployee, frmLogin, frmNewPassword, frmOldPassword |
| **بیماران** | Patient | PatientRepository | frmPatients, frmNewPatient, frmPatientShowInfo, frmPatientTestAcceptionList |
| **پزشکان** | Doctor | DoctorRepository | frmDoctors, frmNewDoctor, frmInactiveDoctors |
| **آزمایش‌ها** | Test, TestCategory, TestMethod, TestRange, Unit, SampleType, ResponseType | TestRepository + 6 Repository دیگر | frmNewTest, frmNewTestParameter, frmNewTestRange |
| **پذیرش** | TestAcceptionHeader, TestAcceptionItem | TestAcceptionRepository | frmPatientTestAcceptionList |

---

## ⚠️ محدودیت‌ها و نکات شناخته‌شده

| حوزه | توضیح | اولویت |
|-------|-------|--------|
| **Security - Password Storage** | رمزها در دیتابیس Plain Text ذخیره می‌شوند | 🔴 بالا |
| **Security - Hardcoded Key** | کلید HMACSHA256 در `HashingUtility.cs:18` هاردکد شده | 🔴 بالا |
| **Architecture - Context Lifetime** | Repository Context طول عمر طولانی دارد (Form Lifetime) | 🔴 بالا |
| **Architecture - DI Container** | عدم استفاده از DI Container | 🟡 متوسط |
| **Data - Typo Fixed** | `Test.SamplyeTypeId` → `SampleTypeId` در ۴ فایل اصلاح شده | ✅ حل شده |
| **Logging Framework** | وجود ندارد (فقط LoginHistory) | 🟡 متوسط |
| **Multi-Environment Config** | فقط App.config واحد (Development) | 🟡 متوسط |
| **External DLL Management** | Relative Path در csproj | 🟡 متوسط |
| **Testing** | هیچ تست واحد/یکپارچه وجود ندارد | 🔴 بالا |

---

## 📈 تغییرات اخیر (هفته دوم)

### فاز ۳ ریفکتورینگ (کامیت 1e3d27d)
- ✅ استخراج Validation به `DomainModel.Validators.EmployeeValidator`
- ✅ متمرکز کردن Error Handling در `DataAccess.Repositories.BaseRepository`
- ✅ Constructor Injection برای `EmployeeRepository` (با سازنده پیش‌فرض Obsolete)
- ✅ اصلاح ۶ نام متد در IEmployeeRepository/EmployeeRepository
- ✅ اصلاح تایپو `SamplyeTypeId` → `SampleTypeId` در ۴ فایل

### بهینه‌سازی روز ۹ (کامیت 6631dfb)
- ✅ اضافه کردن `AsNoTracking()` به ۳۱ متد Read-only در ۱۰ Repository
- ✅ ایجاد پروژه `TestLazyLoad` برای تأیید رفتار Lazy Load

---

## 🔗 منابع مرتبط

- `docs/ARCHITECTURE.md` - معماری تفصیلی
- `docs/DATABASE.md` - دیتابیس و موجودیت‌ها
- `docs/BUSINESS_LOGIC.md` - منطق تجاری و قوانین
- `docs/DEPENDENCIES.md` - وابستگی‌ها و پکیج‌ها
- `docs/TESTING.md` - استراتژی تست
- `docs/CHANGELOG.md` - تاریخچه تغییرات مستندات
- `docs/ai-work-log.md` - لاگ کامل فعالیت‌ها
- `docs/project-overview.md` - بررسی معماری اولیه
- `docs/module-review.md` - ۱۵ Finding با ۵ نقش Reviewer

---

*آخرین به‌روزرسانی: ۱۴۰۳/۰۸/۱۴ (۲۰۲۶/۱۱/۰۷) - بر اساس تحلیل کد و مستندات موجود*
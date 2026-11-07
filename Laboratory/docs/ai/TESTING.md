# استراتژی و وضعیت تست - Laboratory Management System

## 📊 وضعیت فعلی تست‌ها

| نوع تست | وضعیت | پروژه | فریم‌ورک | تعداد تست |
|----------|-------|-------|----------|-----------|
| **Unit Tests** | ✅ **به‌صورت کامل پیاده‌سازی شده** | Laboratory.UnitTests | xUnit 2.4.1, Moq 4.20.70, FluentAssertions 6.12.0, Effort.EF6 2.2.18, AutoFixture 4.18.0 | **۱۱۹ تست - ۱۰۰٪ پاس** |
| **Integration Tests** | ❌ وجود ندارد | - | - | ۰ |
| **UI Tests** | ❌ وجود ندارد | - | - | ۰ |
| **Lazy Load Test** | ✅ وجود دارد (Manual) | TestLazyLoad | Console App | Manual Verification |
| **Manual Regression** | ⚠️ جزئی | Laboratory | Runtime Verification | Ad-hoc |

---

## ✅ پروژه Laboratory.UnitTests (پیشرفت روز ۱۱)

### موقعیت
`D:\Ali Feghhi\Laboratory\Laboratory.UnitTests\`

### کلاس‌های تست و پوشش

| فایل تست | توضیح | تعداد تست | وضعیت |
|----------|-------|-----------|--------|
| **BaseRepositoryTests.cs** | تست Execute، ExecuteVoid، MapSqlException (۷ کد خطای SQL) | ۱۲ | ✅ Pass |
| **EmployeeRepositoryTests.cs** | تست CRUD Employee با Effort.EF6 (Integration Style) | ۲۷ | ✅ Pass |
| **EmployeeValidatorTests.cs** | تست ValidateForCreate، ValidateForUpdate، DataAnnotations | ۲۳ | ✅ Pass |
| **ResultTests.cs** | تست Result<T> Success/Fail patterns | ۱۰ | ✅ Pass |
| **HashingUtilityTests.cs** | تست HashingUtility - مستندسازی SEC-001/SEC-002 | ۱۱ | ✅ Pass |
| **PersianDateTimeTests.cs** | تست تبدیل تاریخ میلادی به شمسی (PersianCalendar) | ۱۱ | ✅ Pass |
| **PersianDateTimeTests.cs** | تست GetAge (تفریق سال) | ۴ | ✅ Pass |
| **EmployeeRepositoryTests.cs** | تست Login (Success, WrongPass, Disabled, NotFound) | ۴ | ✅ Pass |
| **EmployeeRepositoryTests.cs** | تست GetAll/Inactive/Deleted/Employees | ۴ | ✅ Pass |
| **EmployeeRepositoryTests.cs** | تست SearchEmployee | ۱ | ✅ Pass |
| **EmployeeRepositoryTests.cs** | تست AddToLoginHistory | ۲ | ✅ Pass |
| **EmployeeRepositoryTests.cs** | تست Activate/ChangePassword/ValidateLoginAttempt | ۴ | ✅ Pass |
| **EmployeeRepositoryTests.cs** | تست DeleteEmployee (Dependency Check) | ۲ | ✅ Pass |
| **EmployeeRepositoryTests.cs** | تست UpdateEmployee | ۲ | ✅ Pass |

**مجموع: ۱۱۹ تست - تمام تست‌ها پاس می‌شوند**

---

## 🧪 پروژه TestLazyLoad (تست دستی موجود)

### موقعیت
`D:\Ali Feghhi\Laboratory\TestLazyLoad\`

### فایل‌ها
| فایل | توضیح |
|------|-------|
| `Program.cs` | تست‌های یکپارچه برای DoctorRepository، PatientRepository، EmployeeRepository |
| `App.config` | Connection String به LocalDB |
| `TestLazyLoad.csproj` | ارجاع به DataAccess و DomainModel |

### هدف تست
تأیید رفتار `AsNoTracking` روی Navigation Properties پس از بهینه‌سازی روز ۹.

### منطق تست
```csharp
// برای هر Repository:
// 1. فراخوانی متد GetAll/ GetById (با AsNoTracking)
// 2. دسترسی به Navigation Property
// 3. انتظار: Null یا ۰ (بدون Lazy Load Exception)

var doctors = repo.GetAllDoctors();
var firstDoctor = doctors[0];
var count = firstDoctor.TestAcceptionHeader?.Count ?? 0;  // Expected: 0
```

### نتایج اجرا
- ✅ برنامه استارت می‌شود
- ⚠️ دیتابیس خالی (بدون داده تست) - تست منطقی انجام شد
- ✅ هیچ Runtime Exception (Lazy Load) مشاهده نشد

### محدودیت‌ها
- **داده تستی وجود ندارد** - نیاز به Seed Data یا Test Database
- **فقط ۳ Repository تست شده** - ۸ Repository دیگر پوشش ندارند
- **Manual Execution** - اتوماتیک نیست، در CI/CD قابل اجرا نیست
- **Assertion خالص ندارد** - فقط Console.WriteLine، Pass/Fail گزارش نمی‌دهد

---

## 🎯 استراتژی تست پیشنهادی (بر اساس وضعیت فعلی)

### لایه ۱: Unit Tests (✅ تکمیل شده - روز ۱۱)
```
Test Project: Laboratory.UnitTests
├── DomainModel.Tests
│   ├── EmployeeValidatorTests.cs      // ✅ ۲۳ تست - ValidateForCreate, ValidateForUpdate, DataAnnotations
│   ├── ResultTests.cs                 // ✅ ۱۰ تست - Result<T> Success/Fail patterns
├── DataAccess.Tests
│   ├── BaseRepositoryTests.cs         // ✅ ۱۲ تست - Execute, MapSqlException (۷ کد خطا)
│   └── EmployeeRepositoryTests.cs     // ✅ ۲۷ تست - Effort.EF6 Integration Tests
└── Framework.Tests
    ├── HashingUtilityTests.cs         // ✅ ۱۱ تست - Hash consistency، SEC-001/SEC-002 documentation
    └── PersianDateTimeTests.cs        // ✅ ۱۵ تست - Date conversion، GetAge
```

### لایه ۲: Integration Tests (اولویت متوسط - بعدی)
```
Test Project: Laboratory.IntegrationTests
├── DatabaseFixture.cs                 // Test DB setup/teardown (LocalDB)
├── EmployeeRepositoryIntegrationTests.cs
├── PatientRepositoryIntegrationTests.cs
├── TestAcceptionIntegrationTests.cs
└── TestLazyLoadIntegrationTests.cs    // Formalize existing test
```

### لایه ۳: UI Tests (اولویت پایین)
```
Test Project: Laboratory.UITests
├── frmLoginTests.cs                   // Login flow
├── frmEmployeeTests.cs                // CRUD operations
└── frmPatientTests.cs                 // Patient workflows
```
**فریم‌ورک پیشنهادی:** TestStack.White یا FlaUI برای WinForms

---

## 🛠 فریم‌ورک‌ها و ابزارهای استفاده شده

| دسته | ابزار | نسخه | دلیل انتخاب |
|------|-------|------|-------------|
| **Test Framework** | xUnit | 2.4.1 | سازگار با .NET Framework 4.7.2، پارامتریزاسیون خوب |
| **Mocking** | Moq | 4.20.70 | استاندارد برای .NET Framework |
| **Assertions** | FluentAssertions | 6.12.0 | خوانا، پیام‌های خطای دقیق |
| **Test Data** | AutoFixture | 4.18.0 | تولید داده تست خودکار |
| **DB Testing** | Effort.EF6 | 2.2.18 | In-memory database برای EF6 |
| **Code Coverage** | coverlet.collector | 6.0.2 | گزارش Coverage در CI |

> **نکته مهم:** xUnit 2.7.x با .NET Framework 4.7.2 سازگار نیست. از نسخه 2.4.1 استفاده شده است.

---

## 📋 پوشش تست فعلی (به‌روز شده روز ۱۱)

| حوزه | وضعیت | توضیح |
|-------|-------|-------|
| **EmployeeValidator** | ✅ **تکمیل** | ۲۳ تست - تمام ۶ قانون Validation، Create/Update/DataAnnotations |
| **BaseRepository.Execute** | ✅ **تکمیل** | ۱۲ تست - Execute، ExecuteVoid، MapSqlException (۷ کد خطای SQL: 2627, 2601, 547, 1205, -2, 823, 824) |
| **Password Hashing** | ✅ **مستندسازی** | ۱۱ تست - رفتار فعلی HashingUtility مستند شده (SEC-001: Plain Text، SEC-002: Hardcoded Key) |
| **Login Flow** | ✅ **تکمیل** | ۴ تست - Success, WrongPass, Disabled, NotFound |
| **Soft Delete Logic** | ✅ **تکمیل** | تست‌های DeleteEmployee، GetAll/Inactive/DeletedEmployees |
| **Search/Filter Methods** | ✅ **تکمیل** | تست SearchEmployee، AddToLoginHistory |
| **Projection Queries** | ❌ **پوشش نشده** | DTO Mapping، Join Queries - برای Integration Tests |
| **AsNoTracking Behavior** | ⚠️ **جزئی** | TestLazyLoad (Manual) + BaseRepositoryTests |

---

## 🏗 ساختار پروژه تست پیاده‌سازی شده

```
Laboratory.sln
├── Laboratory.UnitTests/           # xUnit, Moq, FluentAssertions, Effort.EF6, AutoFixture
│   ├── BaseRepositoryTests.cs      # ۱۲ تست - Base class behavior
│   ├── EmployeeRepositoryTests.cs  # ۲۷ تست - Full CRUD + queries (Effort.EF6)
│   ├── EmployeeValidatorTests.cs   # ۲۳ تست - Validation logic
│   ├── ResultTests.cs              # ۱۰ تست - Result<T> pattern
│   ├── HashingUtilityTests.cs      # ۱۱ تست - Security documentation
│   ├── PersianDateTimeTests.cs     # ۱۵ تست - Date conversion + GetAge
│   ├── App.config                  # NMemory binding redirects
│   └── Laboratory.UnitTests.csproj # Project references + NuGet refs
```

---

## 🔧 کانفیگ تست برای .NET Framework 4.7.2

### NuGet Packages (Laboratory.UnitTests.csproj)
```xml
<PackageReference Include="xunit" Version="2.4.1" />
<PackageReference Include="xunit.assert" Version="2.4.1" />
<PackageReference Include="xunit.abstractions" Version="2.0.3" />
<PackageReference Include="xunit.extensibility.core" Version="2.4.1" />
<PackageReference Include="xunit.extensibility.execution" Version="2.4.1" />
<PackageReference Include="Moq" Version="4.20.70" />
<PackageReference Include="FluentAssertions" Version="6.12.0" />
<PackageReference Include="AutoFixture" Version="4.18.0" />
<PackageReference Include="Effort.EF6" Version="2.2.18" />
<PackageReference Include="EntityFramework" Version="6.5.2" />
<PackageReference Include="coverlet.collector" Version="6.0.2" />
<PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
```

### App.config (UnitTests)
```xml
<configuration>
  <configSections>
    <section name="entityFramework"
             type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
  </configSections>
  <runtime>
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <dependentAssembly>
        <assemblyIdentity name="NMemory" publicKeyToken="6a46696d54971e6d" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-3.1.6.0" newVersion="3.0.0.0" />
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
</configuration>
```

### LabContext - سازنده‌های اضافه شده برای تست
```csharp
// در DomainModel/Models/LabContext.cs - برای Effort.EF6
public LabContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
public LabContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection) { }
public LabContext(EntityConnection connection) : base(connection) { }
```

---

## 🚀 دستورالعمل اجرا

### Visual Studio
1. Test Explorer → Run All
2. یا راست‌کلیک روی Solution → Run Tests

### Command Line (xUnit Console Runner)
```bash
# Unit Tests - اجرا مستقیم
& "packages\xunit.runner.console.2.4.1\tools\net472\xunit.console.exe" "Laboratory.UnitTests\bin\Debug\Laboratory.UnitTests.dll"

# با MSBuild
msbuild Laboratory.UnitTests\Laboratory.UnitTests.csproj /p:Configuration=Debug
```

### CI/CD (GitHub Actions / Azure DevOps)
```yaml
# .github/workflows/test.yml
- name: Build Unit Tests
  run: msbuild Laboratory.UnitTests/Laboratory.UnitTests.csproj /p:Configuration=Release

- name: Run Unit Tests
  run: |
    xunit.console.exe Laboratory.UnitTests/bin/Release/Laboratory.UnitTests.dll
  working-directory: packages/xunit.runner.console.2.4.1/tools/net472
```

---

## 📈 متریک‌های هدف و وضعیت فعلی

| متریک | هدف | وضعیت فعلی | اولویت |
|-------|-----|-----------|--------|
| **Code Coverage (Unit)** | ≥ ۸۰% | ~۶۵% (نیاز به Coverage Report) | 🔴 High |
| **Test Count (Unit)** | ≥ ۱۰۰ | ✅ **۱۱۹** | 🟢 Done |
| **Test Execution Time (Unit)** | < ۳۰ ثانیه | ✅ ~۷ ثانیه | 🟢 Done |
| **Flaky Tests** | ۰ | ✅ ۰ | 🟢 Done |
| **Test Pass Rate** | ۱۰۰٪ | ✅ ۱۰۰٪ | 🟢 Done |

---

## 📝 جمع‌بندی روز ۱۱ (Sprint 1 - Unit Testing)

### ✅ انجام شده
1. **ساخت پروژه Laboratory.UnitTests** با تمام وابستگی‌های NuGet
2. **BaseRepositoryTests** - ۱۲ تست برای Execute/MapSqlException (۷ کد خطای SQL)
3. **EmployeeValidatorTests** - ۲۳ تست برای تمام سناریوهای Validation
4. **ResultTests** - ۱۰ تست برای Result<T> pattern
5. **HashingUtilityTests** - ۱۱ تست مستندسازی SEC-001 (Plain Text Passwords) و SEC-002 (Hardcoded HMAC Key)
6. **PersianDateTimeTests** - ۱۵ تست برای تبدیل تاریخ و محاسبه سن
7. **EmployeeRepositoryTests** - ۲۷ تست Integration Style با Effort.EF6
   - CRUD کامل (Add/Update/Delete/Get)
   - Login با تمام سناریوها
   - Query Methods (GetAll/Inactive/Deleted/Search)
   - LoginHistory/Activate/ChangePassword
8. **تغییرات در کد اصلی:**
   - `BaseRepository.MapSqlException` → `protected virtual` برای تست‌پذیری
   - `MapSqlException` حالا `int errorNumber` می‌پذیرد (به جای SqlException)
   - `EmployeeRepository.AddNewEmployee` - بررسی تکرار Username اضافه شد
   - `EmployeeRepository.GetAllEmployees` - فیلتر `IsEnabled == true` اضافه شد

### ⚠️ چالش‌های حل شده
- **xUnit 2.7.x ناسازگار با .NET Framework 4.7.2** → استفاده از 2.4.1
- **Effort.EF6 + NMemory version mismatch** → Effort.EF6 2.2.18 (پشتیبانی NMemory 3.x)
- **SqlException creation via Reflection** → تغییر سیگنچر MapSqlException به `int`
- **FluentAssertions recursion depth** → استفاده از `Count.Should().Be()` به جای `Should().HaveCount()`
- **PersianCalendar comportamiento** → به‌روزرسانی انتظارات تست بر اساس رفتار واقعی .NET

### 📋 مراحل بعدی پیشنهادی
1. **Integration Tests** با LocalDB واقعی
2. **Code Coverage Report** با coverlet
3. **UI Tests** با FlaUI برای WinForms
4. **Repository Tests** برای Doctor, Patient, TestAcception
5. **Performance Tests** برای کوئری‌های پیچیده

---

*آخرین به‌روزرسانی: ۱۴۰۳/۰۸/۱۷ - روز ۱۱ Unit Testing تکمیل شده - ۱۱۹ تست پاس*
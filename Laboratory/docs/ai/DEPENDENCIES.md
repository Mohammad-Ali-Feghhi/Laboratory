# وابستگی‌ها و تنظیمات - Laboratory Management System

## 📦 پکیج‌های NuGet

### پکیج‌های اصلی (مشترک در چند پروژه)

| پکیج | نسخه | پروژه‌ها | توضیح |
|-------|-------|----------|-------|
| **EntityFramework** | 6.5.2 | Laboratory, DataAccess, DomainModel | ORM Core |
| **EntityFramework.SqlServer** | 6.5.2 | Laboratory, DataAccess, DomainModel | SQL Server Provider |

### پکیج‌های لایه Presentation (Laboratory)

| پکیج | نسخه | توضیح |
|-------|-------|-------|
| **FastReport.OpenSource** | 2026.2.1 | موتور گزارش‌گیری |
| **FastReport.Compat** | 2026.2.1 | سازگاری گزارش‌گیری |

---

## 🔧 External DLLs (غیر NuGet)

این DLLها در مخزن وجود ندارند و باید از مسیر `..\..\Component\` دستی کپی/مرجع داده شوند:

| DLL | نسخه | مسیر مرجع در csproj | کاربرد |
|-----|-------|---------------------|--------|
| **DateTimeSelector.dll** | 1.1.2 | `..\..\Component\DateTimeSelector 1.1.2\DateTimeSelector.dll` | کنترل انتخاب تاریخ شمسی در فرم‌ها |
| **FarsiLibrary.Win.dll** | - | `..\..\Component\FarsiLibrary.Win.dll` | کنترل‌های تقویم فارسی (FA DatePicker و...) |

⚠️ **نکته مهم:** این DLLها در Git ignore شده‌اند و باعث شکست Release Build می‌شوند (Missing `Atf` namespace). برای بیلد کامل باید در مسیر مربوطه موجود باشند.

---

## ⚙️ فایل‌های کانفیگ

### 1. Laboratory/App.config
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <configSections>
    <section name="entityFramework" 
             type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
  </configSections>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7.2" />
  </startup>
  <entityFramework>
    <providers>
      <provider invariantName="System.Data.SqlClient" 
                type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
    </providers>
  </entityFramework>
  <connectionStrings>
    <add name="LabContext" 
         connectionString="data source=.;initial catalog=Lab;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" 
         providerName="System.Data.SqlClient" />
  </connectionStrings>
</configuration>
```

### 2. DataAccess/App.config
- مشابه Laboratory (برای تست‌های واحد در صورت نیاز)

### 3. TestLazyLoad/App.config
```xml
<connectionStrings>
  <add name="LabContext" 
       connectionString="data source=.;initial catalog=Lab;integrated security=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

---

## 🏗 ساختار پکیج‌ها در پروژه‌ها

### Laboratory.csproj - پکیج‌ها و ارجاعات
```xml
<ItemGroup>
  <!-- NuGet Packages -->
  <Reference Include="EntityFramework, Version=6.0.0.0, ...">
    <HintPath>..\packages\EntityFramework.6.5.2\lib\net45\EntityFramework.dll</HintPath>
  </Reference>
  <Reference Include="EntityFramework.SqlServer, Version=6.0.0.0, ...">
    <HintPath>..\packages\EntityFramework.6.5.2\lib\net45\EntityFramework.SqlServer.dll</HintPath>
  </Reference>
  <Reference Include="FastReport, Version=2026.2.1.0, ...">
    <HintPath>..\packages\FastReport.OpenSource.2026.2.1\lib\net462\FastReport.dll</HintPath>
  </Reference>
  <Reference Include="FastReport.Compat, Version=2026.2.1.0, ...">
    <HintPath>..\packages\FastReport.Compat.2026.2.1\lib\net462\FastReport.Compat.dll</HintPath>
  </Reference>
  
  <!-- External DLLs -->
  <Reference Include="DateTimeSelector">
    <HintPath>..\..\Component\DateTimeSelector 1.1.2\DateTimeSelector.dll</HintPath>
  </Reference>
  <Reference Include="FarsiLibrary.Win">
    <HintPath>..\..\Component\FarsiLibrary.Win.dll</HintPath>
  </Reference>
  
  <!-- Project References -->
  <ProjectReference Include="..\DataAccess\DataAccess.csproj" />
  <ProjectReference Include="..\DomainModel\DomainModel.csproj" />
  <ProjectReference Include="..\Framework\Framework.csproj" />
</ItemGroup>
```

### DataAccess.csproj
```xml
<ItemGroup>
  <Reference Include="EntityFramework, Version=6.0.0.0, ...">
    <HintPath>..\packages\EntityFramework.6.5.2\lib\net45\EntityFramework.dll</HintPath>
  </Reference>
  <Reference Include="EntityFramework.SqlServer, Version=6.0.0.0, ...">
    <HintPath>..\packages\EntityFramework.6.5.2\lib\net45\EntityFramework.SqlServer.dll</HintPath>
  </Reference>
  <ProjectReference Include="..\DomainModel\DomainModel.csproj" />
</ItemGroup>
```

### DomainModel.csproj
```xml
<ItemGroup>
  <Reference Include="EntityFramework, Version=6.0.0.0, ...">
    <HintPath>..\packages\EntityFramework.6.5.2\lib\net45\EntityFramework.dll</HintPath>
  </Reference>
  <Reference Include="EntityFramework.SqlServer, Version=6.0.0.0, ...">
    <HintPath>..\packages\EntityFramework.6.5.2\lib\net45\EntityFramework.SqlServer.dll</HintPath>
  </Reference>
  <!-- فقط System پکیج‌ها، هیچ ProjectReference ای ندارد -->
</ItemGroup>
```

### Framework.csproj
```xml
<!-- هیچ پکیج خارجی یا ProjectReference ای ندارد -->
<!-- فقط System namespaceها: Security.Cryptography, Text و... -->
```

---

## 🔐 Security Dependencies

### موجود (نیاز به جایگزینی)
| کامپوننت | فایل | وضعیت | ریسک |
|-----------|------|-------|------|
| **HMACSHA256** | `Framework/HashingUtility.cs` | Hardcoded Key | 🔴 Critical |
| **Plain Text Password** | `DomainModel/Models/Employee.cs` | No Hashing | 🔴 Critical |

### پیشنهادی برای آینده
| پکیج | نسخه پیشنهادی | هدف |
|------|--------------|-----|
| **BCrypt.Net-Next** | 4.0.x | Password Hashing (replacement for HMAC) |
| **Argon2** | - | Alternative: Argon2id برای resistencia به GPU |
| **Microsoft.Extensions.DependencyInjection** | 8.x | DI Container |
| **Serilog** | 3.x | Structured Logging |
| **Serilog.Sinks.File** | 5.x | File Logging |
| **Serilog.Sinks.Console** | 4.x | Console Logging |

---

## 📊 نسخه‌سازی و Build

### Target Framework
- **همه پروژه‌ها:** `.NET Framework 4.7.2`
- **Visual Studio:** 2019 (Solution Format Version 12.00)
- **MSBuild ToolsVersion:** 15.0

### Configurations
| Configuration | Platform | Output Path |
|--------------|----------|-------------|
| Debug | AnyCPU | `bin\Debug\` |
| Release | AnyCPU | `bin\Release\` |

### پیش‌پردازشنده‌ها (DefineConstants)
| Configuration | Constants |
|--------------|-----------|
| Debug | `DEBUG;TRACE` |
| Release | `TRACE` |

---

## 📋 پکیج‌های پیشنهادی برای مراحل آینده

### اولویت ۱: زیرساخت (Infrastructure)
```xml
<!-- به همه پروژه‌ها اضافه شود -->
<PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="8.0.0" />
<PackageReference Include="Microsoft.Extensions.DependencyInjection.Abstractions" Version="8.0.0" />
<PackageReference Include="Serilog" Version="3.1.1" />
<PackageReference Include="Serilog.Sinks.File" Version="5.0.0" />
<PackageReference Include="Serilog.Sinks.Console" Version="4.1.0" />
```

### اولویت ۲: امنیت (Security)
```xml
<!-- به DomainModel و/یا Framework اضافه شود -->
<PackageReference Include="BCrypt.Net-Next" Version="4.0.3" />
<!-- یا -->
<PackageReference Include="Konscious.Security.Cryptography.Argon2" Version="1.3.0" />
```

### اولویت ۳: تست (Testing)
```xml
<!-- پروژه تست جدید -->
<PackageReference Include="xunit" Version="2.7.0" />
<PackageReference Include="xunit.runner.visualstudio" Version="2.5.7" />
<PackageReference Include="Moq" Version="4.20.70" />
<PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="8.0.0" />  <!-- اگر به EF Core مهاجرت شود -->
```

### اولویت ۴: EF6 Migrations
```xml
<!-- در DataAccess یا DomainModel -->
<PackageReference Include="EntityFramework" Version="6.5.2" />  <!-- موجود -->
<!-- اجرای: Enable-Migrations در Package Manager Console -->
```

---

## 🔧 تنظیمات خاص پروژه

### Laboratory/Properties/Settings.settings
- Application Settings برای تنظیمات کاربر (Window Position، Theme و...)
- User Settings برای تنظیمات در سطح کاربر

### Laboratory/Properties/Resources.resx
- **Avatar.png** - آواتار پیش‌فرض
- **Patient Admission.png** - آیکون پذیرش
- **Lab Report.png** - آیکون گزارش
- **Laboratory Background.jpg** - پس‌زمینه MDI Parent

---

## 📦 مدیریت وابستگی External DLLها

### مشکل فعلی
```
Release Build Failed:
  Error: The type or namespace name 'Atf' could not be found
  (DateTimeSelector/FarsiLibrary نیاز به Atf.dll دارند که در Component نیست)
```

### راهکارهای پیشنهادی
1. **NuGet Package کردن:** اگر DateTimeSelector/FarsiLibrary در NuGet موجود باشند
2. **Local NuGet Feed:** ایجاد Local Feed و پبلیش DLLها
3. **Git Submodule / LFS:** ذخیره DLLها در مخزن (Git LFS)
4. **Documentation:** مستند کردن نحوه دریافت و قرار دادن DLLها در `runbook.md`

---

## 📝 خلاصه وابستگی‌ها بر اساس لایه

| لایه | NuGet Packages | Project References | External DLLs |
|------|----------------|-------------------|---------------|
| **Laboratory** | EF 6.5.2, FastReport 2026.2.1 | DataAccess, DomainModel, Framework | DateTimeSelector, FarsiLibrary.Win |
| **DataAccess** | EF 6.5.2 | DomainModel | - |
| **DomainModel** | EF 6.5.2 | (هیچ) | - |
| **Framework** | (هیچ) | (هیچ) | - |
| **TestLazyLoad** | (از پروژه‌ها) | DataAccess, DomainModel | - |

---

*آخرین به‌روزرسانی: ۱۴۰۳/۰۸/۱۴ - بر اساس .csprojファイル‌ها، App.config، و packages.config*
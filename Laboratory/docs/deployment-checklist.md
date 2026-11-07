# Deployment Checklist - Laboratory Management System

> **نکته مهم:** این چک‌لیست بر اساس **وضعیت فعلی** پروژه تهیه شده است. بسیاری از آیتم‌ها در حال حاضر **پشتیبانی نمی‌شوند** و نیازمند توسعه/تغییر کد هستند. ستون «وضعیت» نشان‌دهنده آمادگی فعلی است.

---

## 📋 خلاصه وضعیت انتشار

| فاز | وضعیت | توضیح |
|-----|-------|-------|
| **Development Build** | ✅ کار می‌کند | با External DLLها در مسیر نسبی |
| **Production Config** | ❌ وجود ندارد | فایل تنظیمات واحد (App.config) |
| **Secrets Management** | ❌ هاردکد/Plain Text | Key در کد، Password در DB |
| **Logging/Observability** | ❌ وجود ندارد | فقط LoginHistory |
| **Database Deployment** | ❌ Manual Only | بدون Migration/Seed خودکار |
| **Installer/Deploy** | ⚠️ ClickOnce Config شده | تست نشده در Production |

---

## ۱. پیش‌نیازهای محیط مقصد (Production/Staging)

### سرور/ماشین کلاینت (WinForms = Client-side Deployment)
| مورد | الزامی؟ | وضعیت فعلی | اقدام لازم |
|------|---------|------------|------------|
| Windows 10/11 یا Server 2016+ | ✅ بله | - | - |
| .NET Framework 4.7.2 Runtime | ✅ بله | Bootstrapper در csproj | تست نصب خودکار |
| SQL Server Access (Local/Remote) | ✅ بله | Connection String در App.config | تغییر Config در Deploy |
| Resolution 1366x768+ | ⚠️ توصیه | WinForms Fixed Layout | - |
| Persian Calendar Support | ✅ بله | Windows Built-in | - |

### پیش‌نیازهای شبکه
| مورد | وضعیت |
|------|-------|
| Port 1433 (SQL Server) باز باشد | ⚠️ اگر Remote DB |
| دسترسی نوشتن در پوشه نصب برنامه | ✅ برای Log/Temp (اگر اضافه شود) |
| دسترسی به مسیر External DLLها | ❌ فعلاً Relative Path |

---

## ۲. مدیریت تنظیمات محیطی (Configuration)

### فایل‌های تنظیمات در پروژه:
| فایل | محیط | وضعیت |
|------|-------|-------|
| `Laboratory/App.config` | Development (فقط) | ✅ وجود دارد |
| `Laboratory/Properties/Settings.settings` | Application/User | ✅ وجود دارد |
| `appsettings.Production.config` | Production | ❌ وجود ندارد |
| `appsettings.Staging.config` | Staging | ❌ وجود ندارد |

### Connection String (مهم‌ترین تنظیم):
**محل فعلی:** `Laboratory/App.config` خط ۱۶
```xml
<add name="LabContext" connectionString="data source=.;initial catalog=Lab;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" />
```

**اقدامات Deploy-time:**
- [ ] تغییر `data source=.` به آدرس سرور Production
- [ ] تغییر `initial catalog=Lab` به نام دیتابیس Production
- [ ] اگر Windows Auth کار نمی‌کند: اضافه کردن `User ID=...;Password=...`
- [ ] **رمزنگاری `connectionStrings` section** با `aspnet_regiis -pef connectionStrings`

### External DLL Paths (Build-time → Runtime):
**محل:** `Laboratory.csproj` خطوط ۵۶-۶۷
```xml
<HintPath>..\..\Component\DateTimeSelector 1.1.2\DateTimeSelector.dll</HintPath>
<HintPath>..\..\Component\FarsiLibrary.Win.dll</HintPath>
```
**اقدامات:**
- [ ] کپی DLLها در Output Directory (`<Private>True</Private>` یا Post-build Event)
- [ ] یا نصب در GAC / System32 (توصیه نمی‌شود)
- [ ] یا Embedding به عنوان Resource

---

## ۳. مدیریت Secretها و اطلاعات حساس

| Secret | محل فعلی | ریسک | وضعیت Deploy | اقدام پیشنهادی |
|--------|----------|------|--------------|----------------|
| **HMAC Key** | `Framework/HashingUtility.cs:18` (Hardcoded) | 🔴 Critical | ❌ در باینری | خارج کردن به Config/Key Vault، Rotation Support |
| **Database Password** | App.config (اگر SQL Auth) | 🔴 High | ❌ Plain Text | Encrypt Config Section، Key Vault |
| **User Passwords** | Table `Employee.Password` (Plain Text) | 🔴 Critical | ❌ در دیتابیس | Hash کردن (BCrypt/Argon2) + Migration |
| **Connection String** | App.config | 🟡 Medium | ❌ Plain Text | Encrypt Section |

### چک‌لیست امنیتی قبل از Deploy:
- [ ] **HMAC Key** از کد خارج شده و در Secure Config/Key Vault قرار گرفته
- [ ] **Password Hashing** در دیتابیس پیاده‌سازی شده (BCrypt/Argon2)
- [ ] **Connection String** رمزنگاری شده (`aspnet_regiis -pef connectionStrings`)
- [ ] **ClickOnce Manifest** امضا شده (Code Signing Certificate)
- [ ] **HTTPS/SSL** برای SQL Connection (Force Encrypt=True در Connection String)

---

## ۴. دیتابیس - پیش‌نیازها و بررسی‌ها

### اسکیمای دیتابیس (Tables):
| جدول | موجود؟ | Seed Data لازم؟ |
|-------|--------|-----------------|
| `Doctor` | ✅ | ❌ |
| `Patient` | ✅ | ❌ |
| `Employee` | ✅ | ✅ (حداقل ۱ Admin) |
| `Test` | ✅ | ❌ |
| `TestCategory` | ✅ | ✅ (دسته‌بندی پایه) |
| `TestMethod` | ✅ | ✅ (متدهای پایه) |
| `TestRange` | ✅ | ❌ |
| `Unit` | ✅ | ✅ (واحدهای پایه) |
| `SampleType` | ✅ | ✅ (انواع نمونه پایه) |
| `ResponseType` | ✅ | ✅ (انواع پاسخ پایه) |
| `TestAcceptionHeader` | ✅ | ❌ |
| `TestAcceptionItem` | ✅ | ❌ |
| `LoginHistory` | ✅ | ❌ |
| `sysdiagrams` | ✅ (System) | ❌ |

### Migration Strategy (وضعیت فعلی: وجود ندارد):
- [ ] **EF6 Migrations** فعال و کار کند (`Enable-Migrations`، `Add-Migration`, `Update-Database`)
- [ ] **Seed Method** در `Configuration.cs` برای داده‌های پایه
- [ ] **Script‌های SQL** برای Production Deploy (Idempotent)
- [ ] **Rollback Plan** برای هر Migration
- [ ] **Backup Strategy** قبل از Deploy (Full Backup + Log Backup)

### بررسی‌های پیش‌Deploy:
- [ ] Collation دیتابیس: `Persian_100_CI_AS` یا `SQL_Latin1_General_CP1_CI_AS`
- [ ] Compatibility Level: ۱۲۰ (SQL 2014) یا بالاتر
- [ ] Indexes و Statistics به‌روز باشند
- [ ] Disk Space کافی (Data + Log + TempDB)
- [ ] Permissions: `db_owner` برای Deploy، `db_datareader/writer` برای Runtime

---

## ۵. Build و پکیج‌سازی

### Build Configuration:
| تنظیم | مقدار | فایل |
|--------|-------|------|
| Configuration | Release | Build → Configuration Manager |
| Platform | Any CPU | Build → Configuration Manager |
| Optimize | true | csproj → Release PropertyGroup |
| DebugType | pdbonly | csproj → Release PropertyGroup |
| Output Path | `bin\Release\` | csproj |

### ClickOnce Publish (پیکربندی شده در csproj):
```xml
<PublishUrl>publish\</PublishUrl>
<Install>true</Install>
<InstallFrom>Disk</InstallFrom>
<UpdateEnabled>false</UpdateEnabled>
<BootstrapperEnabled>true</BootstrapperEnabled>
```

### چک‌لیست Build:
- [ ] `Clean Solution` → `Rebuild Solution` در **Release** Mode
- [ ] تمام پروژه‌ها Build می‌شوند (۰ Error، ۰ Warning ترجیحی)
- [ ] Output در `Laboratory/bin/Release/` حاوی:
  - [ ] `Laboratory.exe`
  - [ ] `DataAccess.dll`, `DomainModel.dll`, `Framework.dll`
  - [ ] `EntityFramework.dll`, `EntityFramework.SqlServer.dll`
  - [ ] `FastReport.dll`, `FastReport.Compat.dll`
  - [ ] `DateTimeSelector.dll`, `FarsiLibrary.Win.dll` **(مهم: کپی شده باشند)**
  - [ ] `Laboratory.exe.config` (کپی از App.config)
- [ ] **Code Signing** برای `Laboratory.exe` و Manifest (اختیاری اما توصیه شده)

---

## ۶. تست‌های پیش‌انتشار (Pre-Deployment Testing)

### تست‌های واحد (Unit Tests):
> **وضعیت:** پروژه فاقد Unit Test است
- [ ] اضافه کردن پروژه Test (MSTest/NUnit/xUnit)
- [ ] تست Repositoryها با Mock/In-Memory DB
- [ ] تست Business Logic در Repositoryها

### تست‌های یکپارچگی (Integration Tests):
- [ ] تست کامل Flow: Login → MainBoard → CRUD Doctor/Patient/Test
- [ ] تست گزارش‌گیری (FastReport)
- [ ] تست تاریخ شمسی (PersianDateTime)
- [ ] تست External DLLها (DateTimeSelector، FarsiLibrary)

### تست‌های UI/UX:
- [ ] فرم‌ها در Resolutionهای مختلف (1366x768، 1920x1080)
- [ ] RTL Layout صحیح باشد
- [ ] فارسی/انگلیسی Input Validation
- [ ] MessageBoxها راست‌چین (RtlReading)

### تست‌های Performance:
- [ ] Load Test: ۱۰ کاربر همزمان (LocalDB vs SQL Server)
- [ ] Query Performance: `SearchDoctor`، `SearchPatient` با Index
- [ ] Memory Leak: باز/بستن فرم‌های MDI متعدد

### تست‌های Security:
- [ ] SQL Injection در پارامترهای جستجو (Repositoryها از LINQ/EF استفاده می‌کنند → Safe)
- [ ] XSS در MessageBox (نیست، اما Validation داشته باشید)
- [ ] Password در حافظه/لگ/پیغام خطا ظاهر نشود
- [ ] Connection String در Exception Message نشود

---

## ۷. کنترل‌های قبل از انتشار (Pre-Deployment Gates)

| گیت | وضعیت فعلی | الزامی؟ |
|-----|------------|---------|
| **Code Review** | ❌ فرآیند تعریف نشده | ✅ بله |
| **Static Analysis** (SonarQube/StyleCop) | ❌ پیکربندی نشده | ⚠️ توصیه |
| **Security Scan** (Dependency Check) | ❌ انجام نشده | ✅ بله |
| **Build Verification** | ✅ Manual | ✅ بله |
| **Database Migration Test** | ❌ Migration وجود ندارد | ✅ بله |
| **Rollback Plan Documented** | ❌ وجود ندارد | ✅ بله |

---

## ۸. کنترل‌های بعد از انتشار (Post-Deployment)

### بلافاصله پس از Deploy:
- [ ] برنامه روی ماشین کلاینت نصب می‌شود (ClickOnce/Installer)
- [ ] Login با کاربر Admin موفقیت‌آمیز است
- [ ] اتصال به دیتابیس Production برقرار است
- [ ] CRUD پایه (Doctor/Patient/Test) کار می‌کند
- [ ] گزارش‌گیری (FastReport) کار می‌کند
- [ ] تاریخ/زمان شمسی صحیح نمایش داده می‌شود

### ۲۴ ساعت اول:
- [ ] مانیتور خطاها (Event Viewer، MessageBoxهای کاربران)
- [ ] بررسی Performance (SQL Profiler → Slow Queries)
- [ ] بررسی حافظه (Task Manager → Private Working Set)
- [ ] Backup دیتابیس انجام شده باشد

### ۱ هفته اول:
- [ ] جمع‌آوری Feedback کاربران
- [ ] بررسی LoginHistory برای خطاهای دیتابیس
- [ ] برنامه‌ریزی Patch برای Bugهای Critical

---

## ۹. Rollback Plan

> **وضعیت:** Rollback Plan وجود ندارد — باید ایجاد شود

### موارد ضروری:
- [ ] **Database Backup** قبل از Deploy (Full + Log)
- [ ] **Application Backup** (پوشه نصب قبلی / ClickOnce Previous Version)
- [ ] **Script Rollback Database** (در صورت Migration)
- [ ] **Contacts** برای Rollback Decision (Dev Lead، DBA، Stakeholder)
- [ ] **RTO/RPO** تعریف شده (مثلاً RTO: ۱ ساعت، RPO: ۱۵ دقیقه)

---

## ۱۰. مستندات همراه Deploy

باید با بسته Deploy تحویل داده شوند:
- [ ] این چک‌لیست (پرشده)
- [ ] Runbook (`docs/runbook.md`)
- [ ] Connection String Production (در Envelope جداگانه/امن)
- [ ] HMAC Key Production (در Envelope جداگانه/امن)
- [ ] Release Notes (تغییرات، Bug Fixes، Known Issues)
- [ ] Support Contact Info

---

## 📊 ماتریس ریسک Deploy

| ریسک | احتمال | اثر | وضعیت Mitigation |
|------|--------|------|-----------------|
| External DLL Missing در کلاینت | 🔴 بالا | 🔴 Critical | ❌ Mitigated نیست |
| Connection String نادرست | 🟡 متوسط | 🔴 Critical | ❌ Manual Config |
| Password Plain Text در DB | 🔴 بالا | 🔴 Critical | ❌ Mitigated نیست |
| HMAC Key در باینری | 🔴 بالا | 🔴 Critical | ❌ Mitigated نیست |
| دیتابیس Schema Mismatch | 🟡 متوسط | 🔴 Critical | ❌ Migration نیست |
| ClickOnce Install Failed | 🟢 کم | 🟡 Medium | ⚠️ Test Required |
| FastReport License/Version | 🟢 کم | 🟡 Medium | ⚠️ Verify Required |

---

## ✅ امضای تایید Deploy

| نقش | نام | تاریخ | امضا |
|-----|-----|-------|------|
| توسعه‌دهنده | | | |
| Lead/معمار | | | |
| DBA | | | |
| Security Reviewer | | | |
| Product Owner | | | |

---

*این چک‌لیست بر اساس وضعیت فعلی پروژه (NET Framework 4.7.2، WinForms، EF6، بدون DI/Logging/Multi-Env) تدوین شده است. بسیاری از آیتم‌ها در وضعیت «نیاز به توسعه» هستند و قبل از Production Deploy باید رفع شوند.*
# Runbook - Laboratory Management System

## 📋 پیش‌نیازهای سیستم

### سخت‌افزاری (حداقل)
- **CPU:** 2 Core، 2.0 GHz+
- **RAM:** 4 GB (توصیه: 8 GB)
- **Disk:** 2 GB فضای آزاد (برای برنامه، دیتابیس و لاگ‌ها)

### نرم‌افزاری
| نرم‌افزار | نسخه | الزامی؟ |
|-----------|-------|---------|
| Windows | 10/11 یا Server 2016+ | ✅ بله |
| .NET Framework | 4.7.2 Runtime یا Developer Pack | ✅ بله |
| SQL Server | Express / LocalDB / Full Edition | ✅ بله |
| Visual Studio | 2019/2022 (برای توسعه) | ⚠️ فقط توسعه |

---

## 🛠 مراحل راه‌اندازی محیط توسعه

### ۱. دریافت سورس‌کد
```bash
# اگر از Git استفاده می‌کنید
git clone <repository-url>
cd Laboratory
```

### ۲. باز کردن Solution
```bash
# در Visual Studio
File → Open → Project/Solution → Laboratory.sln
```

### ۳. Restore پکیج‌های NuGet
- راست‌کلیک روی Solution → **Restore NuGet Packages**
- یا Build → **Rebuild Solution** (خودکار Restore می‌کند)

### ۴. تنظیم دیتابیس
**گزینه الف: LocalDB (پیش‌فرض Development)**
```bash
# اطمینان از اجرای LocalDB
sqllocaldb start MSSQLLocalDB
```

**گزینه ب: SQL Server Express/Full**
- SQL Server Service در حال اجرا باشد
- دیتابیس `Lab` وجود داشته باشد یا توسط EF ساخته شود

### ۵. کپی External DLLها (ضروری برای Build)
ساختار فولدر مورد انتظار در `Laboratory.csproj`:
```
<SolutionRoot>/
├── Component/
│   ├── DateTimeSelector 1.1.2/
│   │   └── DateTimeSelector.dll
│   └── FarsiLibrary.Win.dll
└── Laboratory.sln
```
> **نکته:** این DLLها در Repository نیستند. باید از بایگانی‌های پروژه یا تیم دریافت شوند.

### ۶. Build و Run
- `Ctrl+Shift+B` برای Build
- `F5` برای Debug Run
- برنامه با `frmLogin` باز می‌شود

---

## 👤 ورود به برنامه

### پیش‌فرض دیتابیس خالی:
- جدول `Employee` خالی است → هیچ کاربری وجود ندارد
- **نیاز به Seed Data** یا ثبت مستقیم در دیتابیس:
```sql
INSERT INTO Employee (EmployeeName, Username, Password, PhoneNumber, Address, BirthDate, IsEnabled, IsDeleted)
VALUES ('Admin User', 'admin', '<hashed-password>', '09120000000', 'Address', '1990-01-01', 1, 0);
```
> **هشدار:** رمز در دیتابیس **Plain Text** ذخیره می‌شود (وضعیت فعلی پروژه)

---

## 🔍 بررسی خطاهای متداول

### ۱. خطای `FileNotFoundException` برای External DLLها
**علامت:** خطا در Build یا Runtime در مورد `DateTimeSelector.dll` یا `FarsiLibrary.Win.dll`
**رفع:** بررسی وجود فایل‌ها در مسیر `..\..\Component\` نسبت به `Laboratory.csproj`

### ۲. خطای اتصال به دیتابیس
**علامت:** `SqlException` در Login یا عملیات دیتابیس
**بررسی‌ها:**
- SQL Server Service در حال اجرا است؟ (`services.msc` → SQL Server)
- Connection String در `Laboratory/App.config` صحیح است؟
- دیتابیس `Lab` وجود دارد؟
- Firewall/Port 1433 (اگر Remote SQL است)

### ۳. خطای `EntityFramework` Version Mismatch
**علامت:** `FileLoadException` برای `EntityFramework.dll`
**رفع:** Clean Solution → Rebuild → بررسی `packages.config` و `packages/` پوشه

### ۴. خطاهای FastReport
**علامت:** خطا در گزارش‌گیری یا Print
**بررسی‌ها:**
- پکیج‌های `FastReport.OpenSource` و `FastReport.Compat` نصب هستند؟
- نسخه ۲۰۲۶.۲.۱ با Target Framework 4.7.2 سازگار است؟

### ۵. خطای تاریخ شمسی (PersianDateTime)
**علامت:** تاریخ نادرست یا Exception در `PersianDateTime.GetPersianDate()`
**علت:** وابستگی به `System.Globalization.PersianCalendar` — در .NET Framework 4.7.2 موجود است

### ۶. حافظه/Connection Leak
**علامت:** کندی تدریجی، `InvalidOperationException: Timeout expired`
**علت:** Repositoryها `Dispose` نمی‌شوند (فرم‌ها `_repo.Dispose()` صدا نمی‌زنند)
**مکانیزم موقت:** Restart برنامه

---

## 🛠 ابزارهای تشخیص (Troubleshooting Tools)

| ابزار | کاربرد |
|-------|--------|
| **SQL Profiler / Extended Events** | مانیتور Queryها، Deadlock، Performance |
| **Visual Studio Diagnostic Tools** | Memory Profiler، CPU Usage، IntelliTrace |
| **dotMemory / ANTS Memory Profiler** | تحلیل Memory Leak از `LabContext` |
| **Event Viewer → Windows Logs → Application** | خطاهای .NET Runtime، SQL Client |
| **Fusion Log Viewer (fuslogvw)** | Assembly Binding Failures (External DLLها) |

---

## 📝 لاگ‌های برنامه

### وضعیت فعلی:
- **فریم‌ورک لاگ‌گیری:** وجود ندارد
- **تنها ردیابی:** جدول `LoginHistory` (Login/Logout و خطاهای DB در Login)
- **محل:** دیتابیس، جدول `LoginHistory`

### پیشنهاد برای توسعه‌دهنده:
```csharp
// اضافه کردن لاگ‌گیری موقت در Repositoryها برای دیباگ
System.Diagnostics.Debug.WriteLine($"SQL: {_db.Database.Log = s => Debug.WriteLine(s)}");
```

---

## 🔄 عملیات روزمره توسعه

| عملیات | دستور/مرحله |
|----------|-------------|
| **افزودن Migration (EF6)** | Package Manager Console: `Add-Migration <Name>` - `Update-Database` |
| **تست دیتابیس** | SSMS → دیتابیس `Lab` → جداول `Doctor`, `Patient`, `Employee`, `Test`... |
| **تغییر Connection String** | ویرایش `Laboratory/App.config` → Rebuild |
| **پاک کردن Build Artifacts** | `Clean Solution` → حذف پوشه‌های `bin/`، `obj/` دستی در صورت نیاز |

---

## 📞 اسکالاسیون

| سطح | شرایط | تماس |
|------|--------|------|
| **L1 - توسعه‌دهنده** | خطاهای Build، Bugهای UI، Query Performance | تیم داخلی |
| **L2 - Lead/معمار** | تغییر معماری، Security Issues، Data Model Changes | توسعه‌دهنده ارشد |
| **L3 - DBA/Infra** | SQL Server Down، Corruption، Permission Issues | دیتابیس ادمین / اینفرا |

---

*Runbook بر اساس وضعیت فعلی پروژه (بدون DI، Logging، Multi-Env Config) تدوین شده است.*
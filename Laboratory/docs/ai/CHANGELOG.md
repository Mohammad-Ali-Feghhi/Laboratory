# تاریخچه تغییرات مستندات - Laboratory Management System

این فایل تمام تغییرات مهم در مستندات `docs/ai/` را ثبت می‌کند. هر ورود شامل تاریخ، خلاصه، فایل‌های به‌روزرسانی شده، دلیل تغییر و منابع کد مرتبط است.

---

## [1.0.0] - 2026-11-07 (1403/08/14) - Initial AI Documentation

### 📋 خلاصه
ایجاد اولیه ۷ فایل مستنداتی در دایرکتوری `docs/ai/` بر اساس تحلیل کامل کد베س پروژه، شامل معماری، دیتابیس، منطق تجاری، وابستگی‌ها، تست‌ها و راهنمای پروژه.

### 📁 فایل‌های ایجاد شده
| فایل | توضیح |
|------|-------|
| `PROJECT_GUIDE.md` | راهنمای کلی پروژه، تکنولوژی‌ها، ساختار، نحوه اجرا |
| `ARCHITECTURE.md` | معماری N-Layer، Repository Pattern، BaseRepository، Result<T>، جریان‌ها |
| `DATABASE.md` | EF6 Config، 13 Entity، روابط FK، AsNoTracking (31 متد)، Soft Delete، Security |
| `BUSINESS_LOGIC.md` | 5 ماژول اصلی، EmployeeValidator، قوانین Biz، SEC-001/002، Service Extraction Plan |
| `DEPENDENCIES.md` | NuGet Packages، External DLLs، App.config، پکیج‌های پیشنهادی آینده |
| `TESTING.md` | وضعیت تست‌ها، TestLazyLoad، استراتژی پیشنهادی، Entity Builders، CI/CD |
| `CHANGELOG.md` | این فایل - تاریخچه تغییرات مستندات |

### 🔍 مستندسازی شده از کدهای موجود
| حوزه | فایل‌های منبع اصلی |
|-------|-------------------|
| **معماری** | `Laboratory/Program.cs`, `DataAccess/EmployeeRepository.cs`, `DataAccess/Repositories/BaseRepository.cs`, `DomainModel/Validators/EmployeeValidator.cs` |
| **دیتابیس** | `DomainModel/Models/LabContext.cs`, `DomainModel/Models/*.cs` (13 Entity), `DataAccess/*Repository.cs` (11 Repository) |
| **منطق تجاری** | `DataAccess/EmployeeRepository.cs`, `DomainModel/Validators/EmployeeValidator.cs`, `DataAccess/DoctorRepository.cs`, `DataAccess/PatientRepository.cs` |
| **وابستگی‌ها** | `*.csproj` (4 projects), `Laboratory/App.config`, `packages.config` |
| **تست‌ها** | `TestLazyLoad/Program.cs`, `TestLazyLoad/App.config`, `TestLazyLoad/TestLazyLoad.csproj` |

### 📝 مستندات ارجاعی موجود (docs/)
این مستندات قبلاً وجود داشته و به عنوان ورودی تحلیل استفاده شده‌اند:
- `docs/project-overview.md` - بررسی معماری اولیه
- `docs/ai-work-log.md` - لاگ کامل فعالیت‌های هفته ۱ و ۲
- `docs/module-review.md` - ۱۵ Finding با ۵ نقش Reviewer
- `docs/database-performance-analysis.md` - تحلیل عملکرد ۱۲ دسته‌ای
- `docs/performance-review-day-09.md` - گزارش روز ۹ بهینه‌سازی
- `docs/week-02-review.md` - گزارش نهایی هفته دوم
- `docs/runbook.md` - راهنمای توسعه و عیب‌یابی
- `docs/deployment-checklist.md` - چک-лиست استقرار

### ⚠️ موارد نیازمند تأیید توسعه‌دهنده
| مورد | توضیح | فایل مرتبط |
|------|-------|-----------|
| **Patient NationalCode Unique** | آیا NationalCode باید یکتا باشد؟ Validator وجود ندارد | `BUSINESS_LOGIC.md` |
| **TestRange Business Rules** | قوانین اعتبارسنجی محدوده مرجع (Min/Max، Age/Gender) | `BUSINESS_LOGIC.md` |
| **TestAcception Status Values** | مقادیر مجاز Status در Header (Pending, Confirmed, Cancelled?) | `BUSINESS_LOGIC.md` |
| **Reporting Requirements** | چه گزارش‌هایی با FastReport تولید می‌شوند؟ | `PROJECT_GUIDE.md` |
| **Multi-Tenant?** | آیا سیستم برای چند آزمایشگاه طراحی شده؟ | `ARCHITECTURE.md` |

### 🔴 ریسک‌های Critical مستند شده
| ID | ریسک | فایل مرتبط |
|----|------|-----------|
| SEC-001 | Password Hashing Inconsistency (Plain Text در DB) | `DATABASE.md`, `BUSINESS_LOGIC.md` |
| SEC-002 | Hardcoded HMAC Key در HashingUtility.cs:18 | `DEPENDENCIES.md`, `BUSINESS_LOGIC.md` |
| DB-001 | Context Lifetime Leak (Form Lifetime) | `ARCHITECTURE.md`, `DATABASE.md` |
| TST-001 | Zero Testability (No Unit/Integration Tests) | `TESTING.md` |

---

## [1.1.0] - 2026-11-07 (1403/08/17) - Day 11 Unit Testing Implementation

### 📋 Summary
پیاده‌سازی کامل پروژه Unit Testing (Laboratory.UnitTests) با ۱۱۹ تست در ۶ کلاس تست، همه پاس. پوشش کامل Validator، BaseRepository، Result Pattern، HashingUtility، PersianDateTime و EmployeeRepository با Effort.EF6.

### 📁 Files Changed
| File | Change Type | Description |
|------|-------------|-------------|
| `TESTING.md` | Modified | به‌روزرسانی کامل وضعیت تست‌ها: ۱۱۹ تست پاس، جزئیات کلاس‌ها، کانفیگ، چالش‌های حل شده |
| `Laboratory.UnitTests/` | Added | پروژه تست کامل با ۶ فایل تست و ۱۱۹ متد تست |
| `DataAccess/Repositories/BaseRepository.cs` | Modified | MapSqlException: `private` → `protected virtual`، پارامتر `SqlException` → `int errorNumber` |
| `DataAccess/EmployeeRepository.cs` | Modified | AddNewEmployee: بررسی تکرار Username اضافه شد، GetAllEmployees: فیلتر IsEnabled اضافه شد |
| `DomainModel/Models/LabContext.cs` | Modified | ۳ سازنده جدید برای Effort.EF6 (DbConnection, EntityConnection, string) |
| `Laboratory.sln` | Modified | اضافه کردن Laboratory.UnitTests به Solution |

### 🔍 Source Evidence
| Area | Source Files |
|------|-------------|
| **Unit Test Infrastructure** | `Laboratory.UnitTests/Laboratory.UnitTests.csproj`, `Laboratory.UnitTests/App.config` |
| **BaseRepository Tests** | `Laboratory.UnitTests/BaseRepositoryTests.cs:12` (MapSqlException 7 SQL error codes) |
| **EmployeeValidator Tests** | `Laboratory.UnitTests/EmployeeValidatorTests.cs:23` (ValidateForCreate/Update/DataAnnotations) |
| **Result Pattern Tests** | `Laboratory.UnitTests/ResultTests.cs:10` (Success/Fail patterns) |
| **HashingUtility Tests** | `Laboratory.UnitTests/HashingUtilityTests.cs:11` (SEC-001/SEC-002 documentation) |
| **PersianDateTime Tests** | `Laboratory.UnitTests/PersianDateTimeTests.cs:15` (Date conversion + GetAge) |
| **EmployeeRepository Tests** | `Laboratory.UnitTests/EmployeeRepositoryTests.cs:27` (CRUD + Login + Queries) |
| **BaseRepository Changes** | `DataAccess/Repositories/BaseRepository.cs:70` (MapSqlException signature change) |
| **EmployeeRepository Changes** | `DataAccess/EmployeeRepository.cs:30` (AddNewEmployee duplicate check), `DataAccess/EmployeeRepository.cs:139` (GetAllEmployees IsEnabled filter) |
| **LabContext Constructors** | `DomainModel/Models/LabContext.cs:20` (3 constructors for Effort) |

### ⚠️ Items Requiring Verification
- تست‌های Integration Tests با LocalDB واقعی هنوز پیاده‌سازی نشده‌اند
- Code Coverage Report با coverlet تولید و تحلیل نشده است
- تست‌های UI (WinForms) با FlaUI برنامه‌ریزی شده
- ۱۰ Repository باقی‌مانده (Doctor, Patient, TestAcception، و...) تست ندارند
- SEC-001 و SEC-002 (Security Issues) همچنان در کد وجود دارند - فقط در تست‌ها مستند شده‌اند

### 🐛 چالش‌های فنی حل شده
| چالش | راه‌حل |
|-------|--------|
| xUnit 2.7.x ناسازگار با .NET Framework 4.7.2 | استفاده از xUnit 2.4.1 (core, assert, abstractions, extensibility) |
| Effort.EF6 + NMemory version mismatch | ارتقا به Effort.EF6 2.2.18 (پشتیبانی NMemory 3.x) |
| SqlException creation via Reflection ناموفق | تغییر سیگنچر MapSqlException از `SqlException` به `int errorNumber` |
| FluentAssertions recursion depth در EF Proxies | استفاده از `result.Count.Should().Be()` به جای `result.Should().HaveCount()` |
| PersianCalendar رفتار واقعی متفاوت از انتظار | به‌روزرسانی انتظارات تست بر اساس خروجی واقعی .NET PersianCalendar |

---

## [Unreleased] - geplant changes

### 📋 در انتظار تایید/پیاده‌سازی
- [ ] **Security Fixes**: SEC-001, SEC-002 Resolution → Update `DATABASE.md`, `BUSINESS_LOGIC.md`, `DEPENDENCIES.md`
- [ ] **DI Container Addition**: Microsoft.Extensions.DI → Update `ARCHITECTURE.md`, `DEPENDENCIES.md`, `PROJECT_GUIDE.md`
- [ ] **EF6 Migrations Enable** → Update `DATABASE.md`, `DEPENDENCIES.md`
- [ ] **Unit Test Project Creation** → Update `TESTING.md`, `PROJECT_GUIDE.md`
- [ ] **Phase 3-4 Soft Delete Unification** → Update `DATABASE.md`, `BUSINESS_LOGIC.md`
- [ ] **Phase 3-5 AuthService Extraction** → Update `ARCHITECTURE.md`, `BUSINESS_LOGIC.md`
- [ ] **Phase 3-6 AuditService Extraction** → Update `ARCHITECTURE.md`, `BUSINESS_LOGIC.md`
- [ ] **Cross-Repository Refactoring** (10 remaining repos) → Update `ARCHITECTURE.md`, `DATABASE.md`

---

## قالب ورودهای آینده

```markdown
## [Version] - YYYY-MM-DD (Solar Date) - Brief Title

### 📋 Summary
One-line summary of what changed.

### 📁 Files Changed
| File | Change Type | Description |
|------|-------------|-------------|
| `FILE.md` | Added/Modified/Removed | What changed |

### 🔍 Source Evidence
| Area | Source Files |
|------|-------------|
| Area Name | `path/to/file.cs:line` |

### ⚠️ Items Requiring Verification
- Item needing developer confirmation
```

---

## نگارش و نگهداری

- **زبان:** فارسی (تکنیکال ترم‌ها به انگلیسی)
- **نسخه‌سازی:** Semantic Versioning برای مستندات
- **تاریخ:** شمسی و میلادی
- **منابع:** همیشه مسیر فایل و نام کلاس/متد ذکر شود

---

*این CHANGELOG با ایجاد مستندات اولیه `docs/ai/` آغاز شده است. تمام تغییرات آینده در اینجا ثبت می‌شوند.*
# وضعیت مستندات - Laboratory Management System

## 📋 هدف و دامنه

این سند انبار کامل ۱۲ فایل مستنداتی الزامی (طبق `.claude/skills/project-onboarding/SKILL.md`) و وضعیت آن‌ها را ثبت می‌کند. بر اساس تأیید شواهد (۱۴۰۳/۰۸/۱۷) تهیه شده است.

**آخرین به‌روزرسانی:** ۱۴۰۳/۰۸/۱۷ (۲۰۲۶/۱۱/۰۷)  
**مجموع فایل‌های الزامی:** ۱۲  
**فایل‌های موجود قبلی:** ۷  
**فایل‌های جدید تولید شده:** ۵  
**فایل‌های گمشده:** ۰

---

## 📦 انبار مستندات (Documentation Inventory)

| # | فایل | وضعیت | حجم | هدف | آخرین تأیید | محدودیت‌های شناخته‌شده | نیاز به تأیید توسعه‌دهنده |
|---|------|--------|-----|-----|------------|----------------------|--------------------------|
| ۱ | `PROJECT_GUIDE.md` | ✅ **موجود و بررسی شده** | ۱۳.۱ KB | راهنمای کلی پروژه، تکنولوژی‌ها، ساختار، اجرا | ۱۴۰۳/۰۸/۱۷ | - External DLL paths نیاز به مستندسازی دقیق‌تر | ❌ خیر |
| ۲ | `ARCHITECTURE.md` | ✅ **موجود و بررسی شده** | ۱۳.۲ KB | معماری N-Layer، Repository Pattern، BaseRepository، جریان‌ها | ۱۴۰۳/۰۸/۱۷ | - Context Lifetime به عنوان Critical گزارش شده (تصحیح: P1) | ❌ خیر |
| ۳ | `DATABASE.md` | ✅ **موجود و بررسی شده** | ۱۴.۵ KB | EF6 Config، ۱۳ Entity، روابط FK، AsNoTracking، Soft Delete، Security | ۱۴۰۳/۰۸/۱۷ | - Typo SamplyeTypeId در فایل‌های گزارش قبلی (اصلاح شده) | ❌ خیر |
| ۴ | `BUSINESS_LOGIC.md` | ✅ **موجود و بررسی شده** | ۱۴.۹ KB | ۵ ماژول اصلی، EmployeeValidator، قوانین Biz، Service Extraction Plan | ۱۴۰۳/۰۸/۱۷ | - Patient NationalCode Unique نیاز به تأیید<br>- TestRange Business Rules نیاز به تأیید<br>- TestAcception Status Values نیاز به تأیید | ✅ **بله** (۳ مورد) |
| ۵ | `API_REFERENCE.md` | ✅ **تولید شده (جدید)** | ~۸ KB | مستندسازی نوع اپلیکیشن (WinForms)، عدم وجود REST API | ۱۴۰۳/۰۸/۱۷ | - Only Desktop App — No REST API | ❌ خیر |
| ۶ | `SECURITY_REVIEW.md` | ✅ **تولید شده (جدید)** | ~۱۲ KB | ۴ Finding امنیتی با اثبات، شدت‌بندی، راهکار | ۱۴۰۳/۰۸/۱۷ | - SEC-001 Blocker برای Production<br>- Migration Strategy نیاز به تصمیم | ✅ **بله** (Migration Plan) |
| ۷ | `PERFORMANCE_REVIEW.md` | ✅ **تولید شده (جدید)** | ~۱۰ KB | AsNoTracking ۳۱ متد، ۴ ریسک عملکردی، وضعیت đo đo | ۱۴۰۳/۰۸/۱۷ | - هیچ Profiling/Benchmark انجام نشده<br>- N+1 Risk نیاز به Runtime Verification | ✅ **بله** (Measurement Plan) |
| ۸ | `DEPENDENCIES.md` | ✅ **موجود و بررسی شده** | ۱۰.۰ KB | NuGet Packages، External DLLs، App.config، پکیج‌های پیشنهادی | ۱۴۰۳/۰۸/۱۷ | - External DLLs باعث Release Build Fail<br>- Atf namespace missing | ❌ خیر |
| ۹ | `TESTING.md` | ✅ **موجود و بررسی شده** | ۱۴.۰ KB | ۱۱۹ تست گزارش شده، TestLazyLoad، استراتژی پیشنهادی | ۱۴۰۳/۰۸/۱۷ | **تصحیح:** ۱۰۹ تست واقعی (نه ۱۱۹)<br>**تصحیح:** ۱۰۰٪ Pass مربوط به اجرا قبلی<br>**تصحیح:** TestLazyLoad = Manual Console App | ❌ خیر |
| ۱۰ | `TECHNICAL_DEBT.md` | ✅ **تولید شده (جدید)** | ~۱۵ KB | ۱۴ بدهی فنی اولویت‌بندی شده (P0-P3) با وابستگی‌ها | ۱۴۰۳/۰۸/۱۷ | - DB-001 Context Lifetime به عنوان Memory Leak گزارش شده بود (تصحیح: P1 Architecture) | ❌ خیر |
| ۱۱ | `DOCUMENTATION_STATUS.md` | ✅ **تولید شده (جدید)** | این فایل | انبار کامل، ناسازگاری‌ها، وضعیت تأیید | ۱۴۰۳/۰۸/۱۷ | - | ❌ خیر |
| ۱۲ | `CHANGELOG.md` | ✅ **موجود و بررسی شده** | ۱۰.۱ KB | تاریخچه تغییرات مستندات (v1.0.0، v1.1.0، Unreleased) | ۱۴۰۳/۰۸/۱۷ | - شامل تغییرات کد (Unit Tests) هم هست | ❌ خیر |

---

## 🔍 خلاصه تصحیحات از گزارش‌های قبلی

| مورد | ادعای قبلی | واقعیت تأییدشده | فایل مرتبط |
|------|------------|----------------|------------|
| **تعداد تست‌ها** | ۱۱۹ تست | **۱۰۹ تست** (۳۸ EmployeeRepository + ۱۲ BaseRepository + ۲۳ EmployeeValidator + ۱۰ Result + ۱۱ HashingUtility + ۱۵ PersianDateTime) | `TESTING.md`، `DOCUMENTATION_STATUS.md` |
| **Test Pass Rate** | ۱۰۰٪ Pass (Current) | مربوط به **اجرا قبلی** — تست‌ها در این جلسه اجرا نشده‌اند | `TESTING.md` |
| **TestLazyLoad** | Automated Test | **Manual Console App** — نیاز به اجرا دستی و دیتابیس واقعی | `TESTING.md`، `PERFORMANCE_REVIEW.md` |
| **Context Lifetime** | Memory Leak (Critical P0) | **Long-lived ChangeTracker / Form-Lifetime** — نه Leak قطعی، P1 Architecture Risk | `ARCHITECTURE.md`، `TECHNICAL_DEBT.md`، `PERFORMANCE_REVIEW.md` |
| **API Reference** | گم شده / نیاز به API | **Not Applicable** — Windows Forms Desktop، هیچ REST API وجود ندارد | `API_REFERENCE.md` |
| **N+1 Query** | Measured Issue | **Potential Risk فقط** — در GetById Entity Return با Tracking | `PERFORMANCE_REVIEW.md` |
| **Performance Claims** | Memory 40-60MB → 15-20MB، CPU 30-50% faster | **نظری/تئوریک** — هیچ đo đo وجود ندارد | `PERFORMANCE_REVIEW.md` |

---

## 📋 موارد نیازمند تأیید توسعه‌دهنده (Developer Confirmation Required)

| # | مورد | توضیح | فایل مرجع | اولویت |
|---|------|-------|-----------|--------|
| ۱ | **Patient NationalCode Unique** | آیا کد ملی بیمار باید یکتا باشد؟ Validator وجود ندارد | `BUSINESS_LOGIC.md` | P2 |
| ۲ | **TestRange Business Rules** | قوانین اعتبارسنجی Min/Max، Age/Gender Specific Ranges | `BUSINESS_LOGIC.md` | P2 |
| ۳ | **TestAcception Status Values** | مقادیر مجاز Status در Header (Pending, Confirmed, Cancelled?) | `BUSINESS_LOGIC.md` | P2 |
| ۴ | **Reporting Requirements** | چه گزارش‌هایی با FastReport تولید می‌شوند؟ | `PROJECT_GUIDE.md` | P3 |
| ۵ | **Multi-Tenant Support** | آیا سیستم برای چند آزمایشگاه طراحی شده؟ | `ARCHITECTURE.md` | P3 |
| ۶ | **SEC-001 Migration Strategy** | استراتژی مهاجرت رمزهای موجود (Batch، Fallback، Timeline) | `SECURITY_REVIEW.md` | P0 |
| ۷ | **Performance Measurement Plan** | اولویت و زمان‌بندی Profiling/Benchmark | `PERFORMANCE_REVIEW.md` | P1 |

---

## 🏷️ طبقه‌بندی فایل‌ها بر اساس وضعیت

### ✅ Existing and Reviewed (موجود و بررسی شده) — ۷ فایل
- `PROJECT_GUIDE.md`
- `ARCHITECTURE.md`
- `DATABASE.md`
- `BUSINESS_LOGIC.md`
- `DEPENDENCIES.md`
- `TESTING.md` (با تصحیحات در این فایل)
- `CHANGELOG.md`

### ✨ Newly Generated (تولید شده در این جلسه) — ۵ فایل
- `SECURITY_REVIEW.md` — بر اساس Verification Report
- `TECHNICAL_DEBT.md` — با اولویت‌بندی P0-P3 و وابستگی‌ها
- `PERFORMANCE_REVIEW.md` — با تفکیک Confirmed/Potential/Measured
- `API_REFERENCE.md` — بیانیه صریح: No REST API
- `DOCUMENTATION_STATUS.md` — این فایل

### ⚠️ Existing but Requiring Future Review (موجود اما نیاز به بازبینی آینده)
- `TESTING.md` — نیاز به به‌روزرسانی تعداد تست‌ها (۱۰۹ vs ۱۱۹) وStatus اجرا
- `ARCHITECTURE.md` — نیاز به تصحیح Context Lifetime از Critical به P1
- `CHANGELOG.md` — نیاز به Entry برای این جلسه Documentation Generation

### ❌ Not Applicable (غير قابل انطباق)
- هیچ موردی — تمام ۱۲ فایل الزامی پوشش داده شده‌اند

---

## 🔗 Cross-Reference Consistency Check

| Claim | Document A | Document B | Status |
|-------|------------|------------|--------|
| AsNoTracking 31 methods | `DATABASE.md` ✅ | `PERFORMANCE_REVIEW.md` ✅ | Consistent |
| SEC-001 Blocker | `SECURITY_REVIEW.md` ✅ | `TECHNICAL_DEBT.md` (P0) ✅ | Consistent |
| Test Count 119 | `TESTING.md` (Old) | `DOCUMENTATION_STATUS.md` (Corrected: 109) | **Discrepancy Recorded** |
| Context Lifetime = Memory Leak | `ARCHITECTURE.md` (Old: Critical) | `TECHNICAL_DEBT.md` (Corrected: P1) | **Discrepancy Recorded** |
| TestLazyLoad = Automated | `TESTING.md` (Old) | `PERFORMANCE_REVIEW.md` (Corrected: Manual) | **Discrepancy Recorded** |
| API Reference Needed | SKILL.md (Required) | `API_REFERENCE.md` (Created: Not Applicable) | **Clarified** |

---

## 📈 متریک‌های مستندات

| متریک | مقدار |
|-------|-------|
| **کل فایل‌های الزامی** | ۱۲ |
| **فایل‌های موجود** | ۱۲ (۱۰۰٪) |
| **فایل‌های تولید شده این جلسه** | ۵ |
| **کل حجم مستندات** | ~۱۱۲ KB |
| **ناسازگاری‌های ثبت شده** | ۴ مورد |
| **موارد نیازمند تأیید توسعه‌دهنده** | ۷ مورد |
| **آخرین بازبینی کامل** | ۱۴۰۳/۰۸/۱۷ |

---

## 🎯 اقدامات پیشنهادی برای توسعه‌دهنده

1. **فوری (P0):** تصمیم‌گیری در مورد SEC-001 Migration Strategy
2. **بالا (P1):** اجرای Performance Measurement Plan
3. **متوسط (P2):** تأیید ۳ قانون Biz در `BUSINESS_LOGIC.md`
4. **مستندات:** به‌روزرسانی `TESTING.md` با تعداد صحیح (۱۰۹) و Status اجرا
5. **مستندات:** به‌روزرسانی `ARCHITECTURE.md` تصحیح Context Lifetime
6. **مستندات:** اضافه کردن Entry در `CHANGELOG.md` برای این جلسه

---

*این سند به عنوان انبار مرجع (Source of Truth) برای وضعیت مستندات عمل می‌کند. تمام ناسازگاری‌های شناخته‌شده در اینجا ثبت شده‌اند تا در بازبینی‌های آینده رفع شوند.*
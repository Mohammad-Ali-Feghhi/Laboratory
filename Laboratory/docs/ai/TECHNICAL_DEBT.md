# بدهی فنی و ریسک‌های معماری - Laboratory Management System

## 📋 هدف و دامنه

این سند ثبت أولویت‌بندی شده بدهی‌های فنی و ریسک‌های معماری بر اساس تحلیل کد منبع و گزارش تأیید شواهد (۱۴۰۳/۰۸/۱۷) را مستند می‌کند.

**آخرین به‌روزرسانی:** ۱۴۰۳/۰۸/۱۷ (۲۰۲۶/۱۱/۰۷)  
**منبع:** تحلیل مستقیم سورس‌کد، گزارش‌های موجود، Verification Report

---

## 🎯 أولویت‌بندی (Priority Classification)

| اولویت | برچسب | توصیف | زمان‌بندی پیشنهادی |
|--------|--------|---------|-------------------|
| **P0** | بحرانی | Blocker برای Production / Security Critical | فوری — قبل از Deploy |
| **P1** | بالا | معماری / زیرساخت / عملکرد مهم | Sprint بعد |
| **P2** | متوسط | کیفیت کد / توسعه‌پذیری / ریسک متوسط | ۲-۳ Sprint آینده |
| **P3** | پایین | تمیزکاری / بهینه‌سازی / Nice-to-have | Backlog |

---

## 📋 ثبتی بدهی فنی (Technical Debt Register)

### P0 - بحرانی

#### DB-001: Long-lived LabContext / Form-Lifetime Context
| فیلد | مقدار |
|-------|-------|
| **اولویت** | P0 (معماری بحرانی) |
| **وضعیت فعلی** | ✅ تأیید شده — ۱۳ فرم، عمر Context = عمر Form |
| **اثبات** | `EmployeeRepository.cs:26` (ctor پیش‌فرض)، `DoctorRepository.cs:18`، `PatientRepository.cs:18`، `frmEmployee.cs:161`، `frmLogin.cs:26` و ۱۰ فرم دیگر |
| **تأثیر فنی** | • ChangeTracker طولانی‌عمر → افزایش حافظه در جلسات MDI طولانی<br>• Stale Entities: احتمالات خواندن داده‌های Cache شده (بدون Refresh)<br>• Connection Pooling: Context‌ها Dispose نمی‌شوند تا بسته شدن Form<br>• Concurrency: هر Form Context مجزا دارد — Shared Transaction ناممکن |
| **نکته مهم** | **این یک Memory Leak تأییدشده نیست**. حافظه با بسته شدن Form آزاد می‌شود. اما در اپلیکیشن‌های MDI که فرم‌ها ساعت‌ها باز می‌مانند، افزایش تدریجی حافظه (Memory Retention) رخ می‌دهد. |
| **راهکار پیشنهادی** | 1. Scoped LabContext در DI Container (Per Request / Per Unit of Work)<br>2. Repositoryهای Scoped با Constructor Injection<br>3. Formها Repository را از DI دریافت کنند، نه `new` |
| **وابستگی‌ها** | Microsoft.Extensions.DependencyInjection، DI Container Setup |
| **وضعیت تأیید** | ✅ تأیید شده |

#### SEC-001: Password Hashing Inconsistency
| فیلد | مقدار |
|-------|-------|
| **اولویت** | P0 (Security Blocker) |
| **وضعیت فعلی** | ✅ تأیید شده — Login کاملاً Broken |
| **اثبات** | `frmLogin.cs:90`، `EmployeeRepository.cs:204`، `Employee.cs:31`، `EmployeeRepository.cs:47-48,282` |
| **تأثیر فنی** | هیچ کاربری نمی‌تواند Login کند، سیستم غیرقابل استفاده در Production |
| **راهکار پیشنهادی** | IPasswordHasher + BCrypt/Argon2 + Migration Strategy |
| **وابستگی‌ها** | BCrypt.Net-Next، EF Migration برای رمزهای موجود |
| **وضعیت تأیید** | ✅ تأیید شده |

---

### P1 - بالا

#### SEC-002: Hardcoded HMAC Key
| فیلد | مقدار |
|-------|-------|
| **اولویت** | P1 |
| **وضعیت فعلی** | ✅ تأیید شده |
| **اثبات** | `HashingUtility.cs:18` |
| **تأثیر فنی** | کلید در Source Control، عدم Rotate، ریسک اگر SEC-001 رفع شود |
| **راهکار پیشنهادی** | Config/Key Vault + Rotate پس از Migration |
| **وضعیت تأیید** | ✅ تأیید شده |

#### DI: Lack of DI Container (عدم وجود DI Container)
| فیلد | مقدار |
|-------|-------|
| **اولویت** | P1 |
| **وضعیت فعلی** | ✅ تأیید شده — Manual Instantiation در ۱۳ فرم |
| **اثبات** | `frmEmployee.cs:161` `new EmployeeRepository()`، `frmLogin.cs:26` `new EmployeeRepository()`، و ۱۱ فرم دیگر |
| **تأثیر فنی** | • Scoped Lifetime غیرممکن<br>• Testability پایین (Mock مشکل)<br>• Coupling شدید Form → Concrete Repository<br>• Context Lifetime کنترل‌پذیر نیست |
| **نکته** | `EmployeeRepository` Constructor Injection دارد (خط ۱۷-۲۰) با سازنده پیش‌فرض `[Obsolete]` — DI-Ready است |
| **راهکار پیشنهادی** | Microsoft.Extensions.DependencyInjection + ServiceCollection در Program.cs + Scoped Registrations |
| **وابستگی‌ها** | NuGet: Microsoft.Extensions.DependencyInjection 8.x |
| **وضعیت تأیید** | ✅ تأیید شده |

#### UnitOfWork: Missing Shared Transaction Boundary
| فیلد | مقدار |
|-------|-------|
| **اولویت** | P1 |
| **وضعیت فعلی** | ✅ تأیید شده — هر Repository Context و SaveChanges مجزا |
| **اثبات** | `EmployeeRepository.cs:48` `_db.SaveChanges()`، `DoctorRepository.cs:41`، `PatientRepository.cs:46`، `TestAcceptionRepository` — هر کدام Context جداگانه |
| **تأثیر فنی** | • Partial Commit Risk: در پذیرش آزمایش (Header + Items)، اگر Item Fail شود Header Commit شده باقی می‌ماند<br>• Inconsistent State: تراکنش‌های منطقی چند Repository atomic نیستند<br>• Connection Overhead: چندین Context = چندین Connection |
| **نکته مهم** | **ایجاد کلاس UnitOfWork به تنهایی حل نمی‌شود**. نیاز است:<br>1. Shared LabContext (Scoped)<br>2. Repositoryها Context را Share کنند<br>3. واحد SaveChanges در پایان Unit of Work<br>4. TransactionScope یا EF Transaction |
| **راهکار پیشنهادی** | 1. Scoped LabContext در DI<br>2. IUnitOfWork Interface با SaveChanges واحد<br>3. Repositoryها LabContext را Inject کنند (نه Owner باشند)<br>4. Form/Service از UnitOfWork استفاده کند |
| **وابستگی‌ها** | DI Container (P1)، Scoped LabContext |
| **وضعیت تأیید** | ✅ تأیید شده |

#### EF6 Migrations Disabled (مهاجرات غیرفعال)
| فیلد | مقدار |
|-------|-------|
| **اولویت** | P1 |
| **وضعیت فعلی** | ✅ تأیید شده — `Enable-Migrations` اجرا نشده |
| **اثبات** | `packages.config` / `csproj` — هیچ Migration Folder وجود ندارد، `Database.SetInitializer` تنظیم نشده |
| **تأثیر فنی** | • Schema Changes نیاز به SQL دستی<br>• Unique Constraint (DB-002) قابل اعمال نیست<br>• Soft Delete Unification (DeletedAt) قابل Migration نیست<br>• Version Control Schema از دست رفته |
| **راهکار پیشنهادی** | `Enable-Migrations` در Package Manager Console → `Add-Migration InitialCreate` (Baseline) → Automatic Migrations یا Code-based |
| **وضعیت تأیید** | ✅ تأیید شده |

#### Logging Infrastructure Missing (عدم زیرساخت لاگ‌گیری)
| فیلد | مقدار |
|-------|-------|
| **اولویت** | P1 |
| **وضعیت فعلی** | ✅ تأیید شده — فقط LoginHistory Table وجود دارد |
| **اثبات** | `BaseRepository.cs:48-50` — `catch (Exception ex)` پیام عمومی برمی‌گرداند، هیچ Logging نیست<br>`EmployeeRepository.cs:236-258` `AddToLoginHistoryDatabaseError` فقط در DB می‌نویسد |
| **تأثیر فنی** | • Debugging Production خطاها دشوار<br>• Audit Trail ناقص<br>• Security Monitoring غیرممکن |
| **راهکار پیشنهادی** | Serilog 3.x + Serilog.Sinks.File + Serilog.Sinks.Console + Structured Logging در BaseRepository.MapSqlException |
| **وابستگی‌ها** | NuGet Packages |
| **وضعیت تأیید** | ✅ تأیید شده |

---

### P2 - متوسط

#### Soft Delete Inconsistency (نهامگونی حذف نرم)
| فیلد | مقدار |
|-------|-------|
| **اولویت** | P2 |
| **وضعیت فعلی** | ✅ تأیید شده — ۱۱ Repository، pattern تکراری و ناهمگون |
| **اثبات** | `EmployeeRepository.cs:148` `IsDeleted == false`، `DoctorRepository.cs:145`، `PatientRepository.cs:190` — همه تکرار `Where(x => x.IsDeleted == false)`<br>`EmployeeRepository.cs:154` `GetDeletedEmployees()` با `IsDeleted == true`<br>هیچ `WhereNotDeleted()` Extension Method یکپارچه وجود ندارد |
| **تأثیر فنی** | • Code Duplication در ۱۱ Repository<br>• Bug Risk: فراموش کردن Filter در Repository جدید<br>• Maintenance: تغییر منطق Soft Delete = ۱۱ جا تغییر |
| **راهکار پیشنهادی** | 1. `DeletedAt`، `DeletedBy` فیلدها به Entityها اضافه شود<br>2. `WhereNotDeleted()` Extension Method در BaseRepository یا QueryableExtensions<br>3. Global Query Filter (EF6: Interceptor یا BaseRepository pattern)<br>4. Migration برای Schema Changes |
| **وابستگی‌ها** | EF6 Migrations (P1) |
| **وضعیت تأیید** | ✅ تأیید شده |

#### TST-001: Incomplete Repository Test Coverage
| فیلد | مقدار |
|-------|-------|
| **اولویت** | P2 |
| **وضعیت فعلی** | ✅ تأیید شده — فقط EmployeeRepository تست Integration دارد |
| **اثبات** | `Laboratory.UnitTests/EmployeeRepositoryTests.cs` ۳۸ تست (Effort.EF6)<br>**بدون تست:** DoctorRepository، PatientRepository، TestRepository، TestAcceptionRepository، و ۶ Repository دیگر |
| **تأثیر فنی** | • Regression Risk در Refactoring Repositoryهای دیگر<br>• هیچ اطمینانی برای AsNoTracking، Soft Delete، Validation در Repositoryهای دیگر |
| **راهکار پیشنهادی** | الگوی EmployeeRepositoryTests را برای ۱۰ Repository باقی‌مانده تکرار کنید |
| **وضعیت تأیید** | ✅ تأیید شده — ۱۰۹ تست کل، فقط ۱ Repository پوشش Integration دارد |

#### Cross-Repository Implementation Inconsistency
| فیلد | مقدار |
|-------|-------|
| **اولویت** | P2 |
| **وضعیت فعلی** | ✅ تأیید شده — EmployeeRepository Refactored، ۱۰ Repository قدیمی |
| **تفاوت‌ها** | | EmployeeRepository | ۱۰ Repository دیگر |
| | --- | --- |
| **BaseRepository** | ✅ ارث‌بری | ❌ نه |
| **Constructor Injection** | ✅ دارد (با Obsolete) | ❌ فقط سازنده پیش‌فرض |
| **Validator** | ✅ Domain Validator جدا | ❌ Validation در Repository |
| **Error Handling** | ✅ Execute Pattern | ❌ Try-Catch تکراری |
| **AsNoTracking** | ✅ ۵ متد | ✅ ۳۱ متد کل (Commit 6631dfb) |
| **Method Naming** | ✅ Modern (CheckUsernameExists) | ❌ Legacy (HasExistUsername) |
| **تأثیر فنی** | Maintenance Burden، Bug Surface گسترده، Onboarding دشوار |
| **راهکار پیشنهادی** | Phase 3-4 تا 3-6: اعمال Pattern واحد به ۱۰ Repository باقی‌مانده |
| **وضعیت تأیید** | ✅ تأیید شده |

#### Missing Pagination (عدم صفحه‌بندی)
| فیلد | مقدار |
|-------|-------|
| **اولویت** | P2 |
| **وضعیت فعلی** | ✅ تأیید شده — تمام `GetAll*` و `Search*` بدون Skip/Take |
| **اثبات** | `EmployeeRepository.cs:148` `GetAllEmployees()` → `.ToList()`<br>`DoctorRepository.cs:144` `GetAllDoctors()` → `.ToList()`<br>`PatientRepository.cs:189` `GetAllPatients()` → `.ToList()` |
| **تأثیر فنی** | • Over-fetching در جداول بزرگ<br>• Memory Pressure در Client<br>• UI Freeze در DataBind حجم بالا |
| **راهکار پیشنهادی** | `GetAll(int page, int pageSize)` با `.Skip().Take()` در تمام Repositoryها |
| **وضعیت تأیید** | ✅ تأیید شده |

---

### P3 - پایین

#### Potential N+1 Queries (ریسک بالقوه N+1)
| فیلد | مقدار |
|-------|-------|
| **اولویت** | P3 (قربله/نظری) |
| **وضعیت فعلی** | ⚠️ بالقوه — Navigation Properties بدون Include/Projection در GetById |
| **اثبات** | `DoctorRepository.cs:94` `GetDoctorByDoctorId` → Entity برمی‌گرداند، `doctor.TestAcceptionHeader` در UI/Code ممکن است Lazy Load کند<br>`PatientRepository.cs:114` `GetPatientByPatientId` مشابه |
| **تأثیر فنی** | در صورت دسترسی به Navigation Property: Lazy Load → کوئری اضافی_per_entity |
| **نکته** | **هیچ đo đo N+1 واقعی وجود ندارد** — AsNoTracking روی GetAll‌ها Lazy Load را غیرفعال می‌کند. ریسک فقط در GetById Entity Return هست. |
| **راهکار پیشنهادی** | 1. Projection/DTO در GetById متدهای پرکاربرد<br>2. یا `.Include()` صریح در متد<br>3. مستند کردن Contract: "Entity Return = No Lazy Load Expected" |
| **وضعیت تأیید** | ⚠️ بالقوه — نیاز به Runtime Verification |

#### Entity Over-fetching (بازگرداندن Entity کامل به جای DTO)
| فیلد | مقدار |
|-------|-------|
| **اولویت** | P3 |
| **وضعیت فعلی** | ✅ تأیید شده — ۱۰+ متد Entity کامل برمی‌گردانند |
| **اثبات** | `GetAllDoctors()`، `GetAllEmployees()`، `GetAllPatients()`، `GetAllTestAcceptionItems()` — Entity با همه Columns و Navigation Properties |
| **تأثیر فنی** | • Network Payload زیاد<br>• Memory Usage بالا<br>• Lazy Load Risk (اگر Tracking فعال باشد) |
| **راهکار پیشنهادی** | Projection به DTO/ViewModel (مانند `SearchDoctor`، `SearchPatient` که `DoctorSearchListItem` برمی‌گردانند) |
| **وضعیت تأیید** | ✅ تأیید شده |

---

## 📊 خلاصه اولویت‌بندی

| اولویت | تعداد | موارد |
|--------|-------|-------|
| **P0** | ۲ | DB-001 (Context Lifetime)، SEC-001 (Password Hashing) |
| **P1** | ۵ | SEC-002، DI Container، UnitOfWork، EF Migrations، Logging |
| **P2** | ۵ | Soft Delete، Test Coverage، Cross-Repo Consistency، Pagination، (10 Repo Refactor) |
| **P3** | ۲ | N+1 Risk، Over-fetching |
| **مجموع** | **۱۴** | |

---

## 🔗 وابستگی‌های بین بدهی‌ها

```
SEC-001 (P0)
    ↓ نیاز به Migration
EF6 Migrations (P1) ←.enable()
    ↓
Soft Delete Unification (P2)

DI Container (P1)
    ↓ enables
Scoped LabContext → DB-001 Fix (P0)
    ↓ enables
UnitOfWork Pattern (P1)
    ↓ enables
Cross-Repo Refactor (P2)
    ↓ enables
Pagination + N+1 Fix (P2/P3)
```

---

*این سند بر اساس تحلیل کد منبع و گزارش تأیید شواهد تهیه شده. اولویت‌ها بر اساس تأثیر بر Production، Security، و Maintainability تعیین شده‌اند.*
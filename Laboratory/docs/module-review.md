# Module Review: EmployeeRepository / IEmployeeRepository

## 1. Module Information

| مورد | جزئیات |
|------|--------|
| **نام ماژول** | EmployeeRepository / IEmployeeRepository |
| **نوع** | Data Access Layer — Repository Pattern |
| **فایل‌های اصلی** | `DataAccess/EmployeeRepository.cs` (370 lines, 31 methods)<br>`DataAccess/Services/IEmployeeRepository.cs` (32 lines, 31 method signatures) |
| **فایل‌های وابسته** | `DomainModel/Models/Employee.cs`<br>`DomainModel/Models/LoginHistory.cs`<br>`DomainModel/Results/Result.cs`<br>`DomainModel/Results/ErrorCode.cs`<br>`Framework/HashingUtility.cs` |
| **Consumerها** | `Laboratory/Forms/frmLogin.cs`<br>`Laboratory/Forms/Employees/frmEmployee.cs`<br>`Laboratory/Forms/Employees/frmBasicEmployeeInfo.cs`<br>`Laboratory/Forms/Employees/frmInactiveEmployee.cs`<br>`Laboratory/Forms/Patients/frmPatients.cs`<br>`Laboratory/frmMainBoard.cs` |
| **تاریخ بررسی** | 2026-11-02 |
| **Reviewer** | Senior .NET Code Reviewer |
| **محدوده** | Implementation کامل ۳۱ متد، Error Handling، Security، Database، Testability، Code Quality |

---

## 2. Current Status

### خلاصه وضعیت کد
- **Pattern:** Repository Pattern با Interface تعریف‌شده (`IEmployeeRepository`)
- **ORM:** Entity Framework 6.5.2 با `LabContext` (Database First / Code First Hybrid)
- **Error Handling:** `Result<T>` Pattern با `ErrorCode` Enum (5 codes: None, UserNotFound, InvalidPassword, DatabaseError, ValidationError)
- **Security:** HMACSHA256 با کلید Hardcoded در `Framework.HashingUtility`
- **DI:** **بدون DI Container** — `new LabContext()` در Constructor، Concrete Dependency
- **Testing:** **Zero Unit Testability** — همه وابستگی‌ها Concrete، Static Coupling
- **Code Duplication:** بالا — Validation Logic و Error Handling Pattern در تمام متدها تکرار شده

### آمار کد
| متریک | مقدار |
|--------|-------|
| تعداد متدها | ۳۱ |
| خطوط Implementation | ~۳۷۰ |
| تعداد `try-catch` بلوک‌ها | ۳۱ (هر متد یک) |
| متدهای بیش از ۳۰ خط | ۴ (AddNewEmployee, UpdateEmployee, Login, ChangePassword) |
| وابستگی مستقیم به `LabContext` | بله (Constructor) |
| وابستگی مستقیم به `HashingUtility` | بله (در frmLogin، نه در Repository) |

---

## 3. Findings

### جدول تمام یافته‌ها

| ID | حوزه | اولویت | اطمینان | فایل/کلاس | متد/محل | شرح مختصر |
|----|-------|--------|---------|-----------|---------|-----------|
| **SEC-001** | Security | 🔴 Critical | ۱۰۰٪ | `EmployeeRepository.cs`<br>`frmLogin.cs`<br>`HashingUtility.cs` | `AddNewEmployee`<br>`ChangePassword`<br>`Login` | **Password Handling Inconsistency:** UI هش می‌کند، DB Plain ذخیره می‌کند، Login هش شده را با Plain مقایسه می‌کند → سیستم لاگین کار نمی‌کند |
| **SEC-002** | Security | 🔴 بالا | ۱۰۰٪ | `Framework/HashingUtility.cs` | خط ۱۸ | **Hardcoded HMAC Key:** کلید ۳۲ بایت در سورس‌کد، در Git History، بدون Rotation |
| **ERR-001** | Error Handling | 🔴 بالا | ۱۰۰٪ | `EmployeeRepository.cs` | تمام ۳۱ متد | **Catch-all Exception + Info Disclosure:** `catch(Exception ex) { return Fail(DatabaseError, ex.Message); }` — جزئیات SQL به UI لو می‌رود، هیچ Logging، هیچ Retry |
| **DUP-002** | Duplication | 🔴 بالا | ۱۰۰٪ | `EmployeeRepository.cs` | تمام ۳۱ متد | **Error Handling Pattern تکرار:** ۳۱ بار identical try-catch + Result.Fail |
| **DB-001** | Database | 🔴 بالا | ۹۰٪ | `EmployeeRepository.cs` | Constructor + Dispose | **Context Lifetime / Connection Leak:** Context در Constructor ساخته می‌شود، فرم‌ها Dispose نمی‌کنند → Pool Exhaustion، Memory Leak |
| **TST-001** | Testability | 🔴 بالا | ۱۰۰٪ | `EmployeeRepository.cs` | Constructor + تمام متدها | **Zero Mockability:** `new LabContext()`، Static `HashingUtility`، بدون Constructor Injection |
| **DB-002** | Database | 🟡 متوسط | ۸۵٪ | `EmployeeRepository.cs` | `HasExistUsername`<br>`AddNewEmployee` | **Unnecessary Queries / Race Condition:** چک وجود Username در متد جداگانه، Race Condition بین چک و Insert |
| **QUA-001** | Quality | 🟡 متوسط | ۹۵٪ | `EmployeeRepository.cs` | `AddNewEmployee`<br>`UpdateEmployee`<br>`ChangePassword` | **Validation در Data Access Layer:** Business Ruleها در Repository — SRP Violation، UI Coupling (پیام‌های فارسی) |
| **DB-003** | Database | 🟡 متوسط | ۱۰۰٪ | `EmployeeRepository.cs` | `GetAllEmployees`<br>`GetAllInactiveEmployees`<br>`GetAllDeletedEmployees`<br>`SearchEmployee`<br>`GetAllLoginHistories` | **Missing AsNoTracking:** تمام Read-Only Queries بدون `.AsNoTracking()` → Change Tracker Overhead |
| **ERR-002** | Error Handling | 🟡 متوسط | ۸۵٪ | `EmployeeRepository.cs` | `AddToLoginHistoryDatabaseError` | **Silent Failure در Logging:** خود متد لاگ‌نویسی هم try-catch دارد، اگر Fail کند خطا گم می‌شود |
| **DB-004** | Database | 🟡 متوسط | ۹۰٪ | `EmployeeRepository.cs` | `ValidateLoginAttempt` | **Race Condition:** Read-Modify-Write بدون Concurrency Token / RowVersion |
| **QUA-004** | Quality | 🟡 متوسط | ۹۰٪ | `EmployeeRepository.cs` | `DeleteEmployee`<br>`EnableEmployee`<br>`GetAllDeletedEmployees` | **Soft Delete Pattern Inconsistent:** `IsDeleted`، `IsEnabled`، `IsUpdated` — تداخل معنا |
| **DUP-001** | Duplication | 🟡 متوسط | ۹۵٪ | `EmployeeRepository.cs` | `AddNewEmployee`<br>`UpdateEmployee` | **Validation Logic تکرار:** ۶ اعتبارسنجی identical در دو متد CRUD |
| **QUA-002** | Quality | 🟢 پایین | ۹۰٪ | `EmployeeRepository.cs` | `AddNewEmployee` (49 lines)<br>`UpdateEmployee` (53 lines) | **Long Methods / High Complexity:** Cyclomatic Complexity ~7-8، چندین Return Path |
| **QUA-003** | Quality | 🟢 پایین | ۱۰۰٪ | `DomainModel/Models/Test.cs` | Property `SamplyeTypeId` | **Typo:** `SamplyeTypeId` به جای `SampleTypeId` (در Fluent API هم تکرار) |

---

## 4. Recommended Improvements

### برای هر مشکل راهکار پیشنهادی

| ID | راهکار پیشنهادی (Technical) |
|----|------------------------------|
| **SEC-001** | ۱) تصمیم استراتژیک: Hash در Repository (Service Layer) **یا** در UI — یکی انتخاب شود<br>۲) اگر در Repository: `IPasswordHasher` Interface + Constructor Injection<br>۳) Migration: رمزهای موجود در DB را هش کنید (BCrypt/Argon2 ترجیح داده می‌شود به HMAC)<br>۴) `Login` باید قبل از مقایسه هش کند (اگر DB Hashed است) |
| **SEC-002** | ۱) Key از Config/Environment Variable/Key Vault خوانده شود<br>۲) Environment-specific Keys (Dev/Staging/Prod جدا)<br>۳) Key Rotation Strategy تعریف شود |
| **ERR-001** | ۱) Logging Framework اضافه شود (Serilog پیشنهادی)<br>۲) Catch تفکیک: `SqlException` → check `Number` → Deadlock (1205) Retry / Timeout (-2) / FK Violation (547)<br>۳) Message به UI: Generic ("خطای دیتابیس رخ داد")، Detail در Log با Correlation ID |
| **DUP-002** | ۱) Base Repository Class یا Helper: `ExecuteWithErrorHandling<T>(Func<Result<T>> action)`<br>۲) تمام متدها delegate می‌شوند به این Helper<br>۳) Logging، Retry، Mapping Exception در یکجا متمرکز شود |
| **DB-001** | ۱) **Short-lived Context:** `using (var db = new LabContext())` در هر متد Repository<br>۲) یا DI Container (Microsoft.Extensions.DI) با Scoped Lifetime<br>۳) فرم‌ها باید `using` یا `try/finally Dispose` داشته باشند |
| **TST-001** | ۱) Constructor Injection: `public EmployeeRepository(LabContext db, IPasswordHasher hasher)`<br>۲) `LabContext` با Virtual DbSetها برای Mock (Effort / InMemory Provider)<br>۳) Interface برای Hashing: `IPasswordHasher` |
| **DB-002** | ۱) Unique Constraint در دیتابیس + Catch `DbUpdateException` → Map به `ValidationError`<br>۲) یا `Any()` در همان متد قبل از Add (Atomic Operation)<br>۳) `GetEmployeeByUsername` نتیجه را در Scope Operation Cache کند |
| **QUA-001** | ۱) Validation به Domain Entity (DataAnnotations / FluentValidation) یا Service Layer منتقل شود<br>۲) Repository فقط Data Access انجام دهد<br>۳) پیام‌های خطا از Repository جدا شوند (Resource File / Localization) |
| **DB-003** | ۱) اضافه کردن `.AsNoTracking()` در تمام Read-Only Queries<br>۲) Extension Method: `db.Employee.AsNoTracking().Where(...)` |
| **ERR-002** | ۱) Fire-and-Forget Logging (Background Queue / Hangfire / Channel)<br>۲) Fallback به EventLog / File در صورت فشل دیتابیس<br>۳) Circuit Breaker برای Logging Service |
| **DB-004** | ۱) `RowVersion` / `Timestamp` Property در Employee Entity<br>۲) یا Stored Procedure Atomic برای ValidateLoginAttempt<br>۳) Optimistic Concurrency با EF6 Configuration |
| **QUA-004** | ۱) Unified Soft Delete: یک فیلد `IsDeleted` + `DeletedAt` + `DeletedBy`<br>۲) `IsEnabled` فقط برای Active/Inactive Business State<br>۳) Queryها با Extension Method `WhereNotDeleted()` متمرکز شود |
| **DUP-001** | ۱) Extract Method: `ValidateEmployee(Employee emp, bool isUpdate)`<br>۲) در `AddNewEmployee` و `UpdateEmployee` فراخوانی شود<br>۳) قوانین Validation در یکجا متمرکز شود |
| **QUA-002** | ۱) Extract Methods: `ValidateInput()`, `MapToEntity()`, `SaveAndReturnResult()`<br>۲) هر متد حداکثر ۱۵-۲۰ خط، Single Responsibility |
| **QUA-003** | ۱) Rename Property به `SampleTypeId` در Entity<br>۲) Update Fluent API در `LabContext.OnModelCreating`<br>۳) EF Migration برای رینیم Column در دیتابیس |

---

## 5. Action Plan

### برنامه اصلاح بر اساس اولویت (Phased Approach)

#### Phase 0: Critical Security Fixes (قبل از هر چیز)
| Task | ID | Effort | Dependency |
|------|-----|--------|------------|
| Fix Password Hashing Inconsistency | SEC-001 | High | Hashing Strategy Decision |
| Remove Hardcoded HMAC Key | SEC-002 | Low | Config/Key Vault Setup |

#### Phase 1: Error Handling & Reliability Foundation
| Task | ID | Effort | Dependency |
|------|-----|--------|------------|
| Centralized Error Handling Helper | ERR-001, DUP-002 | Medium | Logging Framework Selection |
| Add Serilog + Structured Logging | ERR-001 | Medium | NuGet + Config |
| Fix Context Lifetime (Short-lived) | DB-001 | Medium | Test Impact Analysis |

#### Phase 2: Testability Enablement
| Task | ID | Effort | Dependency |
|------|-----|--------|------------|
| Constructor Injection for LabContext | TST-001 | Medium | DI Container Setup |
| IPasswordHasher Interface + Injection | TST-001, SEC-001 | Low | Phase 0 |
| Virtual DbSet for Mocking | TST-001 | Low | Entity Changes |

#### Phase 3: Database & Performance Optimizations
| Task | ID | Effort | Dependency |
|------|-----|--------|------------|
| Add AsNoTracking to Read Queries | DB-003 | Low | None |
| Fix Race Conditions (Username, LoginAttempt) | DB-002, DB-004 | Medium | DB Schema Changes |
| Add RowVersion for Concurrency | DB-004 | Medium | Migration |

#### Phase 4: Code Quality & Maintainability
| Task | ID | Effort | Dependency |
|------|-----|--------|------------|
| Extract Validation Logic | DUP-001, QUA-001 | Low | Phase 1 |
| Unify Soft Delete Pattern | QUA-004 | Medium | DB Migration |
| Reduce Method Complexity | QUA-002 | Low | Phase 3 |
| Fix Typo (SamplyeTypeId) | QUA-003 | Low | Migration |

---

### پیش‌نیازهای Cross-Cutting
| پیش‌نیاز | توضیح |
|-----------|-------|
| **DI Container** | Microsoft.Extensions.DI — برای Constructor Injection در Repositoryها و Forms |
| **Logging Framework** | Serilog + File/Seq Sink — برای ERR-001، ERR-002 |
| **Testing Framework** | xUnit/NUnit + Moq + Effort (EF6 InMemory) — برای TST-001 |
| **Migration Strategy** | EF6 Migrations Enable + Seed Data — برای Schema Changes |

---

## 6. Additional Investigation

### موارد نیازمند تأیید/تست برای تصمیم‌گیری نهایی

| مورد | دلیل | نحوه تأیید |
|------|------|-----------|
| **وضعیت واقعی Login در Development** | SEC-001 نشان می‌دهد Login کار نمی‌کند، اما پروژه اجرا می‌شود | تست دستی: اجرا → Login با کاربر موجود → بررسی موفقیت/موفقیت |
| **محتویات جدول Employee در دیتابیس** | آیا رمزها Hashed یا Plain هستند؟ | `SELECT Username, Password FROM Employee` در SSMS |
| **Connection Pool Behavior تحت Load** | DB-001 تئوریک است، نیاز به Load Test | Load Test: ۵۰ کاربر همزمان، مانیتور Pool Usage |
| **FastReport Dependency** | آیا واقعاً استفاده می‌شود؟ حذف شود؟ | جستجوی `FastReport` در کد UI، بررسی گزارش‌ها |
| **External DLLها (DateTimeSelector, FarsiLibrary)** | در Repository نیستند اما Build Dependency هستند | بررسی لایسنس، جایگزینی با NuGet Package |
| **EF6 Migration Status** | آیا Migrations فعال است؟ | Package Manager Console: `Get-Migrations` |
| **Seed Data Strategy** | حداقل ۱ Admin User برای Login | بررسی `Configuration.Seed` یا Script SQL |
| **Concurrency Token در Entityهای دیگر** | DB-004 فقط Employee است، سایر Entityها؟ | بررسی تمام Entityها برای `RowVersion` / `Timestamp` |

---

## 📌 Decision Points (نقاط تصمیم‌گیری برای شما)

1. **Hashing Strategy:** Repository vs UI؟ (تأثیر مستقیم بر SEC-001، TST-001، Architecture)
2. **DI Container Adoption:** الان انجام شود یا تدریجی؟ (تأثیر بر TST-001، DB-001، تمام Repositoryها)
3. **Logging Framework:** Serilog / NLog / log4net؟ (تأثیر بر ERR-001، ERR-002)
4. **Testing Framework:** xUnit / NUnit / MSTest؟ (تأثیر بر TST-001)
5. **EF6 Migration Enable:** الان انجام شود؟ (پیش‌نیاز برای QUA-003، QUA-004، DB-004)

---

**این سند مبنای تصمیم‌گیری برای Refactoring در روزهای بعد است.**  
**تاریخ:** 2026-11-02  
**وضعیت:** تحلیل کامل، بدون تغییر کد
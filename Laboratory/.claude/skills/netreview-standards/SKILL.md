---
name: netreview-standards
description: |
  Specialized C#/.NET code review skill for Laboratory Management System.
  Enforces project-specific standards for architecture, EF6 patterns, security,
  error handling, performance, and testability. Use when reviewing PRs, refactoring,
  or auditing code quality in this WinForms + EF6 + Repository Pattern codebase.
---

# netreview-standards — C#/.NET Code Review Skill

## 🎯 When to Activate
- Code review requests (PR, diff, or file review)
- Refactoring planning and validation
- Architecture compliance checks
- Security audits
- Performance optimization reviews
- Testability assessments

---

## 📋 Project Context (Laboratory Management System)

| Aspect | Detail |
|--------|--------|
| **Runtime** | .NET Framework 4.7.2 |
| **ORM** | Entity Framework 6.5.2 (NOT EF Core) |
| **UI** | Windows Forms (WinForms, MDI) |
| **Database** | SQL Server (LocalDB/Express/Full) |
| **Architecture** | 4-Layer N-Layer: Presentation → DataAccess → DomainModel ← Framework |
| **Pattern** | Repository Pattern (11 repos) + Result<T> + ErrorCode |
| **DI** | **None** — Manual `new` instantiation (Service Locator) |
| **Logging** | **None** — Only `LoginHistory` table |
| **Config** | Single `App.config` (no multi-env) |
| **External DLLs** | DateTimeSelector, FarsiLibrary (relative paths) |

---

## ✅ Standards Extracted from Project Documentation

### 1. Architecture & Layering Rules

**A. Dependency Direction (MUST)**
```
Laboratory (Presentation) → DataAccess → DomainModel
                              ↘ Framework
```
- DomainModel MUST have ZERO references to other projects
- Framework MUST have ZERO references to other projects
- DataAccess references ONLY DomainModel
- Laboratory references ALL three

**B. Repository Pattern (MUST)**
- Each entity has `I<Entity>Repository` interface + concrete implementation
- All repositories return `Result<T>` for unified error handling
- Repository methods: CRUD + Search + Business Validation
- Interface defined in `DataAccess/Services/`

**C. Unit of Work / Context Lifetime (CURRENT STATE - NEEDS FIX)**
- ❌ CURRENT: Context created in Repository constructor, lives for form lifetime
- ✅ REQUIRED: Short-lived Context per operation OR Scoped via DI Container
- ❌ CURRENT: Only `DoctorRepository` implements `Dispose()`
- ✅ REQUIRED: All repositories implement `IDisposable` OR use DI Scoped lifetime

### 2. C#/.NET Coding Standards

**A. Naming Conventions (from Refactoring Phase 3)**
| Pattern | Rule | Example |
|---------|------|---------|
| **Methods** | Action verbs, PascalCase | `CheckUsernameExists`, `ActivateEmployee` |
| **No Redundant Prefixes** | Remove `GetAll` when obvious | `GetInactiveEmployees` not `GetAllInactiveEmployees` |
| **Parameters** | Descriptive, camelCase | `searchTerm` not `phrase` |
| **Domain Classes** | PascalCase, noun | `EmployeeValidator`, `ValidateForCreate` |
| **Interfaces** | `I` prefix + PascalCase | `IEmployeeRepository` |
| **Private Fields** | `_camelCase` | `_db`, `_repo` |
| **Constants** | `PascalCase` | `MaxRetryCount` |

**B. Code Structure**
- Max method length: **20 lines** (current violations: 30-50 lines)
- Cyclomatic Complexity: **< 5** per method
- Single Responsibility: Each method does ONE thing
- Extract validation, mapping, saving into separate methods

**C. C# Version Constraints (.NET Framework 4.7.2)**
- ❌ NO nullable reference types (`?`, `!`)
- ❌ NO default interface methods
- ❌ NO `record` types
- ❌ NO `init` accessors
- ❌ NO pattern matching enhancements (C# 8+)
- ✅ USE: `async/await`, LINQ, generics, extension methods

### 3. Entity Framework 6 Standards

**A. Query Patterns (from Performance Analysis)**

| Rule | Requirement | Current Compliance |
|------|-------------|-------------------|
| **AsNoTracking** | ALL read-only queries MUST use `.AsNoTracking()` | 10% (5/51 methods) |
| **Projection** | Prefer `Select` to DTO over full Entity return | 14% (7/51 methods) |
| **Include/ThenInclude** | Use for eager loading when navigation accessed | 0% (never used) |
| **Pagination** | `Skip`/`Take` on ALL `GetAll*` methods | 0% (none) |
| **Async** | Use `ToListAsync`, `FirstOrDefaultAsync`, `AnyAsync` | 0% (all sync) |
| **FirstOrDefault** | Correct for PK + filter lookups | ✅ 100% |
| **Any()** | Use for existence checks | ✅ 100% |

**B. Context Configuration (from LabContext)**
- Cascade Delete: **ALL false** (explicit in Fluent API)
- Foreign Keys: **Explicit** via `HasForeignKey`
- Table Mapping: Explicit `ToTable` where needed
- ❌ MISSING: Explicit Indexes on FK columns
- ❌ MISSING: `RowVersion`/`Timestamp` for concurrency

**C. SaveChanges & Transactions**
- Batch `AddRange`/`RemoveRange` for multiple entities
- Single `SaveChanges()` per logical operation
- Use `TransactionScope` or `DbContextTransaction` for multi-entity atomicity
- ❌ CURRENT: SaveChanges per entity (except 1 case in TestAcception)

**D. Connection Resiliency**
- Add `DbExecutionStrategy` for transient fault handling
- Configure in `LabContext` constructor

### 4. Security Standards (from Module Review & Deployment Checklist)

| ID | Rule | Status |
|----|------|--------|
| **SEC-001** | **Password Hashing:** NEVER store plain text. Use BCrypt/Argon2 via `IPasswordHasher`. Hash at Service/Repository layer, NOT UI. | ❌ Violation |
| **SEC-002** | **No Hardcoded Secrets:** Keys in Config/Key Vault/Env Vars. Rotation strategy required. | ❌ Violation (HashingUtility.cs:18) |
| **SEC-003** | **Connection String Encryption:** Encrypt `connectionStrings` section in production (`aspnet_regiis -pef`) | ❌ Not done |
| **SEC-004** | **Exception Sanitization:** NEVER expose SQL/stack trace to UI. Generic message + Correlation ID in log. | ❌ Violation (31 methods) |
| **SEC-005** | **SQL Injection:** LINQ/EF parameterized queries are safe. Raw SQL MUST use parameters. | ✅ Compliant |
| **SEC-006** | **ClickOnce Signing:** Code signing certificate for production manifests. | ⚠️ Not verified |

### 5. Error Handling Standards (from Module Review & Refactoring)

**A. Result<T> Pattern (MUST)**
```csharp
// Success
return Result<T>.Success(data);
// Failure with ErrorCode
return Result<T>.Fail(ErrorCode.ValidationError, "User-friendly message");
// Failure with exception (internal only)
return Result<T>.Fail(ErrorCode.DatabaseError, "Generic message");
```

**B. Centralized Error Handling (from Phase 3-2 Refactor)**
- Base class `BaseRepository` with `Execute<T>(Func<Result<T>>)` and `Execute(Action)`
- `MapSqlException<T>()` maps SQL error codes:
  - `2627`, `2601` → Unique Constraint → `ValidationError`
  - `547` → FK Violation → `ValidationError`
  - `1205` → Deadlock → Retry logic
  - `-2` → Timeout → Retry/extend
  - `823`, `824` → I/O Error → Infrastructure alert

**C. Logging (REQUIRED - Not Implemented)**
- Add Serilog (recommended) or NLog
- Structured logging with Correlation ID
- Log: SQL errors, validation failures, security events, performance metrics
- NEVER log passwords, connection strings, HMAC keys

### 6. Dependency Injection & Testability (from Module Review & Runbook)

**A. Current State: ❌ NO DI Container**
- All repositories instantiated via `new Repository()`
- Forms hold repositories as fields (long lifetime)
- `LabContext` created in repository constructor

**B. Required: DI Container Setup**
```csharp
// Program.cs - Composition Root
var services = new ServiceCollection();
services.AddScoped<LabContext>();
services.AddScoped<IDoctorRepository, DoctorRepository>();
// ... all 11 repositories
services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
services.AddSingleton<ILogger>(sp => new LoggerConfiguration()...CreateLogger());
var provider = services.BuildServiceProvider();
```

**C. Constructor Injection (MUST for Testability)**
```csharp
// GOOD - Testable
public EmployeeRepository(LabContext db, IPasswordHasher hasher) { ... }

// BAD - Not testable (current)
public EmployeeRepository() { _db = new LabContext(); }
```

**D. Mocking Support**
- `LabContext` needs `virtual DbSet<T>` for Effort/InMemory provider
- `IPasswordHasher` interface for hash abstraction
- All external dependencies behind interfaces

### 7. Performance Anti-Patterns to Flag (from Database Performance Analysis)

| Anti-Pattern | Detection | Fix |
|--------------|-----------|-----|
| **Long-lived Context** | `new LabContext()` in ctor, held as field | Scoped DI / using block |
| **Missing AsNoTracking** | Read query without `.AsNoTracking()` | Add before ToList/FirstOrDefault |
| **N+1 Query** | Loop accessing navigation property | `Include()` or projection |
| **Full Entity Return** | `GetAll*` returns `List<Entity>` | Project to DTO (`Select`) |
| **No Pagination** | Unbounded `GetAll*` | Add `skip`/`take` params |
| **Sync Only** | `.ToList()`, `.FirstOrDefault()` | `.ToListAsync()`, `.FirstOrDefaultAsync()` |
| **Duplicate Query** | Same query executed twice | Cache result / combine |
| **SaveChanges per Entity** | Multiple `SaveChanges()` in loop | `AddRange` + single `SaveChanges` |
| **Missing Indexes** | FK columns queried without index | Add explicit Index in Fluent API |

### 8. Duplication & Complexity Rules

**A. Validation Duplication (DUP-001)**
- ❌ NEVER duplicate validation logic between Add/Update
- ✅ Extract to Domain Validator (`EmployeeValidator.ValidateForCreate/Update`)
- ✅ Use DataAnnotations on Entity where possible
- ✅ FluentValidation for complex rules

**B. Error Handling Duplication (DUP-002)**
- ❌ NEVER repeat `try-catch` + `Result.Fail` pattern
- ✅ Use `BaseRepository.Execute()` pattern

**C. Soft Delete Consistency (QUA-004)**
- ✅ Single pattern: `IsDeleted` + `DeletedAt` + `DeletedBy`
- ✅ Extension method `WhereNotDeleted()`
- ❌ Current: Mix of `IsDeleted`, `IsEnabled`, `IsUpdated`

### 9. Testability Checklist

| Requirement | Verification |
|-------------|--------------|
| Repository has constructor injection | `public Repo(LabContext db, ...)` |
| All dependencies are interfaces | `IPasswordHasher`, `IEmailService`, etc. |
| `LabContext` has virtual DbSets | `public virtual DbSet<Doctor> Doctor { get; set; }` |
| No static dependencies | No `HashingUtility`, `DateTime.Now`, `ConfigurationManager` |
| Methods return `Result<T>` | Testable assertions on `IsSuccess`, `Data`, `ErrorCode` |
| No UI coupling in Repository | No Persian messages, no `MessageBox` |

---

## 🔍 Review Process

### Step 1: Quick Scan (30 seconds)
- [ ] File in correct layer/project?
- [ ] Naming conventions followed?
- [ ] No obvious security violations (hardcoded secrets, plain passwords)?
- [ ] Method length < 20 lines?

### Step 2: Architecture Compliance (2 min)
- [ ] Dependency direction correct?
- [ ] Repository implements interface?
- [ ] Result<T> pattern used?
- [ ] No UI references in DataAccess/DomainModel?

### Step 3: EF6 Patterns (3 min)
- [ ] AsNoTracking on read queries?
- [ ] Projection used where appropriate?
- [ ] Include for eager loading?
- [ ] Pagination on GetAll?
- [ ] Async methods used?
- [ ] SaveChanges batched?

### Step 4: Error Handling (2 min)
- [ ] BaseRepository.Execute pattern?
- [ ] SQL exception mapping?
- [ ] No raw exception messages to UI?
- [ ] Logging present (when framework added)?

### Step 5: Security (2 min)
- [ ] No hardcoded keys/secrets?
- [ ] Passwords hashed (BCrypt/Argon2)?
- [ ] Connection string encryption (prod)?
- [ ] Input validation (LINQ safe)?

### Step 6: Testability (1 min)
- [ ] Constructor injection?
- [ ] Virtual DbSets?
- [ ] Interfaces for external deps?
- [ ] No static coupling?

### Step 7: Performance (2 min)
- [ ] No N+1 patterns?
- [ ] No duplicate queries?
- [ ] Indexes on FK columns?
- [ ] No over-fetching?

---

## 📊 Finding Classification

| Severity | Label | Response Time | Examples |
|----------|-------|---------------|----------|
| **Critical** | 🔴 Critical | Immediate (block deploy) | SEC-001, SEC-002, Plain passwords, Hardcoded keys, SQL injection |
| **High** | 🔴 High | Before merge | Missing AsNoTracking (read), Context leak, No DI, Raw exceptions to UI |
| **Medium** | 🟡 Medium | Next sprint | N+1 risk, No pagination, Duplication, Soft delete inconsistency, No indexes |
| **Low** | 🟢 Low | Tech debt backlog | Naming inconsistency, Missing async, Long methods, Missing projection |

---

## 🇮🇷 Persian Report Template

When reporting findings, use this Persian format:

```markdown
## نتیجه‌گیری بازبینی کد - [Module/File Name]

### خلاصه
- **فایل‌ها بررسی شده:** N
- **یافته‌های Critical:** N
- **یافته‌های High:** N
- **یافته‌های Medium:** N
- **یافته‌های Low:** N

### جزئیات یافته‌ها

| شناسه | شدت | فایل | متد/خط | شرح مشکل | پیشنهاد اصلاح |
|-------|------|------|--------|----------|--------------|
| CR-001 | 🔴 Critical | EmployeeRepository.cs | Line 45 | رمزعبور Plain Text ذخیره می‌شود | پیاده‌سازی IPasswordHasher با BCrypt |

### توصیه‌های اولویت‌بندی شده
1. **فوری:** [Critical items]
2. **قبل از مرج:** [High items]
3. **اسپرینت بعدی:** [Medium items]
4. **بکلاگ تکنیکال:** [Low items]
```

---

## 🚫 What NOT To Do

- ❌ **Never modify files** during review — report findings only
- ❌ **Never change business logic** — only flag violations
- ❌ **Never commit/push/merge** — user approval required
- ❌ **Never expose secrets** in reports — redact keys, passwords, connection strings
- ❌ **Never assume EF Core patterns** — this is EF 6.5.2
- ❌ **Never suggest C# 8+ features** — .NET Framework 4.7.2 constraint

---

## 🔧 Activation Keywords

This skill auto-activates when user says:
- "code review", "review code", "code audit"
- "refactor", "refactoring"
- "security audit", "security review"
- "performance review", "optimize queries"
- "testability", "unit test"
- "architecture review"
- "PR review", "pull request review"

---

## 📚 Reference Documents (Project-Specific)

| Document | Path | Purpose |
|----------|------|---------|
| Project Overview | `docs/project-overview.md` | Architecture, tech stack, layer responsibilities |
| Module Review | `docs/module-review.md` | 15 findings on EmployeeRepository with priorities |
| Performance Analysis | `docs/database-performance-analysis.md` | 12-category EF6 performance analysis |
| Runbook | `docs/runbook.md` | Dev setup, troubleshooting, common errors |
| Deployment Checklist | `docs/deployment-checklist.md` | Production deploy gates, security, config |
| AI Work Log | `docs/ai-work-log.md` | Completed refactoring phases, pending tasks |
| Week 2 Review | `docs/week-02-review.md` | Performance optimization summary |

---

*Skill Version: 1.0 | Project: Laboratory Management System | Created: 2026-11-04*
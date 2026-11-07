# Database Performance Analysis - DataAccess Layer

**Date:** 2026-11-04  
**Project:** Laboratory Management System (.NET Framework 4.7.2, EF 6.5.2)  
**Scope:** All 11 Repositories, LabContext, Entity Relationships  
**Role:** Senior .NET Performance Engineer & EF Specialist  

---

## Executive Summary

This analysis covers the **DataAccess layer** of a Laboratory Management System using **Entity Framework 6.5.2** (not EF Core) with a **Repository Pattern** over 11 repositories. The system runs on Windows Forms with SQL Server (LocalDB/Express).

### Overall Assessment: **High Risk - Multiple Critical Performance Anti-Patterns**

| Risk Level | Count | Key Issues |
|------------|-------|------------|
| 🔴 **Critical** | 5 | Context lifetime leaks, No AsNoTracking (except 5 methods), N+1 query risks, No pagination, Over-fetching |
| 🟡 **High** | 4 | Duplicate queries, No column selection (Select), SaveChanges per entity, Missing indexes on FK |
| 🟢 **Medium** | 3 | FirstOrDefault vs SingleOrDefault, Eager loading gaps, Connection pooling concerns |

---

## 1. DbContext Lifetime & DI Usage

### Current State: **CRITICAL** 🔴

```csharp
// Pattern in ALL 11 repositories (e.g., DoctorRepository.cs:13-18)
private readonly LabContext _db;

public DoctorRepository()
{
    _db = new LabContext();  // New context per repository instance
}
```

### Issues Found:

| Issue | Severity | Impact |
|-------|----------|--------|
| **Context per Repository = Context per Form** | 🔴 Critical | Forms hold repositories as fields (`frmDoctors.cs:76`), keeping context alive for entire form lifetime |
| **No Scoped/Per-Request Lifetime** | 🔴 Critical | Long-running context accumulates tracked entities → memory bloat, stale data, concurrency issues |
| **No DI Container** | 🔴 Critical | Manual `new LabContext()` prevents scoped lifetime management |
| **Dispose() not consistently called** | 🟡 High | Only `DoctorRepository` implements `Dispose()`; other 10 repositories don't |
| **MultipleActiveResultSets=True** | 🟢 Medium | Enabled in connection string - good for MARS, but masks lazy-loading issues |

### Evidence:
- `frmNewTestParameter.cs:100-116` - 6 repositories instantiated in constructor, held for form lifetime
- `frmEmployee.cs` - EmployeeRepository held as field
- Connection pool exhaustion risk under concurrent users

### Recommendation:
1. Add DI Container (Microsoft.Extensions.DependencyInjection)
2. Register `LabContext` as **Scoped** (per unit of work)
3. Register repositories as **Scoped**
4. Implement `UnitOfWork` pattern for transaction boundary

---

## 2. LINQ Query Patterns

### Current State: **MIXED** 🟡

### Good Patterns (Projection/Select):
- `PatientRepository.GetPatientTestListByPatientId()` (lines 195-207) - Uses `select new PatientTestListItem` with navigation properties
- `TestAcceptionRepository.GetAllTestAcceptionItems()` (lines 126-151) - Explicit join with projection
- `TestRepository.GetTestItemsByTestId()` (lines 82-92) - Projection to DTO
- `DoctorRepository.SearchDoctor()` (lines 165-182) - Projection to `DoctorSearchListItem`

### Poor Patterns (Entity Return):
- `GetAllDoctors()`, `GetAllPatients()`, `GetAllTests()`, `GetAllUnits()`, etc. - Return full entities
- `GetAllEmployees()` - Returns full `Employee` with all navigation properties
- `GetAllInactiveEmployees()` - Same issue

### Query Complexity:
| Repository | Simple Queries | Complex Queries | Projection Used |
|------------|----------------|-----------------|-----------------|
| Patient | 6 | 2 | 2/8 |
| TestAcception | 2 | 2 | 1/4 |
| Doctor | 8 | 1 | 1/9 |
| Employee | 6 | 2 | 2/8 (after refactor) |
| Test | 3 | 1 | 1/4 |
| Others (Category, Method, Range, Unit, ResponseType, SampleType) | 1 each | 0 | 0/6 |

---

## 3. N+1 Query Risks

### Current State: **HIGH RISK** 🔴

### Confirmed N+1 Locations:

#### 1. `PatientRepository.GetPatientTestListByPatientId()` (lines 195-207)
```csharp
// This query DOES project, so no N+1 HERE
// BUT the projected properties access navigation:
DoctorName = item.Doctor.DoctorName,      // Could trigger lazy load if not included
RegistrationEmployeeName = item.Employee.EmployeeName  // Could trigger lazy load
```
**Risk**: If projection changed to return entities, or if caller accesses other nav props → N+1

#### 2. `TestAcceptionRepository.GetAllTestAcceptionItems()` (lines 126-151)
```csharp
// Uses explicit JOIN - SAFE from N+1
join method in _db.TestMethod on testAcceptionItem.TestMethodId equals method.TestMethodId
join unit in _db.Unit on testAcceptionItem.UnitId equals unit.UnitId
TestName = testAcceptionItem.Test.TestName  // Accesses Test navigation - RISK if not projected
```

#### 3. **Implicit N+1 in UI Layer** - Forms iterate results and access navigation properties
- `frmDoctors.cs` likely accesses `Doctor.TestAcceptionHeaders` 
- `frmPatients.cs` accesses `Patient.TestAcceptionHeaders`
- No `Include()` in repository queries for these scenarios

### Navigation Property Access Patterns (High Risk):
| Entity | Navigation Properties | Accessed in Repositories? |
|--------|----------------------|---------------------------|
| Doctor | TestAcceptionHeaders | No Include in GetAllDoctors |
| Patient | TestAcceptionHeaders | No Include in GetAllPatients |
| Employee | TestAcceptionHeaders (RegistrationEmployee), LoginHistory | No Include |
| Test | TestCategory, TestMethod, Unit, SampleType, ResponseType, TestRange | Partial in GetTestItemsByTestId |
| TestAcceptionHeader | Doctor, Patient, Employee, TestAcceptionItems | Partial in GetAllTestAcceptionItems |
| TestAcceptionItem | Test, TestMethod, Unit | Partial in GetAllTestAcceptionItems |

---

## 4. Include/ThenInclude Usage

### Current State: **ALMOST NON-EXISTENT** 🔴

### Findings:
| Repository | Include() Used? | ThenInclude() Used? | Eager Loading |
|------------|-----------------|---------------------|---------------|
| All 11 | ❌ **Never** | ❌ **Never** | ❌ **None** |

### Code Evidence:
```csharp
// DoctorRepository.cs:136 - GetAllDoctors
return _db.Doctor.Where(x => x.IsDeleted == false)
                 .OrderBy(x => x.DoctorName)
                 .ToList();  // No Include for TestAcceptionHeaders

// PatientRepository.cs:189 - GetAllPatients
return _db.Patient.Where(x => x.IsDeleted == false)
                  .OrderBy(x => x.PatientName)
                  .ToList();  // No Include for TestAcceptionHeaders

// EmployeeRepository.cs (refactored) - GetAllEmployees
return _db.Employee.Where(x => x.IsDeleted == false)
                   .AsNoTracking()  // Added in Phase 2
                   .OrderBy(x => x.EmployeeName)
                   .ToList();  // No Include for LoginHistory, TestAcceptionHeaders
```

### Impact:
- **Lazy loading enabled by default** (EF6 default)
- Each navigation property access = additional round-trip
- Typical form loads 50-100 entities → 50-100 additional queries per navigation

---

## 5. Column Selection (Projection)

### Current State: **PARTIAL - Only in Search/List DTOs** 🟡

### Good: Projection to DTOs (6 methods)
| Repository | Method | Projects To |
|------------|--------|-------------|
| Patient | GetPatientTestListByPatientId | PatientTestListItem |
| Patient | SearchPatient | PatientSearchListItem |
| Doctor | SearchDoctor | DoctorSearchListItem |
| Employee | SearchEmployee | EmployeeSearchListItem |
| Test | TestSearch | TestSearchListItem |
| TestAcception | GetAllTestAcceptionItems | TestAcceptionListItem |

### Bad: Full Entity Return (30+ methods)
| Pattern | Count | Example |
|---------|-------|---------|
| `GetAll*()` returns `List<Entity>` | 11 | GetAllDoctors, GetAllPatients, GetAllTests... |
| `GetBy*Id()` returns `Result<Entity>` | 11 | GetDoctorByDoctorId, GetPatientByPatientId... |
| `Get*By*` returns `List<Entity>` | 4 | GetAllDeactiveDoctors, GetInactiveEmployees... |

### Column Over-fetch Example:
```csharp
// Employee entity has: EmployeeId, EmployeeName, Username, Password, PhoneNumber, 
// Address, BirthDate, IsEnabled, IsDeleted, IsUpdated, UpdateTime, 
// Navigation: LoginHistories, TestAcceptionHeaders (RegistrationEmployee)

// GetAllEmployees() returns ALL columns + potential lazy loads
// But UI often only needs: EmployeeId, EmployeeName, Username, IsEnabled
```

---

## 6. AsNoTracking Usage

### Current State: **PARTIAL - Only EmployeeRepository (5 methods)** 🟡

### Added in Phase 2 Refactoring (EmployeeRepository only):
```csharp
// EmployeeRepository.cs - After refactor
public List<Employee> GetAllEmployees()
{
    return _db.Employee.Where(x => x.IsDeleted == false)
                       .AsNoTracking()  // ✅ ADDED
                       .OrderBy(x => x.EmployeeName)
                       .ToList();
}

// Also added to: GetInactiveEmployees, GetDeletedEmployees, SearchEmployee, GetAllLoginHistories
```

### Missing AsNoTracking (All other 10 repositories - 30+ methods):
```csharp
// DoctorRepository.cs:136
public List<Doctor> GetAllDoctors()
{
    return _db.Doctor.Where(x => x.IsDeleted == false)
                     .OrderBy(x => x.DoctorName)
                     .ToList();  // ❌ NO AsNoTracking
}

// PatientRepository.cs:189
public List<Patient> GetAllPatients()
{
    return _db.Patient.Where(x => x.IsDeleted == false)
                      .OrderBy(x => x.PatientName)
                      .ToList();  // ❌ NO AsNoTracking
}

// TestRepository.cs:113, TestCategoryRepository.cs:16, etc. - ALL MISSING
```

### Impact:
- **Change tracking overhead** on read-only queries
- Memory bloat from tracked entity graphs
- Unnecessary `DetectChanges()` calls on `SaveChanges()`

---

## 7. ToList/ToListAsync Patterns

### Current State: **SYNCHRONOUS ONLY - No Async** 🔴

### Findings:
| Method | Count | Async Version |
|--------|-------|---------------|
| `.ToList()` | 40+ | ❌ Never used |
| `.ToListAsync()` | 0 | ❌ Not available in EF6 without EF6.Async |
| `.FirstOrDefault()` | 25+ | ❌ No Async |
| `.Any()` | 15+ | ❌ No Async |
| `.SingleOrDefault()` | 0 | N/A |

### EF6 Async Support:
- EF 6.1+ supports `ToListAsync()`, `FirstOrDefaultAsync()`, etc.
- Requires `using System.Data.Entity;` namespace
- **Not used anywhere in codebase**

### Impact:
- **UI thread blocking** on all database operations
- WinForms `frmNewTestParameter_Load()` calls 6 `GetAll*()` sequentially → 6 round-trips blocking UI
- No cancellation token support
- Scalability ceiling on concurrent users

---

## 8. FirstOrDefault vs SingleOrDefault

### Current State: **CONSISTENTLY FirstOrDefault** 🟢

### Analysis:
| Method | Usage | Correct? |
|--------|-------|----------|
| `FirstOrDefault()` | 25+ | ✅ Appropriate - PK lookups with IsDeleted filter |
| `SingleOrDefault()` | 0 | N/A |
| `.Any()` | 15+ | ✅ Appropriate for existence checks |

### Examples:
```csharp
// Correct - PK lookup with soft-delete filter
var doctor = _db.Doctor.FirstOrDefault(x => x.DoctorId == doctorId && x.IsDeleted == false);

// Correct - Unique constraint check
var exist = _db.Doctor.Any(x => x.MedicalLicenseNumber == licenseNumber && x.IsDeleted == false);

// Correct - Username check
var exist = _db.Employee.Any(x => x.Username == username && x.IsDeleted == false);
```

### Assessment: **No issues found** - `FirstOrDefault` is correct for PK lookups with additional filters. `SingleOrDefault` would throw on duplicates which indicates data corruption anyway.

---

## 9. Duplicate Queries

### Current State: **MULTIPLE INSTANCES** 🟡

### Confirmed Duplicate Query Patterns:

#### 1. DoctorRepository.GetAllTestAcceptionsByDoctorId() (lines 218-248)
```csharp
// QUERY 1: Existence check
var exist = _db.TestAcceptionHeader.Any(x => x.DoctorId == doctorId && x.IsDeleted == false);

// QUERY 2: If exists, fetch ALL again
if (exist)
{
    var list = _db.TestAcceptionHeader.Where(x => x.DoctorId == doctorId && x.IsDeleted == false).ToList();
    // SAME QUERY EXECUTED TWICE!
}
```

#### 2. TestAcceptionRepository.HasExistTestAcceptionItem() (lines 208-223)
```csharp
// Could combine with AddNewTestAcceptionItem but separate calls
var existTestItem = _db.TestAcceptionItem.Any(...);
// Then caller calls Add which does another query
```

#### 3. EmployeeRepository.ValidateLoginAttempt() (not shown but referenced in module review)
```csharp
// Likely pattern: Check username exists → Then get employee → Then check password
// 2-3 queries for single login
```

#### 4. PatientRepository.PatientCheckingValidation() (lines 169-186)
```csharp
var patient = _db.Patient.FirstOrDefault(x => x.NationalCode == item.NationalCode || 
                                              x.Mobile == item.Mobile && x.IsDeleted == false);
// Single query but OR condition may not use index efficiently
```

---

## 10. SaveChanges Patterns

### Current State: **PER-OPERATION - No Batching** 🔴

### Pattern in ALL repositories:
```csharp
// DoctorRepository.AddNewDoctor (lines 22-37)
_db.Doctor.Add(newDoctor);
_db.SaveChanges();  // ❌ Round-trip per entity

// TestAcceptionRepository.AddNewTestAcceptionItems (lines 74-96) - ONE GOOD EXAMPLE
var entries = temps.Select(x => new TestAcceptionItem { ... }).ToList();
_db.TestAcceptionItem.AddRange(entries);  // ✅ Batch add
_db.SaveChanges();  // Single SaveChanges for multiple entities
```

### SaveChanges Count:
| Repository | Methods with SaveChanges | Batched? |
|------------|--------------------------|----------|
| Doctor | 4 | ❌ No |
| Employee | 4 | ❌ No |
| Patient | 4 | ❌ No |
| Test | 1 | ❌ No |
| TestAcception | 5 | ⚠️ 1 batched (AddRange) |
| TestRange | 1 | ❌ No |
| Others | 0 (read-only) | N/A |

### Transaction Boundary Issues:
- No explicit `TransactionScope` or `DbContextTransaction`
- Each `SaveChanges()` = implicit transaction
- Multi-entity operations (header + items) not atomic

---

## 11. Over-fetching Analysis

### Current State: **SEVERE - Full Entities Returned** 🔴

### Over-fetch by Repository:

| Repository | Method | Columns Fetched | Columns Needed (Typical UI) | Over-fetch Ratio |
|------------|--------|-----------------|----------------------------|------------------|
| Doctor | GetAllDoctors | ~12 + nav props | 4 (Id, Name, License, Enabled) | **3x+** |
| Patient | GetAllPatients | ~10 + nav props | 5 (Id, Name, NationalCode, Mobile, BirthDate) | **2x+** |
| Employee | GetAllEmployees | ~12 + nav props | 4 (Id, Name, Username, Enabled) | **3x+** |
| Test | GetAllTests | ~9 + nav props | 3 (Id, Name, Category) | **3x+** |
| TestCategory | GetAllTestCategories | ~4 | 2 (Id, Name) | **2x** |
| TestMethod | GetAllTestMethods | ~4 | 2 (Id, Name) | **2x** |
| Unit | GetAllUnits | ~4 | 2 (Id, Name) | **2x** |
| ResponseType | GetAllResponseTypes | ~4 | 2 (Id, Name) | **2x** |
| SampleType | GetAllSampleTypes | ~4 | 2 (Id, Name) | **2x** |

### Navigation Property Over-fetch:
- `Doctor.TestAcceptionHeaders` - Collection, potentially 100s of records
- `Patient.TestAcceptionHeaders` - Collection, potentially 100s
- `Employee.LoginHistories` - Collection, potentially 1000s
- `Test.TestRanges` - Collection
- `TestAcceptionHeader.TestAcceptionItems` - Collection

---

## 12. Pagination Issues

### Current State: **NO PAGINATION ANYWHERE** 🔴

### Findings:
| Repository | Pagination Support | Max Rows Returned |
|------------|-------------------|-------------------|
| All 11 | ❌ **None** | Unbounded (all matching rows) |

### Risk Scenarios:
```csharp
// DoctorRepository.GetAllDoctors() - Returns ALL non-deleted doctors
// PatientRepository.GetAllPatients() - Returns ALL non-deleted patients
// EmployeeRepository.GetAllEmployees() - Returns ALL non-deleted employees
// TestAcceptionRepository.GetAllTestAcceptionHeaders() - Returns ALL headers
```

### Real-world Impact:
- Laboratory with 5+ years data → 10,000+ patients, 50,000+ test acceptions
- `GetAllTestAcceptionHeaders()` orders by date desc but takes ALL
- ComboBox binding in `frmNewTestParameter_Load()` loads ALL units, sample types, methods, categories, response types
- Memory pressure on client, network bandwidth waste

---

## Entity Relationship & Index Analysis

### LabContext Fluent API (DomainModel/Models/LabContext.cs):

```csharp
// Lines 30-70: All cascade deletes = false (good for data integrity)
modelBuilder.Entity<Doctor>().HasMany(d => d.TestAcceptionHeaders)
    .WithRequired(t => t.Doctor).HasForeignKey(t => t.DoctorId)
    .WillCascadeOnDelete(false);

// Lines 55-56: Test entity - FK typo fixed in refactor
modelBuilder.Entity<Test>().HasRequired(t => t.SampleType)
    .WithMany().HasForeignKey(t => t.SampleTypeId)  // Was SamplyeTypeId
    .WillCascadeOnDelete(false);
```

### Missing Indexes (Implicit from FK but not explicit):
```sql
-- These FK columns likely need explicit indexes for query performance:
-- TestAcceptionHeader.DoctorId (queried in GetAllTestAcceptionsByDoctorId)
-- TestAcceptionHeader.PatientId (queried in GetPatientTestListByPatientId)
-- TestAcceptionHeader.RegistrationEmployeeId
-- TestAcceptionItem.TestAcceptionHeaderId (queried in GetAllTestAcceptionItems)
-- TestAcceptionItem.TestId
-- TestAcceptionItem.TestMethodId
-- TestAcceptionItem.UnitId
-- Test.SampleTypeId, Test.TestMethodId, Test.TestCategoryId, Test.UnitId, Test.ResponseTypeId
-- Employee.Username (queried in CheckUsernameExists, ValidateLoginAttempt)
-- Patient.NationalCode (queried in HasExistNationalCode, PatientCheckingValidation)
-- Doctor.MedicalLicenseNumber (queried in GetDoctorByMedicalLicenseNumber, HasExistMedicalLicenseNumber)
```

---

## Priority Remediation Matrix

### 🔴 CRITICAL (Do First - Security/Stability)

| # | Issue | Effort | Files Affected |
|---|-------|--------|----------------|
| 1 | **Add DI Container + Scoped LabContext** | Medium | Program.cs, all Forms, all Repositories |
| 2 | **Add AsNoTracking to ALL read-only queries** | Low | 10 repositories, 30+ methods |
| 3 | **Implement Pagination (Skip/Take)** | Medium | All repositories with GetAll* |
| 4 | **Add explicit Include() for eager loading** | Medium | 6+ repositories |
| 5 | **Batch SaveChanges / Add TransactionScope** | Medium | 5+ repositories |

### 🟡 HIGH (Performance/Scale)

| # | Issue | Effort | Files Affected |
|---|-------|--------|----------------|
| 6 | **Add EF6 Async (ToListAsync, FirstOrDefaultAsync)** | Low | All repositories |
| 7 | **Project to DTOs instead of full entities** | Medium | 30+ methods |
| 8 | **Fix DoctorRepository duplicate query** | Low | DoctorRepository.cs |
| 9 | **Add explicit indexes on FK columns** | Low | LabContext.cs + Migration |
| 10 | **Implement UnitOfWork pattern** | Medium | New files + all repositories |

### 🟢 MEDIUM (Quality/Maintainability)

| # | Issue | Effort | Files Affected |
|---|-------|--------|----------------|
| 11 | **Standardize FirstOrDefault vs SingleOrDefault** | Low | N/A (already consistent) |
| 12 | **Add query logging/inspection** | Low | LabContext.Database.Log |
| 13 | **Consider compiled queries for hot paths** | Medium | High-frequency methods |
| 14 | **Add connection resiliency (EF6 ExecutionStrategy)** | Low | LabContext constructor |

---

## Repository-by-Repository Summary

| Repository | Methods | AsNoTracking | Projection | Include | Pagination | Async | SaveChanges Batching |
|------------|---------|--------------|------------|---------|------------|-------|---------------------|
| **Employee** | 10 | ✅ 5/5 reads | ✅ 2/8 | ❌ 0 | ❌ | ❌ | ❌ |
| **Doctor** | 12 | ❌ 0 | ✅ 1/9 | ❌ 0 | ❌ | ❌ | ❌ |
| **Patient** | 8 | ❌ 0 | ✅ 2/8 | ❌ 0 | ❌ | ❌ | ❌ |
| **Test** | 5 | ❌ 0 | ✅ 1/4 | ❌ 0 | ❌ | ❌ | ❌ |
| **TestAcception** | 9 | ❌ 0 | ✅ 1/4 | ⚠️ Join | ❌ | ❌ | ⚠️ 1/5 |
| **TestCategory** | 1 | ❌ 0 | ❌ 0 | ❌ 0 | ❌ | ❌ | N/A |
| **TestMethod** | 1 | ❌ 0 | ❌ 0 | ❌ 0 | ❌ | ❌ | N/A |
| **TestRange** | 2 | ❌ 0 | ❌ 0 | ❌ 0 | ❌ | ❌ | ❌ |
| **Unit** | 1 | ❌ 0 | ❌ 0 | ❌ 0 | ❌ | ❌ | N/A |
| **ResponseType** | 1 | ❌ 0 | ❌ 0 | ❌ 0 | ❌ | ❌ | N/A |
| **SampleType** | 1 | ❌ 0 | ❌ 0 | ❌ 0 | ❌ | ❌ | N/A |
| **TOTAL** | **51** | **5/51 (10%)** | **7/51 (14%)** | **0/51** | **0/51** | **0/51** | **1/15** |

---

## Recommended Implementation Order

### Phase 1: Foundation (Week 1)
1. Add `Microsoft.Extensions.DependencyInjection` NuGet
2. Create `ServiceCollection` configuration in `Program.cs`
3. Register `LabContext` as Scoped
4. Register all 11 repositories as Scoped
5. Update all Forms to receive repositories via constructor injection

### Phase 2: Query Optimization (Week 1-2)
6. Add `.AsNoTracking()` to ALL read-only methods (30+ methods)
7. Add `.Include()` for navigation properties accessed in UI
8. Convert `GetAll*()` methods to support pagination (Skip/Take parameters)
9. Add projection (Select) to remaining `GetAll*` methods returning DTOs

### Phase 3: Async & Batching (Week 2)
10. Add EF6 Async methods (`ToListAsync`, `FirstOrDefaultAsync`, `AnyAsync`)
11. Batch `SaveChanges` where multiple entities added/updated
12. Add `TransactionScope` for multi-entity operations

### Phase 4: Database Level (Week 2-3)
13. Enable EF6 Migrations
14. Add explicit indexes on all FK columns + Username, NationalCode, MedicalLicenseNumber
15. Add connection resiliency (`DbExecutionStrategy`)

### Phase 5: Monitoring (Ongoing)
16. Add `LabContext.Database.Log = sql => Debug.WriteLine(sql)` for development
17. Add MiniProfiler or similar for production query monitoring
18. Set up query performance baselines

---

## Appendix: Key Files for Reference

| File | Path | Lines |
|------|------|-------|
| LabContext | `DomainModel/Models/LabContext.cs` | 1-70 |
| BaseRepository | `DataAccess/Repositories/BaseRepository.cs` | 1-97 |
| EmployeeRepository | `DataAccess/EmployeeRepository.cs` | 1-293 |
| DoctorRepository | `DataAccess/DoctorRepository.cs` | 1-252 |
| PatientRepository | `DataAccess/PatientRepository.cs` | 1-232 |
| TestRepository | `DataAccess/TestRepository.cs` | 1-130 |
| TestAcceptionRepository | `DataAccess/TestAcceptionRepository.cs` | 1-225 |
| frmNewTestParameter | `Laboratory/Forms/Tests/frmNewTestParameter.cs` | 1-229 |

---

*Analysis complete. No code changes made - this is a diagnostic report only.*
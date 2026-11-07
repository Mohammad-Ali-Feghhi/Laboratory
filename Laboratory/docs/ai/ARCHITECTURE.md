# معماری سیستم - Laboratory Management System

## 🏛 معماری مشاهده‌شده

این پروژه یک معماری **N-Layer (۴ لایه)** با الگوی **Repository Pattern** پیاده‌سازی شده است. لایه‌ها به‌صورت سخت‌گیرانه جدا شده‌اند و Dependency Direction تنها به سمت پایین (از Presentation به Domain) است.

---

## 📐 دیاگرام معماری

```
┌─────────────────────────────────────────────────────────────────────┐
│                    PRESENTATION LAYER                               │
│  ┌─────────────────────────────────────────────────────────────┐   │
│  │  Laboratory (WinForms .exe)                                  │   │
│  │  • frmLogin → frmMainBoard (MDI)                            │   │
│  │  • Forms: Doctors, Employees, Patients, Tests               │   │
│  │  • QuickAccess Panel, Persian DateTime                      │   │
│  └──────────────────────────┬──────────────────────────────────┘   │
└─────────────────────────────┼──────────────────────────────────────┘
                              │ References
                              ▼
┌─────────────────────────────────────────────────────────────────────┐
│                    DATA ACCESS LAYER                                │
│  ┌─────────────────────────────────────────────────────────────┐   │
│  │  DataAccess (Library)                                        │   │
│  │  • 11 Repository Classes                                     │   │
│  │  • 11 Service Interfaces                                     │   │
│  │  • BaseRepository (Error Handling Pattern)  ← NEW            │   │
│  │  • Result<T> Pattern Consumer                                │   │
│  └──────────────────────────┬──────────────────────────────────┘   │
└─────────────────────────────┼──────────────────────────────────────┘
                              │ References
                              ▼
┌─────────────────────────────────────────────────────────────────────┐
│                      DOMAIN LAYER                                   │
│  ┌─────────────────────────────────────────────────────────────┐   │
│  │  DomainModel (Library) - INDEPENDENT                         │   │
│  │  • 13 Entities (Models/)                                     │   │
│  │  • LabContext (EF6 DbContext + Fluent API)                   │   │
│  │  • 10 DTOs/ViewModels (BussinessModel/)                      │   │
│  │  • Result<T> & ErrorCode (Results/)                          │   │
│  │  • EmployeeValidator (Validators/)  ← NEW                    │   │
│  └─────────────────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────────────────┐
│                  INFRASTRUCTURE LAYER                               │
│  ┌─────────────────────────────────────────────────────────────┐   │
│  │  Framework (Library) - INDEPENDENT                           │   │
│  │  • HashingUtility (HMACSHA256)                               │   │
│  │  • PersianDateTime (Solar Hijri)                             │   │
│  │  • UIHelper (WinForms Helpers)                               │   │
│  └─────────────────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────────────────┘
```

---

## 🏗 مسئولیت لایه‌ها

| لایه | پروژه | مسئولیت اصلی | وابستگی‌ها |
|-------|-------|--------------|-----------|
| **Presentation** | Laboratory | UI، ناوبری MDI، رویدادهای کاربر، نمایش داده‌ها | DataAccess, DomainModel, Framework |
| **Data Access** | DataAccess | CRUD، کوئری‌ها، تراکنش‌ها، مدیریت خطای دیتابیس | DomainModel |
| **Domain** | DomainModel | موجودیت‌ها، DTOها، Context، قوانین اعتبارسنجی، Result Pattern | (بدون وابستگی) |
| **Infrastructure** | Framework | توابع کمکی: Hashing، تاریخ شمسی، UI Helpers | (بدون وابستگی) |

---

## 🔄 الگوهای معماری

### 1. Repository Pattern
```csharp
// Interface در DataAccess/Services/
public interface IEmployeeRepository
{
    Result<Employee> AddNewEmployee(Employee emp);
    Result<Employee> UpdateEmployee(Employee newEmp);
    Employee GetEmployeeByEmployeeId(int employeeId);
    List<Employee> GetAllEmployees();
    // ...
}

// Implementation در DataAccess/
public class EmployeeRepository : BaseRepository, IEmployeeRepository  // ← NEW: BaseRepository
{
    private readonly LabContext _db;
    public EmployeeRepository(LabContext db) { _db = db; }  // ← Constructor Injection
    
    [Obsolete("Use EmployeeRepository(LabContext db)")]
    public EmployeeRepository() : this(new LabContext()) { }
}
```

### 2. Result<T> Pattern (DomainModel/Results/Result.cs)
```csharp
public class Result<T>
{
    public bool IsSuccess { get; private set; }
    public ErrorCode ErrorCode { get; private set; }
    public string Message { get; private set; }
    public T Data { get; private set; }

    public static Result<T> Success(T data) => new Result<T>(true, ErrorCode.None, "", data);
    public static Result<T> Fail(ErrorCode errorCode, string message) => new Result<T>(false, errorCode, message, default);
}
```

### 3. BaseRepository Pattern (NEW - DataAccess/Repositories/BaseRepository.cs)
```csharp
public abstract class BaseRepository
{
    protected Result<T> Execute<T>(Func<Result<T>> action)
    {
        try { return action(); }
        catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx)
        { return MapSqlException<T>(sqlEx); }
        // ... سایر catch blocks
    }

    private Result<T> MapSqlException<T>(SqlException sqlEx)
    {
        switch (sqlEx.Number)
        {
            case 2627: case 2601: return Result<T>.Fail(ErrorCode.ValidationError, "اطلاعات تکراری است");
            case 547: return Result<T>.Fail(ErrorCode.ValidationError, "عملیات نامعتبر است");
            case 1205: return Result<T>.Fail(ErrorCode.DatabaseError, "تداخل در دسترسی");
            // ...
        }
    }
}
```

### 4. Domain Layer Validation (NEW - DomainModel/Validators/EmployeeValidator.cs)
```csharp
public static class EmployeeValidator
{
    public static Result<Employee> ValidateForCreate(Employee emp)
    {
        var common = ValidateCommonFields(emp);
        if (!common.IsSuccess) return common;
        if (string.IsNullOrWhiteSpace(emp.Password))
            return Result<Employee>.Fail(ErrorCode.ValidationError, "رمز عبور الزامی است!");
        return Result<Employee>.Success(default);
    }
    
    public static Result<Employee> ValidateForUpdate(Employee emp) 
        => ValidateCommonFields(emp);  // Password در Update الزامی نیست
}
```

---

## 🎯 نکات معماری مهم

### ✅ نقاط قوت
| مورد | توضیح |
|------|-------|
| **جداسازی لایه‌ها** | DomainModel کاملاً مستقل است |
| **Repository Pattern** | انتزاع داده با Interfaceها |
| **Result<T> Pattern** | مدیریت خطای یکپارچه بدون Exception در UI |
| **BaseRepository** | مدیریت متمرکز خطا و نگاشت کدهای SQL |
| **Domain Validation** | قوانینBiz در Domain Layer (EmployeeValidator) |
| **DI-Ready** | Constructor Injection در EmployeeRepository |

### ⚠️ ریسک‌های معماری
| ریسک | اولویت | توضیح |
|-------|--------|-------|
| **Context Lifetime** | 🔴 Critical | `LabContext` با عمر Form زنده می‌ماند (Memory Leak، Stale Data) |
| **No DI Container** | 🔴 High | Manual `new Repository()`،Scoped Lifetime ممکن نیست |
| **No UnitOfWork** | 🟡 Medium | تراکنش‌های متعدد Repository مدیریت نمی‌شوند |
| **Mixed Patterns** | 🟡 Medium | ۱ Repository (Employee) ریفکتور شده، ۱۰ Repository قدیمی |
| **Static Validator** | 🟢 Low | `EmployeeValidator` استاتیک - اگر نیاز به DI داشته باشد محدودیت دارد |

---

## 🔗 جریان‌های اجرای مهم

### 1. ورود کاربر (Login Flow)
```
frmLogin.btnLogin_Click
    → EmployeeRepository.Login(username, password)
        → BaseRepository.Execute()
            → _db.Employee.FirstOrDefault(x => x.Username == username)
            → مقایسه Plain Text Password  ← SEC-001
        → Result<Employee> با User Data
    → frmMainBoard.Show() (MDI Parent)
```

### 2. افزودن کارمند جدید
```
frmEmployee.btnAdd_Click
    → EmployeeRepository.AddNewEmployee(emp)
        → BaseRepository.Execute()
            → EmployeeValidator.ValidateForCreate(emp)  ← Domain Validation
            → _db.Employee.Add(emp)
            → _db.SaveChanges()
        → Result<Employee>
    → Refresh Grid
```

### 3. جستجوی بیمار
```
frmPatients.txtSearch_TextChanged
    → PatientRepository.SearchPatient(searchTerm)
        → _db.Patient.AsNoTracking().Where(...).Select(new PatientSearchListItem)
        → List<PatientSearchListItem>
    → Bind to DataGridView
```

---

## 📂 ساختار Namespaces

| پروژه | Namespace اصلی | زیرفضاهای مهم |
|-------|--------------|---------------|
| Laboratory | `Laboratory` | `Laboratory.Forms.Doctors`, `Laboratory.Forms.Employees`, `Laboratory.Forms.Patients`, `Laboratory.Forms.Tests`, `Laboratory.QuickAccess` |
| DataAccess | `DataAccess` | `DataAccess.Services` (Interfaces), `DataAccess.Repositories` (BaseRepository) |
| DomainModel | `DomainModel` | `DomainModel.Models`, `DomainModel.BussinessModel`, `DomainModel.Results`, `DomainModel.Validators` |
| Framework | `Framework` | (بدون زیرفضا) |

---

## 🔮 مسیر پیشنهادی تکامل معماری

### فاز ۱: زیرساخت (Infrastructure)
1. **افزودن DI Container** (Microsoft.Extensions.DependencyInjection)
2. **Scoped LabContext** - یک Context برای هر Unit of Work
3. **Scoped Repositories** - تزریق در Forms از طریق Constructor
4. **Serilog** - لاگ‌گیری ساختاری در BaseRepository

### فاز ۲: UnitOfWork Pattern
```csharp
public interface IUnitOfWork : IDisposable
{
    LabContext Context { get; }
    IEmployeeRepository Employees { get; }
    IPatientRepository Patients { get; }
    // ...
    int SaveChanges();
}
```

### فاز ۳: Service Layer
- استخراج `AuthService` (Login, ChangePassword)
- استخراج `AuditService` (LoginHistory)
- جدا کردن منطق Biz از Repositoryها

### فاز ۴: Cross-Repository Consistency
اعمال الگوی `BaseRepository` + `Validator` + `Constructor Injection` به ۱۰ Repository باقی‌مانده.

---

*آخرین به‌روزرسانی: ۱۴۰۳/۰۸/۱۴ - بر اساس تحلیل کد و کامیت‌های 1e3d27d، 6631dfb*
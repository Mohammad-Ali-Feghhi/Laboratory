# مرجع API - Laboratory Management System

## 📋 هدف و دامنه

این سند قرارداد API اپلیکیشن را مستند می‌کند. بر اساس تحلیل کد منبع، این برنامه یک **اپلیکیشن دسکتاپ Windows Forms** است و **هیچ REST API یا HTTP Endpoint عمومی ندارد**.

**آخرین تأیید:** ۱۴۰۳/۰۸/۱۷ (۲۰۲۶/۱۱/۰۷)  
**نوع اپلیکیشن:** Windows Forms Desktop Application (.NET Framework 4.7.2)  
**وضعیت API:** Not Applicable — No Public API

---

## 🖥️ معماری اپلیکیشن

### Entry Point
- **فایل:** `Laboratory/Program.cs`
- **متد:** `Main()` با `[STAThread]`
- **جریان:**
  1. `Application.EnableVisualStyles()`
  2. `Thread.CurrentThread.CurrentUICulture = new CultureInfo("fa-IR")`
  3. `Application.SetCompatibleTextRenderingDefault(false)`
  4. `Application.Run(new frmLogin())`

### فرم‌های اصلی (UI Forms)

| فرم | فایل | نقش |
|-----|------|-----|
| **frmLogin** | `Laboratory/Forms/frmLogin.cs` | احراز هویت، نقطه ورود |
| **frmMainBoard** | `Laboratory/Forms/frmMainBoard.cs` | MDI Parent، منوی اصلی، ناوبری |
| **frmEmployee** | `Laboratory/Forms/Employees/frmEmployee.cs` | مدیریت کارمندان (CRUD، جستجو) |
| **frmNewEmployee** | `Laboratory/Forms/Employees/frmNewEmployee.cs` | ثبت کارمند جدید |
| **frmInactiveEmployee** | `Laboratory/Forms/Employees/frmInactiveEmployee.cs` | کارمندان غیرفعال |
| **frmUserPassEmployee** | `Laboratory/Forms/Employees/frmUserPassEmployee.cs` | تغییر رمز کارمند |
| **frmNewPassword** | `Laboratory/Forms/Employees/frmNewPassword.cs` | رمز جدید |
| **frmOldPassword** | `Laboratory/Forms/Employees/frmOldPassword.cs` | رمز قدیمی |
| **frmDoctors** | `Laboratory/Forms/Doctors/frmDoctors.cs` | مدیریت پزشکان |
| **frmNewDoctor** | `Laboratory/Forms/Doctors/frmNewDoctor.cs` | ثبت پزشک جدید |
| **frmInactiveDoctors** | `Laboratory/Forms/Doctors/frmInactiveDoctors.cs` | پزشکان غیرفعال |
| **frmPatients** | `Laboratory/Forms/Patients/frmPatients.cs` | مدیریت بیماران |
| **frmNewPatient** | `Laboratory/Forms/Patients/frmNewPatient.cs` | ثبت بیمار جدید |
| **frmPatientShowInfo** | `Laboratory/Forms/Patients/frmPatientShowInfo.cs` | نمایش اطلاعات بیمار |
| **frmPatientTestAcceptionList** | `Laboratory/Forms/Patients/frmPatientTestAcceptionList.cs` | لیست پذیرش‌های بیمار |
| **frmNewTest** | `Laboratory/Forms/Tests/frmNewTest.cs` | مدیریت آزمایش‌ها |
| **frmNewTestParameter** | `Laboratory/Forms/Tests/frmNewTestParameter.cs` | پارامترهای آزمایش |
| **frmNewTestRange** | `Laboratory/Forms/Tests/frmNewTestRange.cs` | محدوده‌های مرجع آزمایش |
| **QuickAccessPanel** | `Laboratory/QuickAccess/QuickAccessPanel.cs` | پنل دسترسی سریع |

### ناوبری (Navigation Pattern)
- **MDI Architecture:** `frmMainBoard` به عنوان MDI Parent
- **Child Forms:** تمام فرم‌های عملیات به عنوان MDI Child در `frmMainBoard` باز می‌شوند
- **Menu Strip:** منوی اصلی در `frmMainBoard` برای ناوبری به فرم‌ها

---

## 🔌 لایه دسترسی به داده (Data Access Layer) — Internal Contracts

این برنامه از **Repository Pattern** با Interfaceها برای انتزاع داده استفاده می‌کند. این Internal Contracts هستند، نه Public API.

### Repository Interfaces (Services)

| Interface | فایل | متدهای کلیدی |
|-----------|------|--------------|
| `IEmployeeRepository` | `DataAccess/Services/IEmployeeRepository.cs` | Login، AddNewEmployee، UpdateEmployee، DeleteEmployee، ActivateEmployee، CheckUsernameExists، GetAllEmployees، SearchEmployee، ChangePassword، ValidateLoginAttempt، AddToLoginHistory |
| `IDoctorRepository` | `DataAccess/Services/IDoctorRepository.cs` | AddNewDoctor، UpdateDoctor، GetDoctorByDoctorId، GetAllDoctors، GetAllDeactiveDoctors، SearchDoctor، HasExistMedicalLicenseNumber، DeleteDoctor، EnableDoctor |
| `IPatientRepository` | `DataAccess/Services/IPatientRepository.cs` | AddNewPatient، UpdatePatient، GetPatientByPatientId، GetAllPatients، SearchPatient، DeletePatient، HasExistNationalCode، PatientCheckingValidation، GetPatientTestListByPatientId |
| `ITestRepository` | `DataAccess/Services/ITestRepository.cs` | AddNewTest، UpdateTest، GetTestByTestId، GetAllTests، SearchTest، GetItemsByTestId، DeleteTest |
| `ITestAcceptionRepository` | `DataAccess/Services/ITestAcceptionRepository.cs` | AddNewTestAcception، GetTestAcceptionItem، GetAllTestAcceptionHeaders، GetAllTestAcceptionItems، HasExistTestAcceptionItem |
| `ITestCategoryRepository` | `DataAccess/Services/ITestCategoryRepository.cs` | GetAll |
| `ITestMethodRepository` | `DataAccess/Services/ITestMethodRepository.cs` | GetAll |
| `ITestRangeRepository` | `DataAccess/Services/ITestRangeRepository.cs` | GetAll، GetByTestId |
| `IUnitRepository` | `DataAccess/Services/IUnitRepository.cs` | GetAll |
| `IResponseTypeRepository` | `DataAccess/Services/IResponseTypeRepository.cs` | GetAll |
| `ISampleTypeRepository` | `DataAccess/Services/ISampleTypeRepository.cs` | GetAll |

### Result Pattern (Internal Contract)

```csharp
// DomainModel/Results/Result.cs
public class Result<T>
{
    public bool IsSuccess { get; private set; }
    public ErrorCode ErrorCode { get; private set; }
    public string Message { get; private set; }
    public T Data { get; private set; }

    public static Result<T> Success(T data) => new Result<T>(true, ErrorCode.None, "", data);
    public static Result<T> Fail(ErrorCode errorCode, string message) => new Result<T>(false, errorCode, message, default);
}

public enum ErrorCode
{
    None,
    ValidationError,
    UserNotFound,
    InvalidPassword,
    DatabaseError,
    // ...
}
```

### DTOs / ViewModels (Internal Data Contracts)

| DTO | فایل | استفاده |
|-----|------|---------|
| `DoctorSearchListItem` | `DomainModel/BussinessModel/DoctorSearchListItem.cs` | جستجوی پزشک |
| `PatientSearchListItem` | `DomainModel/BussinessModel/PatientSearchListItem.cs` | جستجوی بیمار |
| `EmployeeSearchListItem` | `DomainModel/BussinessModel/EmployeeSearchListItem.cs` | جستجوی کارمند — **⚠️ شامل Password** |
| `PatientTestListItem` | `DomainModel/BussinessModel/PatientTestListItem.cs` | لیست تست‌های بیمار |
| `TestAcceptionListItem` | `DomainModel/BussinessModel/TestAcceptionListItem.cs` | لیست پذیرش |
| `TestAcceptionItemViewModel` | `DomainModel/BussinessModel/TestAcceptionItemViewModel.cs` | جزئیات آیتم پذیرش |
| `AddNewPatientTestItem` | `DomainModel/BussinessModel/AddNewPatientTestItem.cs` | افزودن تست به بیمار |
| `PatientCheckingValidationItem` | `DomainModel/BussinessModel/PatientCheckingValidationItem.cs` | اعتبارسنجی بیمار |
| `TestParameterTemp` | `DomainModel/BussinessModel/TestParameterTemp.cs` | پارامتر موقت تست |
| `UserPassEmployee` | `DomainModel/BussinessModel/UserPassEmployee.cs` | تغییر رمز کارمند |

---

## 🌐 عدم وجود REST API

### بیانیه صریح
> **این اپلیکیشن هیچ REST API، HTTP Endpoint، Web API Controller، یا gRPC Service ندارد.**

### دلایل
1. **معماری:** Windows Forms Desktop Application — کلاینت سنگین (Thick Client)
2. **Deployment:** Installer-based روی Workstation‌های آزمایشگاه
3. **Data Access:** مستقیم به SQL Server از طریق Entity Framework 6
4. **Authentication:** Form-based Login در کلاینت، نه Token-based

### مقایسه با معماری‌های با API

| ویژگی | معماری فعلی | معماری با REST API |
|--------|-------------|-------------------|
| **Client** | Windows Forms (EXE) | Browser / Mobile App |
| **Server** | هم‌هم‌روی Client (Same Process) | Web API Server (IIS/Kestrel) |
| **Communication** | In-Process Method Calls | HTTP/HTTPS + JSON |
| **Authentication** | Form Login + Session در حافظه | JWT / OAuth2 Tokens |
| **Deployment** | ClickOnce / Installer | CI/CD → Web Server |
| **Scalability** | محدود به Workstation | Horizontal Scaling |

---

## 🔮 اگر در آینده REST API اضافه شود

این فایل باید با موارد زیر گسترش یابد:

### پیشنهادی API Structure
```
Base URL: https://api.laboratory.local/v1

Endpoints:
├── /auth
│   ├── POST   /login
│   ├── POST   /refresh
│   └── POST   /logout
├── /employees
│   ├── GET    /                    (Pagination, Filter)
│   ├── GET    /{id}
│   ├── POST   /
│   ├── PUT    /{id}
│   ├── DELETE /{id}                (Soft Delete)
│   └── POST   /{id}/password
├── /doctors
├── /patients
├── /tests
├── /test-acceptions
└── /lookups
    ├── /categories
    ├── /methods
    ├── /units
    ├── /sample-types
    └── /response-types
```

### الزامات Security (اگر API اضافه شود)
- JWT Bearer Token Authentication
- Role-based Authorization (Admin، Technician، Doctor)
- Rate Limiting
- HTTPS Enforcement
- Input Validation / Sanitization
- Audit Logging

---

## 📋 خلاصه

| مورد | وضعیت |
|------|-------|
| **Application Type** | Windows Forms Desktop (.NET Framework 4.7.2) |
| **Public REST API** | ❌ وجود ندارد |
| **Public HTTP Endpoints** | ❌ وجود ندارد |
| **Internal Repository Contracts** | ✅ ۱۱ Interface + Result<T> Pattern |
| **Internal DTOs** | ✅ ۱۰ ViewModel/DTO |
| **Authentication** | Form-based (frmLogin) |
| **Deployment** | Desktop Installer / ClickOnce |

---

*این سند برای کامل بودن ساختار مستندات ۱۲‌گانه ایجاد شده است. اگر در آینده REST API توسعه یابد، این فایل باید به‌روزرسانی شود.*
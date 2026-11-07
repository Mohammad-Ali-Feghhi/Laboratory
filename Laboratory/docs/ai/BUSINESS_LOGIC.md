# منطق تجاری و قوانین کسب‌وکار - Laboratory Management System

## 🎯 ماژول‌های تجاری اصلی

| ماژول | موجودیت‌های اصلی | Repository | توضیح |
|-------|----------------|------------|-------|
| **مدیریت کارمندان** | Employee, LoginHistory | EmployeeRepository | احراز هویت، کنترل دسترسی، مدیریت پروفایل |
| **مدیریت بیماران** | Patient | PatientRepository | ثبت، جستجو، پذیرش آزمایش |
| **مدیریت پزشکان** | Doctor | DoctorRepository | مجوز پزشکی، فعال/غیرفعال |
| **مدیریت آزمایش‌ها** | Test, TestCategory, TestMethod, TestRange, Unit, SampleType, ResponseType | TestRepository + 6 Repository | تعریف تست، پارامترها، محدوده‌ها |
| **پذیرش آزمایش** | TestAcceptionHeader, TestAcceptionItem | TestAcceptionRepository | ثبت سفارش، ردیابی وضعیت |

---

## 🔐 ماژول احراز هویت و کارمندان (Employee Module)

### سرویس اصلی: EmployeeRepository
**فایل:** `DataAccess/EmployeeRepository.cs` (ریفکتور شده در فاز ۳)

### متدهای اصلی

| متد | ورودی | خروجی | توضیح |
|------|-------|-------|-------|
| `Login(username, password)` | string, string | `Result<Employee>` | ورود کاربر - **⚠️ SEC-001: Plain Text Comparison** |
| `AddNewEmployee(emp)` | Employee | `Result<Employee>` | ثبت کارمند جدید + Validation |
| `UpdateEmployee(emp)` | Employee | `Result<Employee>` | ویرایش کارمند + Validation |
| `DeleteEmployee(id)` | int | `Result<Employee>` | Soft Delete (بررسی وابستگی TestAcception) |
| `ActivateEmployee(id)` | int | `Result<Employee>` | فعال‌سازی کارمند غیرفعال |
| `ChangePassword(id, password)` | int, string | `Result<Employee>` | تغییر رمز - **⚠️ Plain Text Storage** |
| `CheckUsernameExists(username)` | string | `Result<Employee>` | بررسی یکتایی نام کاربری |
| `ValidateLoginAttempt(id)` | int | bool | قفل کردن کاربر پس از تلاش‌های ناموفق |
| `AddToLoginHistory(username)` | string | `Result<LoginHistory>` | ثبت لاگ ورود موفق |
| `AddToLoginHistoryDatabaseError(log)` | LoginHistory | `Result<LoginHistory>` | ثبت لاگ خطای دیتابیس |

### قوانین اعتبارسنجی (EmployeeValidator - DomainModel/Validators/EmployeeValidator.cs)

#### ValidateForCreate (ثبت جدید)
```csharp
// فیلدهای الزامی مشترک
EmployeeName: Required, StringLength(100)
Username: Required, StringLength(100), Unique (Biz Check)
Password: Required, StringLength(100)  ← فقط در Create
PhoneNumber: Required, StringLength(20)
Address: Required, StringLength(400)
BirthDate: Required (DateTime?)

// اعتبارسنجی DataAnnotations (اختیاری)
ValidateDataAnnotations(employee) → List<ValidationResult>
```

#### ValidateForUpdate (ویرایش)
```csharp
// فیلدهای الزامی مشترک (بدون Password)
EmployeeName, Username, PhoneNumber, Address, BirthDate
// Password در Update الزامی نیست
```

### رویدادهای حیاتی و قوانین Biz

| رویداد | قانون | پیاده‌سازی |
|--------|-------|-----------|
| **ثبت کارمند** | Username یکتا، فیلدهای الزامی پر شده | `EmployeeValidator.ValidateForCreate` + `CheckUsernameExists` |
| **ویرایش کارمند** | کاربر وجود داشته باشد، فیلدها معتبر | `EmployeeValidator.ValidateForUpdate` |
| **حذف کارمند** | نباید در TestAcceptionHeader ثبت آزمایش داشته باشد | `DeleteEmployee` چک `Any(x => x.RegistrationEmployeeId == id)` |
| **تغییر رمز** | رمز جدید با فعلی متفاوت باشد | `ChangePassword` چک `password == user.Password` |
| **ورود** | کاربر Active باشد، رمز صحیح | `Login` چک `IsEnabled == true` + Plain Text Compare |
| **قفل حساب** | پس از تلاش‌های ناموفق | `ValidateLoginAttempt` → `IsEnabled = false` |

---

## 🏥 ماژول مدیریت پزشکان (Doctor Module)

### سرویس اصلی: DoctorRepository
**فایل:** `DataAccess/DoctorRepository.cs` (پターن قدیمی، هنوز ریفکتور نشده)

### متدهای اصلی

| متد | ورودی | خروجی | توضیح |
|------|-------|-------|-------|
| `AddNewDoctor(doctor)` | Doctor | `Result<Doctor>` | ثبت پزشک + Validation |
| `UpdateDoctor(doctor)` | Doctor | `Result<Doctor>` | ویرایش پزشک + Validation |
| `GetDoctorByDoctorId(id)` | int | `Result<Doctor>` | دریافت با AsNoTracking |
| `GetDoctorByMedicalLicenseNumber(license)` | string | `Result<Doctor>` | جستجو با مجوز پزشکی |
| `HasExistMedicalLicenseNumber(license)` | string | `Result<Doctor>` | بررسی یکتایی مجوز |
| `GetAllDoctors()` | - | `List<Doctor>` | با AsNoTracking |
| `GetAllDeactiveDoctors()` | - | `List<Doctor>` | با AsNoTracking |
| `SearchDoctor(phrase)` | string | `List<DoctorSearchListItem>` | جستجو با Projection |
| `DeleteDoctor(id)` | int | `Result<Doctor>` | Soft Delete (چک وابستگی TestAcception) |
| `EnableDoctor(id)` | int | `Result<Doctor>` | فعال‌سازی |
| `GetAllTestAcceptionsByDoctorId(id)` | int | `Result<List<TestAcceptionHeader>>` | تست‌های پزشک |

### قوانین اعتبارسنجی (در Repository - هنوز جداسازی نشده)

| قانون | پیام خطا | مکان |
|-------|----------|------|
| نام پزشک الزامی | "نام دکتر الزامی است." | AddNewDoctor, UpdateDoctor |
| مجوز پزشکی الزامی | "شماره نظام پزشکی الزامی است." | AddNewDoctor, UpdateDoctor |
| مجوز پزشکی ≥ ۴ کاراکتر (Add) | "شماره نظام پزشکی درست وارد نشده است." | AddNewDoctor |
| مجوز پزشکی ≥ ۵ کاراکتر (Update) | "شماره نظام پزشکی درست وارد نشده است." | UpdateDoctor |
| مجوز پزشکی یکتا | "شماره نظام پزشکی {license} قبلاً ثبت شده است." | HasExistMedicalLicenseNumber |

---

## 👤 ماژول مدیریت بیماران (Patient Module)

### سرویس اصلی: PatientRepository
**فایل:** `DataAccess/PatientRepository.cs`

### متدهای مهم

| متد | توضیح |
|------|-------|
| `GetPatientTestListByPatientId(id)` | **Projection خوب** - با Join به Doctor, Employee, Test |
| `SearchPatient(phrase)` | جستجو با Projection به PatientSearchListItem |
| `GetAllPatients()` | با AsNoTracking |
| `GetPatientByPatientId(id)` | با AsNoTracking |

###Projection نمونه (PatientTestListItem)
```csharp
select new PatientTestListItem
{
    TestAcceptionHeaderId = item.TestAcceptionHeaderId,
    TestName = item.Test.TestName,
    DoctorName = item.TestAcceptionHeader.Doctor.DoctorName,
    RegistrationEmployeeName = item.TestAcceptionHeader.Employee.EmployeeName,
    // ...
}
```

---

## 🧪 ماژول مدیریت آزمایش‌ها (Test Module)

### موجودیت‌ها و Repositoryها

| موجودیت | Repository | عملیات اصلی |
|---------|------------|-------------|
| **Test** | TestRepository | CRUD، جستجو، GetItemsByTestId (Projection) |
| **TestCategory** | TestCategoryRepository | GetAll (Lookup) |
| **TestMethod** | TestMethodRepository | GetAll (Lookup) |
| **TestRange** | TestRangeRepository | GetAll، GetByTestId (محدوده مرجع) |
| **Unit** | UnitRepository | GetAll (Lookup) |
| **SampleType** | SampleTypeRepository | GetAll (Lookup) |
| **ResponseType** | ResponseTypeRepository | GetAll (Lookup) |

### روابط Test (مرکزی‌ترین موجودیت)
```
Test
  ├── TestCategory (Required)
  ├── TestMethod (Required)
  ├── Unit (Required)
  ├── SampleType (Required)  ← FIXED: SamplyeTypeId
  ├── ResponseType (Required)
  ├── TestRange (1:N) - محدوده‌های مرجع
  └── TestAcceptionItem (1:N) - در پذیرش‌ها
```

---

## 📋 ماژول پذیرش آزمایش (TestAcception Module)

### موجودیت‌ها
| موجودیت | توضیح |
|---------|-------|
| **TestAcceptionHeader** | هدر پذیرش: Patient, Doctor, RegistrationEmployee, ConfirmationEmployee, تاریخ، وضعیت |
| **TestAcceptionItem** | آیتم‌ها: Header, Test، نتیجه، پارامترها |

### Repository: TestAcceptionRepository
- Join پیچیده با AsNoTracking روی تمام منابع
- `GetAllTestAcceptionItems()` - Projection با Join صریح
- `HasExistTestAcceptionItem(headerId, testId)` - بررسی تکرار

---

## ⚠️ مسائل امنیتی و تجاریCritical

### SEC-001: Password Hashing Inconsistency 🔴 Critical
```csharp
// HashingUtility.HashPasswordWithKey(password) در UI
// اما در دیتابیس Plain Text ذخیره می‌شود
// Login: user.Password != password  ← همیشه False برای رمز هش شده!
```

**تأثیر:** کاربران با رمز هش شده نمی‌توانند لاگین کنند.

### SEC-002: Hardcoded HMAC Key 🔴 High
```csharp
// Framework/HashingUtility.cs:18
string key = "b613679a0814d9ec772f95d778c35fc5ff1697c493715653c6c712144292c5ad";
```

**تأثیر:** کلید در Source Control، قابل استخراج، عدم امکان Rotate Key.

### DB-002: Username Race Condition 🟡 Medium
```csharp
// CheckUsernameExists و AddNewEmployee در تراکنش واحد نیستند
// دو درخواست همزمان می‌توانند Username یکسان ثبت کنند
```

### DB-004: ValidateLoginAttempt Race Condition 🟡 Medium
```csharp
// خواندن User → چک IsEnabled → آپدیت IsEnabled=false
// در بین دو درخواست، هر دو موفق می‌شوند
```

### QUA-004: Soft Delete Inconsistency 🟡 Medium
- منطق `IsDeleted == false` در همه جا تکرار شده
- هیچ Extension Method یکپارچه `WhereNotDeleted()` وجود ندارد

---

## 📊دیو ماژول‌ها (Module Dependencies)

```
┌─────────────────────────────────────────────────────────────┐
│                    Employee Module                          │
│  ├── Auth (Login, ChangePassword, ValidateLoginAttempt)    │
│  ├── Profile Management (Add, Update, Delete, Activate)    │
│  └── Audit (LoginHistory - AddToLoginHistory*)             │
└────────────────────────┬────────────────────────────────────┘
                         │ Uses
                         ▼
┌─────────────────────────────────────────────────────────────┐
│                    TestAcception Module                     │
│  ├── RegistrationEmployeeId → Employee                      │
│  ├── ConfirmationEmployeeId → Employee                      │
│  └── PatientId → Patient                                    │
└────────────────────────┬────────────────────────────────────┘
                         │ Uses
                         ▼
┌─────────────────────────────────────────────────────────────┐
│                    Doctor Module                            │
│  └── DoctorId → TestAcceptionHeader                         │
└────────────────────────┬────────────────────────────────────┘
                         │ Uses
                         ▼
┌─────────────────────────────────────────────────────────────┐
│                    Test Module (Core)                       │
│  ├── Category, Method, Unit, SampleType, ResponseType       │
│  ├── TestRange (Reference Ranges)                           │
│  └── TestAcceptionItem → Test                               │
└─────────────────────────────────────────────────────────────┘
```

---

## 🔄 پیشنهادی برای جدا کردن سرویس‌ها (Phase 3-5, 3-6)

### AuthService (جدید)
```csharp
public interface IAuthService
{
    Result<Employee> Login(string username, string password);
    Result<Employee> ChangePassword(int employeeId, string newPassword);
    bool ValidateLoginAttempt(int employeeId);
}
```
- استفاده از `IPasswordHasher` (BCrypt)
- جدا کردن منطق احراز هویت از EmployeeRepository

### AuditService (جدید)
```csharp
public interface IAuditService
{
    Task LogLoginAsync(string username);
    Task LogErrorAsync(string username, string errorMessage);
}
```
- Fire-and-Forget pattern با fallback
- جدا کردن `AddToLoginHistory*` از EmployeeRepository

---

## 📝 خلاصه قوانین Biz تاییدشده vs نیازمند بررسی

| قانون | وضعیت | منبع |
|-------|-------|------|
| Employee: فیلدهای Name, Username, Phone, Address, BirthDate الزامی | ✅ تأییدشده | EmployeeValidator |
| Employee: Username یکتا | ✅ تأییدشده | CheckUsernameExists |
| Employee: Password در Create الزامی، در Update اختیاری | ✅ تأییدشده | EmployeeValidator |
| Employee: نمی‌توان حذف کرد اگر TestAcception داشته باشد | ✅ تأییدشده | DeleteEmployee |
| Doctor: MedicalLicenseNumber یکتا | ✅ تأییدشده | HasExistMedicalLicenseNumber |
| Doctor: MedicalLicenseNumber طول حداقل ۴/۵ | ✅ تأییدشده | Add/UpdateDoctor |
| Patient: NationalCode یکتا (فرض) | ⚠️ نیازمند تأیید | کد موجود نیست در Validator |
| Test: تمام FKها (Category, Method, Unit, SampleType, ResponseType) Required | ✅ تأییدشده | Fluent API WithRequired |
| Soft Delete: IsDeleted = true به جای حذف فیزیکی | ✅ تأییدشده | همه Repositoryها |
| Login: User باید IsEnabled == true باشد | ✅ تأییدشده | Login method |

---

*آخرین به‌روزرسانی: ۱۴۰۳/۰۸/۱۴ - بر اساس EmployeeRepository، EmployeeValidator، DoctorRepository، PatientRepository، TestRepository*
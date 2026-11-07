# بررسی امنیتی - Laboratory Management System

## 📋 هدف و دامنه

این سند یافته‌های امنیتی تأییدشده بر اساس تحلیل کد منبع (Verification Report ۱۴۰۳/۰۸/۱۷) را مستند می‌کند. تمام ادعاهای این فایل بر اساس بررسی مستقیم فایل‌های سورس تأیید شده‌اند.

**آخرین تأیید:** ۱۴۰۳/۰۸/۱۷ (۲۰۲۶/۱۱/۰۷)  
**روش تأیید:** بررسی مستقیم کد منبع (Read-only)  
**وضعیت:** تمام Findings تأییدشده با اثبات منبع

---

## 🔴 SEC-001: Password Hashing Inconsistency (عدم تطابق هش کردن رمز عبور)

### توضیح
سیستم احراز هویت به‌صورت کامل Broken است. UI رمز عبور را با HMACSHA256 هش می‌کند، اما دیتابیس رمزها را به صورت Plain Text ذخیره می‌کند و مقایسه Login بین Hash (ورودی UI) و Plain Text (دیتابیس) انجام می‌شود که همیشه Fail می‌شود.

### اثبات (Evidence)

| مؤلفه | فایل:خط | رفتار |
|---------|----------|-------|
| **UI Hashing** | `Laboratory/Forms/frmLogin.cs:90` | `var hashPassword = _secret.HashPasswordWithKey(txtPassword.Text);` |
| **Login Compare** | `DataAccess/EmployeeRepository.cs:204` | `if (user.Password != password)` — `user.Password` = Plain Text از DB، `password` = Hash از UI |
| **Employee.Password** | `DomainModel/Models/Employee.cs:31` | `[StringLength(100)] public string Password { get; set; }` — Plain Text در DB |
| **AddNewEmployee** | `DataAccess/EmployeeRepository.cs:47-48` | `_db.Employee.Add(emp)` — بدون هش کردن قبل از ذخیره |
| **ChangePassword** | `DataAccess/EmployeeRepository.cs:282` | `user.Password = password` — بدون هش کردن |

### جریان احراز هویت (مستقیم از کد)
```
1. frmLogin → کاربر رمز می‌نویسد
2. HashingUtility.HashPasswordWithKey() → HMACSHA256 با کلید هاردکد
3. EmployeeRepository.Login(username, hashPassword)
4. DB query → user.Password (Plain Text)
5. مقایسه: user.Password != hashPassword → همیشه True
6. نتیجه: ErrorCode.InvalidPassword → "رمز عبور اشتباه است!"
```

### تأثیر
- **Login:** هیچ کاربری نمی‌تواند وارد شود (مگر داده‌های Seed از قبل هش شده باشند)
- **AddNewEmployee:** رمز Plain Text ذخیره می‌شود
- **ChangePassword:** رمز جدید Plain Text ذخیره می‌شود
- **Production Deployment:** Blocker است — سیستم غیرقابل استفاده

### شدت
**🔴 Critical (P0)** — Blocker برای استقرار Production

### راهکار پیشنهادی (Remediation Strategy)
1. **Abstraction:** معرفی `IPasswordHasher` در DomainModel
2. **Implementation:** ارزیابی BCrypt.Net-Next 4.x یا Argon2id با .NET Framework 4.7.2
   - BCrypt: سازگار، Salt یکتا، Work Factor قابل تنظیم
   - Argon2id: مقاوم‌تر در برابر GPU، نیاز به Konscious.Security.Cryptography.Argon2
3. **Migration:** استراتژی مهاجرت رمزهای موجود
   - شناسایی کاربران با رمز Plain Text
   - هش کردن Batch در Migration/Script
   - Fallback برای Login اولیه (بررسی هر دو فرمت)
4. **Consistency:** اطمینان از استفاده یکسان در Login، AddNewEmployee، ChangePassword
5. **Key Rotation:** حذف کلید هاردکد پس از Migration کامل

### وضعیت تأیید
✅ **تأیید شده** — تمام اثبات‌ها در کد منبع مستقیم قابل مشاهده

---

## 🟠 SEC-002: Hardcoded HMAC Key (کلید HMAC هاردکد شده)

### توضیح
کلید مخفی HMACSHA256 در کد منبع به صورت Hardcoded وجود دارد که در Source Control قابل استخراج است.

### اثبات
- **فایل:** `Framework/HashingUtility.cs:18`
- **محتوا:** `string key = "b613679a0814d9ec772f95d778c35fc5ff1697c493715653c6c712144292c5ad";`
- **استفاده:** در `HashPasswordWithKey()` برای HMACSHA256

### رابطه با SEC-001
این کلید در جریان Login فعلی استفاده می‌شود (UI هش می‌کند)، اما چون مقایسه با Plain Text در DB انجام می‌شود (SEC-001)، کلید فعلاً در مسیر Authentication نقشی ایفا نمی‌کند. با رفع SEC-001، این کلید به کلید اصلی هش کردن تبدیل می‌شود.

### ریسک‌ها
- کلید در Git History و Source Control قابل استخراج
- امکان Rotate Key وجود ندارد بدون Deploy جدید
- اگر مهاجرت رمزها با همین کلید انجام شود، همه هش‌ها با کلید یکسان قابل محاسبه هستند

### شدت
**🟠 High (P1)** — وابسته به شرایط'exposition' و رفع SEC-001

### راهکار پیشنهادی
1. کلید را به Configuration (App.config / Environment Variable / Key Vault) منتقل کنید
2. پس از Migration رمزها (SEC-001)، کلید قدیمی را Rotate کنید
3. از Secret Management مناسب برای محیط Production استفاده کنید

### وضعیت تأیید
✅ **تأیید شده** — خط ۱۸ در HashingUtility.cs مستقیم قابل مشاهده

---

## 🟡 DB-002: Username Race Condition (شرط مسابقه نام کاربری)

### توضیح
بررسی یکتایی Username و ثبت کاربر در دو مرحله مجزا و بدون تراکنش واحد انجام می‌شود.

### اثبات
- **فایل:** `DataAccess/EmployeeRepository.cs:40-45` (CheckUsernameExists) و `AddNewEmployee` خط ۳۰-۵۰
- **الگو:** 
  1. `CheckUsernameExists(username)` — بررسی وجود
  2. `AddNewEmployee(emp)` — ثبت کاربر
- **شرط مسابقه:** دو Request همزمان هر دو در Check Pass می‌شوند، هر دو در Add ثبت می‌شوند

### تأثیر
- امکان ثبت Username تکراری در پایگاه داده
- خطای Unique Constraint در سطح DB (SQL Error 2627/2601) که در BaseRepository.MapSqlException هندل می‌شود

### شدت
**🟡 Medium (P2)** —.BaseRepository.MapSqlException خطای 2627/2601 را به ValidationError نگاشت می‌دهد، اما تجربه کاربری نامناسب است

### راهکار پیشنهادی
1. Unique Constraint در سطح دیتابیس (Index روی Username) — EF Migration نیاز است
2. یا تراکنش Serializable / Lock در کد
3. استفاده از `INSERT ... WHERE NOT EXISTS` pattern

### وضعیت تأیید
✅ **تأیید شده** — کد در EmployeeRepository.cs خطوط ۴۰-۵۰ و ۳۰-۵۰

---

## 🟡 DB-004: ValidateLoginAttempt Race Condition (شرط مسابقه قفل حساب)

### توضیح
فرآیند قفل کردن کاربر پس از تلاش‌های ناموفق بدون Lock اتمیک انجام می‌شود.

### اثبات
- **فایل:** `DataAccess/EmployeeRepository.cs:289-301`
- **متد:** `ValidateLoginAttempt(int employeeId)`
- **الگو:**
  1. `var user = _db.Employee.FirstOrDefault(...)` — خواندن
  2. `user.IsEnabled = false` — تغییر در حافظه
  3. `_db.SaveChanges()` — ذخیره
- **شرط مسابقه:** دو Request همزمان هر دو User را Enabled می‌بینند، هر دو IsEnabled=false می‌کنند، هر دو SaveChanges موفق می‌شوند

### تأثیر
- قفل کردن نامناسب (ممکن است بیش از حد قفل شود یا لاگ‌ها تکراری ثبت شود)
- در BaseRepository.AddToLoginHistoryDatabaseError نیز pattern مشابه وجود دارد

### شدت
**🟡 Medium (P2)** — اثر جانبی محدود، اما ناهمگونی داده در LoginHistory

### راهکار پیشنهادی
1. Atomic Update در SQL: `UPDATE Employee SET IsEnabled=0 WHERE EmployeeId=@id AND IsEnabled=1`
2. یا Row Version / Concurrency Token در EF
3. تراکنش Serializable

### وضعیت تأیید
✅ **تأیید شده** — متد ValidateLoginAttempt خط ۲۸۹-۳۰۱

---

## 📊 خلاصه شدت‌بندی

| ID | عنوان | شدت | اولویت | وضعیت |
|----|-------|------|--------|--------|
| SEC-001 | Password Hashing Inconsistency | 🔴 Critical | P0 | ✅ تأیید شده |
| SEC-002 | Hardcoded HMAC Key | 🟠 High | P1 | ✅ تأیید شده |
| DB-002 | Username Race Condition | 🟡 Medium | P2 | ✅ تأیید شده |
| DB-004 | ValidateLoginAttempt Race | 🟡 Medium | P2 | ✅ تأیید شده |

---

## 🔐 نکات پیاده‌سازی امن

### الزامات Migration
- هیچ تغییری در داده‌های موجود انجام نشده است
- استراتژی Migration باید قبل از Deploy طراحی شود
- تست کامل Flow Login/Register/ChangePassword الزامی است

### وابستگی‌ها
- SEC-001 باید قبل از SEC-002 Rotate Key حل شود
- EF6 Migrations برای Unique Constraint (DB-002) نیاز است
- DI Container برای تزریق IPasswordHasher نیاز است

---

*این سند بر اساس تحلیل کد منبع Read-only تهیه شده. هیچ تست امنیتی، پنتست، یا اسکن خارجی انجام نشده است.*
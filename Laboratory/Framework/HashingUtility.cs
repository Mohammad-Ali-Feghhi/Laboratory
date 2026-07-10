using System.Security.Cryptography;
using System.Text;

namespace Framework
{
    public class HashingUtility
    {
        /// <summary>
        /// یک رمز عبور را با استفاده از HMACSHA256 و یک کلید سری هش می‌کند.
        /// این فرایند قطعی و غیرقابل برگشت است.
        /// </summary>
        /// <param name="password">رشته ورودی (رمز).</param>
        /// <param name="secretKey">کلید سری که برای HMAC استفاده خواهد شد.</param>
        /// <returns>هش HMACSHA256 به صورت رشته هگزادسیمال.</returns>
        public string HashPasswordWithKey(string password)
        {

            string key = "b613679a0814d9ec772f95d778c35fc5ff1697c493715653c6c712144292c5ad";
            if (string.IsNullOrEmpty(password))
            {
                return string.Empty;
            }

            // تبدیل کلید سری و رمز عبور به آرایه بایت
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // استفاده از HMACSHA256
            using (var hmac = new HMACSHA256(keyBytes))
            {
                // محاسبه هش
                byte[] hashBytes = hmac.ComputeHash(passwordBytes);

                // تبدیل آرایه بایت هش شده به یک رشته هگزادسیمال
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

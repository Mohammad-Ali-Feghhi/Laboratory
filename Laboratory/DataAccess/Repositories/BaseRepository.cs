using System;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using DomainModel.Results;

namespace DataAccess.Repositories
{
    /// <summary>
    /// کلاس پایه برای Repositoryها - مدیریت متمرکز خطا و الگوی Execute
    /// </summary>
    public abstract class BaseRepository
    {
        /// <summary>
        /// اجرای عملیات دیتابیس با مدیریت متمرکز خطا
        /// </summary>
        /// <typeparam name="T">نوع نتیجه</typeparam>
        /// <param name="action">عملیات دیتابیس</param>
        /// <returns>Result با موفقیت یا DatabaseError</returns>
        protected Result<T> Execute<T>(Func<Result<T>> action)
        {
            try
            {
                return action();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx)
            {
                return MapSqlException<T>(sqlEx.Number);
            }
            catch (DbUpdateException ex)
            {
                // سایر خطاهای EF Update
                return Result<T>.Fail(ErrorCode.DatabaseError, "خطا در ذخیره‌سازی اطلاعات: " + ex.Message);
            }
            catch (EntityException ex)
            {
                // خطاهای اتصال/Entity Framework
                return Result<T>.Fail(ErrorCode.DatabaseError, "خطای اتصال به دیتابیس: " + ex.Message);
            }
            catch (SqlException ex)
            {
                // خطاهای مستقیم SQL
                return MapSqlException<T>(ex.Number);
            }
            catch (Exception ex)
            {
                // خطاهای غیرمنتظره - در محیط تولید لاگ شود، پیام عمومی برگردانده شود
                return Result<T>.Fail(ErrorCode.DatabaseError, "خطای دیتابیس رخ داد: " + ex.Message);
            }
        }

        /// <summary>
        /// اجرای عملیات دیتابیس که نتیجه‌ای برنمی‌گرداند (void)
        /// </summary>
        /// <param name="action">عملیات دیتابیس</param>
        /// <returns>Result خالی با موفقیت یا DatabaseError</returns>
        protected Result<object> Execute(Action action)
        {
            return Execute<object>(() =>
            {
                action();
                return Result<object>.Success(null);
            });
        }

        /// <summary>
        /// نگاشت کدهای خطای SQL Server به ErrorCode مناسب
        /// </summary>
        protected virtual Result<T> MapSqlException<T>(int errorNumber)
        {
            // کدهای خطای رایج SQL Server
            switch (errorNumber)
            {
                case 2627: // Unique Constraint Violation (Primary Key)
                case 2601: // Duplicate Key
                    return Result<T>.Fail(ErrorCode.ValidationError, "اطلاعات تکراری است. این رکورد قبلاً ثبت شده است.");

                case 547: // Foreign Key Violation
                    return Result<T>.Fail(ErrorCode.ValidationError, "عملیات نامعتبر است. اطلاعات وابسته وجود دارد.");

                case 1205: // Deadlock Victim
                    return Result<T>.Fail(ErrorCode.DatabaseError, "تداخل در دسترسی به دیتابیس. لطفاً مجدداً تلاش کنید.");

                case -2: // Timeout
                    return Result<T>.Fail(ErrorCode.DatabaseError, "زمان انتظار برای پاسخ دیتابیس به پایان رسید.");

                case 823: // I/O Error (Database Corruption)
                case 824: // Logical Consistency Error
                    return Result<T>.Fail(ErrorCode.DatabaseError, "خطای دیتابیس جدی. با مدیریت سیستم تماس بگیرید.");

                default:
                    // برای سایر خطاها، پیام عمومی برگردان (جزئیات در لاگ ثبت شود)
                    return Result<T>.Fail(ErrorCode.DatabaseError, "خطای دیتابیس رخ داد (کد: " + errorNumber + ")");
            }
        }
    }
}
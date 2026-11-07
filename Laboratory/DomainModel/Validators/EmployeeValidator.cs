using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DomainModel.Models;
using DomainModel.Results;

namespace DomainModel.Validators
{
    /// <summary>
    /// اعتبارسنجی موجودیت کارمند - شامل قوانین کسب‌وکار برای Add و Update
    /// </summary>
    public static class EmployeeValidator
    {
        /// <summary>
        /// اعتبارسنجی کامل برای ایجاد کارمند جدید
        /// </summary>
        /// <param name="employee"> موجودیت کارمند</param>
        /// <returns>Result با موفقیت یا اولین خطای ValidationError</returns>
        public static Result<Employee> ValidateForCreate(Employee employee)
        {
            // اعتبارسنجی فیلدهای مشترک
            var commonResult = ValidateCommonFields(employee);
            if (!commonResult.IsSuccess)
                return commonResult;

            // رمز عبور برای ایجاد جدید الزامی است
            if (string.IsNullOrWhiteSpace(employee.Password))
            {
                return Result<Employee>.Fail(ErrorCode.ValidationError, "رمز عبور الزامی است!");
            }

            return Result<Employee>.Success(default);
        }

        /// <summary>
        /// اعتبارسنجی برای به‌روزرسانی کارمند موجود
        /// </summary>
        /// <param name="employee"> موجودیت کارمند با مقادیر جدید</param>
        /// <returns>Result با موفقیت یا اولین خطای ValidationError</returns>
        public static Result<Employee> ValidateForUpdate(Employee employee)
        {
            // اعتبارسنجی فیلدهای مشترک (رمز عبور در Update الزامی نیست)
            return ValidateCommonFields(employee);
        }

        /// <summary>
        /// اعتبارسنجی فیلدهای مشترک بین Create و Update
        /// </summary>
        /// <param name="employee"> موجودیت کارمند</param>
        /// <returns>Result با موفقیت یا خطای ValidationError</returns>
        private static Result<Employee> ValidateCommonFields(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.EmployeeName))
            {
                return Result<Employee>.Fail(ErrorCode.ValidationError, "نام و نام خانوادگی الزامیست!");
            }

            if (string.IsNullOrWhiteSpace(employee.Username))
            {
                return Result<Employee>.Fail(ErrorCode.ValidationError, "نام کاربری الزامیست!");
            }

            if (string.IsNullOrWhiteSpace(employee.PhoneNumber))
            {
                return Result<Employee>.Fail(ErrorCode.ValidationError, "شماره تلفن همراه الزامیست!");
            }

            if (string.IsNullOrWhiteSpace(employee.Address))
            {
                return Result<Employee>.Fail(ErrorCode.ValidationError, "آدرس الزامیست!");
            }

            if (employee.BirthDate == null)
            {
                return Result<Employee>.Fail(ErrorCode.ValidationError, "تاریخ تولد الزامیست!");
            }

            return Result<Employee>.Success(default);
        }

        /// <summary>
        /// اعتبارسنجی با DataAnnotations (برای استفاده در لایه‌های بالاتر)
        /// </summary>
        /// <param name="employee"> موجودیت کارمند</param>
        /// <returns>لیست خطاهای اعتبارسنجی</returns>
        public static List<ValidationResult> ValidateDataAnnotations(Employee employee)
        {
            var context = new ValidationContext(employee, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(employee, context, results, validateAllProperties: true);
            return results;
        }
    }
}
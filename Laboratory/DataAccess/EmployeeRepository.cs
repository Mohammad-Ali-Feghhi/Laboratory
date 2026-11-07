using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using DataAccess.Repositories;
using DataAccess.Services;
using DomainModel.BussinessModel;
using DomainModel.Models;
using DomainModel.Results;
using DomainModel.Validators;

namespace DataAccess
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        private readonly LabContext _db;
        public EmployeeRepository(LabContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        /// <summary>
        /// سازنده پیش‌فرض برای سازگاری با کد موجود - در نسخه‌های آینده حذف خواهد شد
        /// </summary>
        [Obsolete("Use EmployeeRepository(LabContext db) for proper dependency injection")]
        public EmployeeRepository() : this(new LabContext())
        {
        }

        public Result<Employee> AddNewEmployee(Employee emp)
        {
            return Execute(() =>
            {
                var validationResult = EmployeeValidator.ValidateForCreate(emp);
                if (!validationResult.IsSuccess)
                {
                    return validationResult;
                }

                // Check for duplicate username
                var existingUser = _db.Employee.FirstOrDefault(x => x.Username == emp.Username && x.IsDeleted == false);
                if (existingUser != null)
                {
                    return Result<Employee>.Fail(ErrorCode.ValidationError, $" نام کاربری {emp.Username} قبلا ثبت شده است!");
                }

                _db.Employee.Add(emp);
                _db.SaveChanges();
                return Result<Employee>.Success(emp);
            });
        }
        public Result<Employee> UpdateEmployee(Employee newEmp)
        {
            return Execute(() =>
            {
                var oldEmp = _db.Employee.FirstOrDefault(x => x.EmployeeId == newEmp.EmployeeId &&
                                                              x.IsDeleted == false);
                if (oldEmp == null)
                {
                    return Result<Employee>.Fail(ErrorCode.UserNotFound,
                                          @"کاربر پیدا نشد!");
                }

                var validationResult = EmployeeValidator.ValidateForUpdate(newEmp);
                if (!validationResult.IsSuccess)
                {
                    return validationResult;
                }

                oldEmp.EmployeeName = newEmp.EmployeeName;
                oldEmp.Username = newEmp.Username;
                oldEmp.PhoneNumber = newEmp.PhoneNumber;
                oldEmp.Tel = newEmp.Tel;
                oldEmp.Address = newEmp.Address;
                oldEmp.IsEnabled = newEmp.IsEnabled;
                oldEmp.IsUpdated = newEmp.IsUpdated;
                oldEmp.UpdateTime = newEmp.UpdateTime;
                _db.SaveChanges();
                return Result<Employee>.Success(newEmp);
            });
        }
        public Result<Employee> DeleteEmployee(int employeeId)
        {
            return Execute(() =>
            {
                if (_db.TestAcceptionHeader.Any(x => x.RegistrationEmployeeId == employeeId ||
                                                     x.ConfirmationEmployeeId == employeeId))
                {
                    return Result<Employee>.Fail(ErrorCode.ValidationError,
                                          "این کاربر ثبت آزمایش انجام داده است!");
                }

                var user = _db.Employee.FirstOrDefault(x => x.EmployeeId == employeeId &&
                                                            x.IsDeleted == false);
                if (user == null)
                {
                    return Result<Employee>.Fail(ErrorCode.UserNotFound,
                                          "کاربر پیدا نشد!");
                }

                user.IsDeleted = true;
                _db.SaveChanges();
                return Result<Employee>.Success(user);
            });
        }

        public Employee GetEmployeeByEmployeeId(int employeeId)
        {
            return _db.Employee.FirstOrDefault(x => x.EmployeeId == employeeId &&
                                                    x.IsDeleted == false);
        }
        public Employee GetEmployeeByUsername(string username)
        {
            return _db.Employee.FirstOrDefault(x => x.Username == username &&
                                                    x.IsDeleted == false);
        }
        public Result<Employee> ActivateEmployee(int employeeId)
        {
            return Execute(() =>
            {
                var employee = _db.Employee.FirstOrDefault(x => x.EmployeeId == employeeId);
                if (employee == null)
                {
                    return Result<Employee>.Fail(ErrorCode.UserNotFound, "کاربر پیدا نشد!");
                }

                employee.IsEnabled = true;
                _db.SaveChanges();
                return Result<Employee>.Success(employee);
            });
        }
        public Result<Employee> CheckUsernameExists(string username)
        {
            return Execute(() =>
            {
                var exist = _db.Employee.Any(x => x.Username == username &&
                                                  x.IsDeleted == false);
                if (!exist)
                {
                    return Result<Employee>.Success(default);
                }
                var msg = $" نام کاربری {username} قبلا ثبت شده است!";
                return Result<Employee>.Fail(ErrorCode.ValidationError, msg);
            });
        }
        public List<Employee> GetAllEmployees()
        {
            return _db.Employee.AsNoTracking().Where(x => x.IsDeleted == false && x.IsEnabled == true).OrderBy(x => x.EmployeeName).ToList();
        }
        public List<Employee> GetInactiveEmployees()
        {
            return _db.Employee.AsNoTracking().Where(x => x.IsEnabled == false && x.IsDeleted == false).ToList();
        }
        public List<Employee> GetDeletedEmployees()
        {
            return _db.Employee.AsNoTracking().Where(x => x.IsDeleted == true).ToList();
        }
        public List<EmployeeSearchListItem> SearchEmployee(string searchTerm)
        {
            var q = from e in _db.Employee.AsNoTracking()
                where e.EmployeeName.StartsWith(searchTerm) ||
                      e.PhoneNumber.StartsWith(searchTerm) &&
                      e.IsDeleted == false
                select new EmployeeSearchListItem
                {
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.EmployeeName,
                    Username = e.Username,
                    Password = e.Password,
                    PhoneNumber = e.PhoneNumber,
                    Tel = e.Tel,
                    Address = e.Address,
                    BirthDate = e.BirthDate,
                    UpdateTime = e.UpdateTime,
                    IsEnabled = e.IsEnabled,
                    IsUpdated = e.IsUpdated,
                    IsDeleted = e.IsDeleted
                };
            return q.OrderBy(x => x.EmployeeName).ToList();
        }
        public List<LoginHistory> GetAllLoginHistories()
        {
            return _db.LoginHistory.AsNoTracking().OrderByDescending(x => x.LoginHistoryId).ToList();
        }
        public Result<Employee> Login(string username, string password)
        {
            return Execute(() =>
            {
                if (string.IsNullOrWhiteSpace(username))
                {
                    return Result<Employee>.Fail(ErrorCode.ValidationError,
                        "نام کاربری الزامی است!");
                }

                var user = _db.Employee.FirstOrDefault(x => x.Username == username &&
                                                            x.IsDeleted == false &&
                                                            x.IsEnabled == true);
                if (user == null)
                {
                    return Result<Employee>.Fail(ErrorCode.UserNotFound,
                        "کاربر پیدا نشد!");
                }

                if (user.Password != password)
                {
                    return Result<Employee>.Fail(ErrorCode.InvalidPassword,
                        "رمز عبور اشتباه است!");
                }
                return Result<Employee>.Success(user);
            });
        }
        public Result<LoginHistory> AddToLoginHistory(string username)
        {
            return Execute(() =>
            {
                var user = _db.Employee.FirstOrDefault(x => x.Username == username &&
                                                            x.IsDeleted == false &&
                                                            x.IsEnabled == true);
                if (user == null)
                {
                    return Result<LoginHistory>.Fail(ErrorCode.UserNotFound,
                                              "کاربر پیدا نشد!");
                }

                var loginHistory = new LoginHistory
                {
                    EmployeeId = user.EmployeeId,
                    Username = username,
                    LoginDate = DateTime.Now
                };
                _db.LoginHistory.Add(loginHistory);
                _db.SaveChanges();
                return Result<LoginHistory>.Success(loginHistory);
            });
        }
        public Result<LoginHistory> AddToLoginHistoryDatabaseError(LoginHistory log)
        {
            return Execute(() =>
            {
                var user = _db.Employee.FirstOrDefault(x => x.Username == log.Username &&
                                                            x.IsDeleted == false &&
                                                            x.IsEnabled == true);
                if (user == null)
                {
                    return Result<LoginHistory>.Fail(ErrorCode.UserNotFound, "کاربر پیدا نشد!");
                }

                var loginHistory = new LoginHistory
                {
                    EmployeeId = user.EmployeeId,
                    Username = user.Username,
                    Message = log.Message,
                    LoginDate = DateTime.Now
                };
                _db.LoginHistory.Add(loginHistory);
                _db.SaveChanges();
                return Result<LoginHistory>.Success(loginHistory);
            });
        }
        public Result<Employee> ChangePassword(int employeeId, string password)
        {
            return Execute(() =>
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    return Result<Employee>.Fail(ErrorCode.ValidationError,
                                          @"رمز عبور الزامیست!");
                }
                var user = _db.Employee.FirstOrDefault(x => x.EmployeeId == employeeId &&
                                                            x.IsDeleted == false);
                if (user == null)
                {
                    return Result<Employee>.Fail(ErrorCode.UserNotFound,
                                          @"کاربر پیدا نشد!");
                }

                if (password == user.Password)
                {
                    return Result<Employee>.Fail(ErrorCode.InvalidPassword,
                                          @"رمز عبور را قبلاً استفاده کرده‌اید!");
                }
                user.Password = password;
                user.IsUpdated = true;
                user.UpdateTime = DateTime.Now;
                _db.SaveChanges();
                return Result<Employee>.Success(user);
            });
        }
        public bool ValidateLoginAttempt(int employeeId)
        {
            var user = _db.Employee.FirstOrDefault(x => x.EmployeeId == employeeId &&
                                                        x.IsDeleted == false);
            if (user == null)
            {
                return false;
            }

            user.IsEnabled = false;
            _db.SaveChanges();
            return true;
        }
    }
}
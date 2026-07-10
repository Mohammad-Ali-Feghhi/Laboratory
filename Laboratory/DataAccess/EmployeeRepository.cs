using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using DataAccess.Services;
using DomainModel.BussinessModel;
using DomainModel.Models;
using DomainModel.Results;

namespace DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly LabContext _db;
        public EmployeeRepository()
        {
            _db = new LabContext();
        }

        public Result<Employee> AddNewEmployee(Employee emp)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(emp.EmployeeName))
                {
                    return Result<Employee>.Fail(ErrorCode.ValidationError, 
                                          "نام و نام خانوادگی الزامی است!");
                }

                if (string.IsNullOrWhiteSpace(emp.Username))
                {
                    return Result<Employee>.Fail(ErrorCode.ValidationError, 
                                          "نام کاربری الزامی است!");
                }

                if (string.IsNullOrWhiteSpace(emp.Password))
                {
                    return Result<Employee>.Fail(ErrorCode.ValidationError, 
                                          "رمز عبور الزامی است!");
                }

                if (string.IsNullOrWhiteSpace(emp.PhoneNumber))
                {
                    return Result<Employee>.Fail(ErrorCode.ValidationError, 
                                          "شماره تلفن همراه الزامی است!");
                }

                if (string.IsNullOrWhiteSpace(emp.Address))
                {
                    return Result<Employee>.Fail(ErrorCode.ValidationError, 
                                          "آدرس الزامی است!");
                }

                if (emp.BirthDate == null)
                {
                    return Result<Employee>.Fail(ErrorCode.ValidationError, 
                                          "تاریخ تولد الزامی است!");
                }

                _db.Employee.Add(emp);
                _db.SaveChanges();
                return Result<Employee>.Success(emp);
            }
            catch (Exception ex)
            {
                return Result<Employee>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public Result<Employee> UpdateEmployee(Employee newEmp)
        {
            try
            {
                var oldEmp = _db.Employee.FirstOrDefault(x => x.EmployeeId == newEmp.EmployeeId &&
                                                              x.IsDeleted == false);
                if (oldEmp == null)
                {
                    return Result<Employee>.Fail(ErrorCode.UserNotFound, 
                                          @"کاربر پیدا نشد!");
                }

                if (string.IsNullOrWhiteSpace(newEmp.Username))
                {
                    return Result<Employee>.Fail(ErrorCode.ValidationError, "نام کاربری الزامیست!");
                }

                if (string.IsNullOrWhiteSpace(newEmp.EmployeeName))
                {
                    return Result<Employee>.Fail(ErrorCode.ValidationError, "نام و نام خانوادگی الزامیست!");
                }

                if (string.IsNullOrWhiteSpace(newEmp.PhoneNumber))
                {
                    return Result<Employee>.Fail(ErrorCode.ValidationError, "شماره تلفن همراه الزامیست!");
                }

                if (string.IsNullOrWhiteSpace(newEmp.Address))
                {
                    return Result<Employee>.Fail(ErrorCode.ValidationError, "آدرس الزامیست!");
                }

                if (newEmp.BirthDate == null)
                {
                    return Result<Employee>.Fail(ErrorCode.ValidationError, "تاریخ تولد الزامیست!");
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
            }
            catch (Exception ex)
            {
                return Result<Employee>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public Result<Employee> DeleteEmployee(int employeeId)
        {
            try
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
            }
            catch (Exception ex)
            {
                return Result<Employee>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
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
        public Result<Employee> EnableEmployee(int employeeId)
        {
            try
            {
                var employee = _db.Employee.FirstOrDefault(x => x.EmployeeId == employeeId);
                if (employee == null)
                {
                    return Result<Employee>.Fail(ErrorCode.UserNotFound, "کاربر پیدا نشد!");
                }

                employee.IsEnabled = true;
                _db.SaveChanges();
                return Result<Employee>.Success(employee);
            }
            catch (Exception ex)
            {
                return Result<Employee>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public Result<Employee> HasExistUsername(string username)
        {
            try
            {
                var exist = _db.Employee.Any(x => x.Username == username && 
                                                  x.IsDeleted == false);
                if (!exist)
                {
                    return Result<Employee>.Success(default);
                }
                var msg = $" نام کاربری {username} قبلا ثبت شده است!";
                return Result<Employee>.Fail(ErrorCode.ValidationError, msg);
            }
            catch (Exception ex)
            {
                return Result<Employee>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public List<Employee> GetAllEmployees()
        {
            return _db.Employee.Where(x => x.IsDeleted == false).OrderBy(x => x.EmployeeName).ToList();
        }
        public List<Employee> GetAllInactiveEmployees()
        {
            return _db.Employee.Where(x => x.IsEnabled == false && x.IsDeleted == false).ToList();
        }
        public List<Employee> GetAllDeletedEmployees()
        {
            return _db.Employee.Where(x => x.IsDeleted == true).ToList();
        }
        public List<EmployeeSearchListItem> SearchEmployee(string phrase)
        {
            var q = from e in _db.Employee
                where e.EmployeeName.StartsWith(phrase) ||
                      e.PhoneNumber.StartsWith(phrase) &&
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
            return _db.LoginHistory.OrderByDescending(x => x.LoginHistoryId).ToList();
        }
        public Result<Employee> Login(string username, string password)
        {
            try
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
            }
            catch (Exception ex)
            {
                return Result<Employee>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public Result<LoginHistory> AddToLoginHistory(string username)
        {
            try
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
            }
            catch (Exception ex)
            {
                return Result<LoginHistory>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public Result<LoginHistory> AddToLoginHistoryDatabaseError(LoginHistory log)
        {
            try
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
            }
            catch (Exception ex)
            {
                return Result<LoginHistory>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public Result<Employee> ChangePassword(int employeeId, string password)
        {
            try
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
            }
            catch (Exception ex)
            {
                return Result<Employee>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
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

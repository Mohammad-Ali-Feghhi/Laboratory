using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.BussinessModel;
using DomainModel.Models;
using DomainModel.Results;

namespace DataAccess.Services
{
    public interface IEmployeeRepository
    {
        Result<Employee> AddNewEmployee(Employee emp);
        Result<Employee> UpdateEmployee(Employee newEmp);
        Result<Employee> DeleteEmployee(int employeeId);
        Employee GetEmployeeByEmployeeId(int employeeId);
        Employee GetEmployeeByUsername(string username);
        Result<Employee> ActivateEmployee(int employeeId);
        Result<Employee> CheckUsernameExists(string username);
        List<Employee> GetAllEmployees();
        List<Employee> GetInactiveEmployees();
        List<Employee> GetDeletedEmployees();
        List<EmployeeSearchListItem> SearchEmployee(string searchTerm);
        List<LoginHistory> GetAllLoginHistories();
        Result<Employee> Login(string username, string password);
        Result<LoginHistory> AddToLoginHistory(string username);
        Result<LoginHistory> AddToLoginHistoryDatabaseError(LoginHistory log);
        Result<Employee> ChangePassword(int employeeId, string password);
        bool ValidateLoginAttempt(int employeeId);
    }
}

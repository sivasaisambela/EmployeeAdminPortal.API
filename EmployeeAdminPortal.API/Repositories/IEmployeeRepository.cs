using EmployeeAdminPortal.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAdminPortal.API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesAsync();

        Task<Employee> GetEmpployeeByIdAsync(Guid employeeId);

        Task<List<Gender>> GetGendersAsync();

        Task<bool> Exists(Guid employeeId);

        Task<Employee> UpdateEmployee(Guid employeeId, Employee empToUpdate);
    }
}

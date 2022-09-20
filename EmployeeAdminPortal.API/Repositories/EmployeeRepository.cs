using EmployeeAdminPortal.API.Data;
using EmployeeAdminPortal.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAdminPortal.API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeAdminContext _context;

        public EmployeeRepository(EmployeeAdminContext context)
        {
            _context = context;
        }

        public async Task<bool> Exists(Guid employeeId)
        {
            return await _context.Employees.AnyAsync(x => x.Id == employeeId);
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
           return await _context.Employees.Include(nameof(Address)).Include(nameof(Department)).Include(nameof(Gender)).ToListAsync();
        }

        public async Task<Employee> GetEmpployeeByIdAsync(Guid employeeId)
        {
            return await _context.Employees
                  .Include(nameof(Address)).Include(nameof(Department)).Include(nameof(Gender))
                  .FirstOrDefaultAsync(x => x.Id == employeeId);
        }

        public async Task<List<Gender>> GetGendersAsync()
        {
           return await _context.Gender.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Guid employeeId, Employee emp)
        {
            var existingEmployee = await GetEmpployeeByIdAsync(employeeId);

            if(existingEmployee!=null)
            {
                existingEmployee.FirstName = emp.FirstName;
                existingEmployee.LastName = emp.LastName;
                existingEmployee.DateOfBirth = emp.DateOfBirth;
                existingEmployee.Email = emp.Email;
                existingEmployee.Mobile = emp.Mobile;
                existingEmployee.GenderId = emp.GenderId;
                existingEmployee.Address.PhysicalAddress = emp.Address.PhysicalAddress;
                existingEmployee.Address.PostalAddress = emp.Address.PostalAddress;

                await _context.SaveChangesAsync();
                return existingEmployee;

            }
            return null;
        }
    }
}

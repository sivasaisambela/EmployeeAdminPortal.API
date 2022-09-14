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
        public async Task<List<Employee>> GetEmployeesAsync()
        {
           return await _context.Employees.Include(nameof(Address)).Include(nameof(Department)).ToListAsync();
        }
    }
}

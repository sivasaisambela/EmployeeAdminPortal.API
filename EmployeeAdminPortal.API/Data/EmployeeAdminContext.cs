using EmployeeAdminPortal.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAdminPortal.API.Data
{
    public class EmployeeAdminContext : DbContext
    {
        public EmployeeAdminContext(DbContextOptions<EmployeeAdminContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Gender> Gender { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Address> Address { get; set; }

        
    }
}

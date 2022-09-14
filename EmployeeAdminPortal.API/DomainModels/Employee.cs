using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAdminPortal.API.DomainModels
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public long Mobile { get; set; }

        public string ProfileImageUrl { get; set; }

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }

        public Address Address { get; set; }
    }
}

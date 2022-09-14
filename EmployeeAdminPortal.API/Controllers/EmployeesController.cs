using AutoMapper;
using EmployeeAdminPortal.API.DomainModels;
using EmployeeAdminPortal.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAdminPortal.API.Controllers
{
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _context;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var emps = await _context.GetEmployeesAsync();

            _mapper.Map<List<Employee>>(emps);


            //var domainModelEmps = new List<Employee>();
            //foreach(var e in emps)
            //{
            //    domainModelEmps.Add(new Employee()
            //    {
            //        Id = e.Id,
            //        FirstName = e.FirstName,
            //        LastName = e.LastName,
            //        DateOfBirth = e.DateOfBirth,
            //        Email = e.Email,
            //        Mobile = e.Mobile,
            //        ProfileImageUrl = e.ProfileImageUrl,

            //        DepartmentId = e.DepartmentId,
            //        Address = new Address()
            //        {
            //            Id=e.Address.Id,
            //            PhysicalAddress = e.Address.PhysicalAddress,
            //            PostalAddress = e.Address.PostalAddress,


            //        },
            //        Department = new Department()
            //        {
            //            Id=e.Department.Id,
            //            Name = e.Department.Name
            //        }
            //    });
            //}
            //return Ok(domainModelEmps);
            return Ok(_mapper.Map<List<Employee>>(emps));

        }
    }
}

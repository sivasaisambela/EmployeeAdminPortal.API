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

        public EmployeesController(IEmployeeRepository context, IMapper mapper)
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



            return Ok(_mapper.Map<List<Employee>>(emps));


        }


        [HttpGet]
        [Route("[controller]/{employeeId:guid}")]
        public async Task<IActionResult> GetEmpployeeByIdAsync([FromRoute] Guid employeeId)
        {
            var employee = await _context.GetEmpployeeByIdAsync(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Employee>(employee));
        }

        [HttpPut]
        [Route("[controller]/{employeeId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid employeeId, [FromBody] updateEmpRequest updateEmp)
        {

            if (await _context.Exists(employeeId))
            {
                var updatedEmployee = await _context.UpdateEmployee(employeeId, _mapper.Map<EmployeeAdminPortal.API.Models.Employee>(updateEmp));
                if (updatedEmployee != null)
                {
                    return Ok(_mapper.Map<Employee>(updatedEmployee));
                }
            }

            return NotFound();

        }
    }
}

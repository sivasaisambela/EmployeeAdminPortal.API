using AutoMapper;
using EmployeeAdminPortal.API.DomainModels;
using EmployeeAdminPortal.API.Models;
using EmployeeAdminPortal.API.Profiles.AfterMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Address = EmployeeAdminPortal.API.Models.Address;
using Department = EmployeeAdminPortal.API.Models.Department;
using Employee = EmployeeAdminPortal.API.Models.Employee;
using Gender = EmployeeAdminPortal.API.Models.Gender;

namespace EmployeeAdminPortal.API.Profiles
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DomainModels.Employee, Employee>().ReverseMap();

            CreateMap<DomainModels.Department, Department>().ReverseMap();

            CreateMap<DomainModels.Address, Address>().ReverseMap();

            CreateMap<DomainModels.Gender, Gender>().ReverseMap();

            CreateMap<updateEmpRequest, Employee>().AfterMap<UpdateEmployeeRequestAfterMap>();
                
        }
    }
}

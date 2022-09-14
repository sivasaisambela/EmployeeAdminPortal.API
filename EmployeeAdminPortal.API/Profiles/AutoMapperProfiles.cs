using AutoMapper;
using EmployeeAdminPortal.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAdminPortal.API.Profiles
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DomainModels.Employee, Employee>().ReverseMap();

            CreateMap<DomainModels.Department, Department>().ReverseMap();

            CreateMap<DomainModels.Address, Address>().ReverseMap();
            
        }
    }
}

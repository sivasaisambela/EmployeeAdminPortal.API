﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAdminPortal.API.DomainModels
{
    public class Address
    {
        public Guid Id { get; set; }

        public string PhysicalAddress { get; set; }

        public string PostalAddress { get; set; }

        public Guid EmployeeId { get; set; }
    }
}

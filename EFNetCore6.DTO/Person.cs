﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EFNetCore6.Auxiliary.DTO;
using EFNetCore6.Auxiliary.DAL;

namespace EFNetCore6.DTO
{
    public class Person : DTOBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid? PositionId { get; set; }
    }
}

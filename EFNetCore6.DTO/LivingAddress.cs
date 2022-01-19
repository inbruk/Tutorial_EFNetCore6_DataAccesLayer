using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EFNetCore6.Auxiliary.DTO;
using EFNetCore6.Auxiliary.DAL;

namespace EFNetCore6.DTO
{
    public class LivingAddress : DTOBase
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string Locality { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int Apartment { get; set; }
        public Guid PersonId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNetCore6.DTO
{
    public class VwPersonCarLivingAddress
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Body { get; set; }
        public int DoorsCount { get; set; }
        public int Power { get; set; }
        public Guid LivingAddressId { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Locality { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int Apartment { get; set; }
    }
}

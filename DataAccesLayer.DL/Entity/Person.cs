using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO = Migs.DTO;

namespace Migs.DL.Entity
{
    public class Person : DTO.Person
    {
        public List<Car> Cars { get; } = new List<Car>();
        public List<LivingAddress> LivingAddresses { get; } = new List<LivingAddress>();
    }
}

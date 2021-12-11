using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Migs.Auxiliary;

namespace Migs.DTO
{
    public class Car : DTOBase
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Body { get; set; }
        public int DoorsCount { get; set; }
        public int Power { get; set; }
        public Guid PersonId { get; set; }
    }
}

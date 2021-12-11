using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO = Migs.DTO;

namespace Migs.DL.Entity
{
    public class Car : DTO.Car
    {
        public Person Person { get; set; }
    }
}

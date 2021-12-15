using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNetCore6.Auxiliary.DI
{
    public interface ISimpleFactory<I>
    {
        I Create();
    }
}

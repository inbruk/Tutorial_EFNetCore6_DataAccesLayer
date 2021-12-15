using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNetCore6.Auxiliary.DI
{
    public class SimpleFactory<I,T>: ISimpleFactory<I>
        where T : class, I, new()
    {
        public I Create()
        {
            return new T();
        }
    }
}

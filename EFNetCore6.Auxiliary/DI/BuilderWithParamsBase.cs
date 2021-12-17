using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNetCore6.Auxiliary.DI
{
    public class BuilderWithParamsBase<I,T>
    {
        protected virtual I CheckNullAndConvert(object? obj) => (I)( obj ?? throw new CantCreateObjectException(typeof(T).Name) );
    }
}

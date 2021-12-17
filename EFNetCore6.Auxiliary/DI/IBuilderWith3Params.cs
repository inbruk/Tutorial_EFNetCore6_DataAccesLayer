using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNetCore6.Auxiliary.DI
{
    internal interface IBuilderWith3Params<T, P1, P2, P3> : ISimpleFactory<T>
    {
        P1? Param1 { get; set; }
        P2? Param2 { get; set; }
        P3? Param3 { get; set; }
    }
}

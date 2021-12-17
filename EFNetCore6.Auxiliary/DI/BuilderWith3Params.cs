using System;

namespace EFNetCore6.Auxiliary.DI
{
    public class BuilderWith3Params<I, T, P1, P2, P3> : BuilderWith2Params<I, T, P1, P2>, IBuilderWith3Params<I, P1, P2, P3>, ISimpleFactory<I>
        where T : class, I, new()
    {
        public P3? Param3 { get; set; }
        public override I Create() => CheckNullAndConvert(Activator.CreateInstance(typeof(T), Param1, Param2, Param3));
    }
}

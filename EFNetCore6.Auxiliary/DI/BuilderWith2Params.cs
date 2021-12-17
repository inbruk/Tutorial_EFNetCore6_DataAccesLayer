using System;

namespace EFNetCore6.Auxiliary.DI
{
    public class BuilderWith2Params<I, T, P1, P2> : BuilderWith1Params<I, T, P1>, IBuilderWith2Params<I, P1, P2>, ISimpleFactory<I>
        where T : class, I, new()
    {
        public P2? Param2 { get; set; }
        public override I Create() => CheckNullAndConvert(Activator.CreateInstance(typeof(T), Param1, Param2));
    }
}

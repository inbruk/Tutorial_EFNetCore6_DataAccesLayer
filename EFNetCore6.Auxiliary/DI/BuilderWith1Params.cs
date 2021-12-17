using System;

namespace EFNetCore6.Auxiliary.DI
{
    public class BuilderWith1Params<I,T,P1>: BuilderWithParamsBase<I, T>, IBuilderWith1Params<I, P1>, ISimpleFactory<I>
        where T : class, I, new()
    {
        public P1? Param1 { get; set; }
        public virtual I Create() => CheckNullAndConvert( Activator.CreateInstance(typeof(T), Param1) );
    }
}

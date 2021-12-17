namespace EFNetCore6.Auxiliary.DI
{
    public interface IBuilderWith1Params<I,P1>: ISimpleFactory<I>
    {
        P1? Param1 { get; set; }
    }
}

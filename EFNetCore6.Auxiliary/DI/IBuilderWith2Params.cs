namespace EFNetCore6.Auxiliary.DI
{
    public interface IBuilderWith2Params<T, P1, P2> : ISimpleFactory<T>
    {
        P1? Param1 { get; set; }
        P2? Param2 { get; set; }
    }
}

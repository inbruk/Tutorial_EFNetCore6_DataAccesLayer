namespace EFNetCore6.Auxiliary.DI
{
    public class SimpleFactory<I,T>: ISimpleFactory<I>
        where T : class, I, new()
    {
        public I Create() => new T();
    }
}

namespace EFNetCore6.Auxiliary.DI
{
    [Serializable]
    public class CantCreateObjectException : Exception
    {
        public CantCreateObjectException(string typeName)
            : base(@"Can't create object of {typeName} type")
        {
        }
    }
}

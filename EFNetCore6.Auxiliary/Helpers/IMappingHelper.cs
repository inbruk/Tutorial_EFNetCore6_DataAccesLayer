namespace EFNetCore6.Auxiliary.Helpers
{
    public interface IMappingHelper
    {
        void SetMaps(List<Tuple<Type, Type>> listOfMaps);
        DSTT Map<SRCT, DSTT>(SRCT src);
    }
}

namespace EFNetCore6.Auxiliary.Helpers
{
    public interface IMappingHelper
    {
        void AddMaps(List<(Type, Type)> listOfMaps);
        void Configure();
        DSTT Map<SRCT, DSTT>(SRCT src);
        List<DSTT> Map<SRCT, DSTT>(List<SRCT> src);
    }
}

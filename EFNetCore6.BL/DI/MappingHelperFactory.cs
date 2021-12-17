using EFNetCore6.Auxiliary.Helpers;
using EFNetCore6.Auxiliary.DI;

namespace EFNetCore6.BL.DI
{
    public class MappingHelperFactory : SimpleFactory<IMappingHelper, MappingHelper>, ISimpleFactory<IMappingHelper>
    {
    }
}

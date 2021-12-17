using EFNetCore6.Auxiliary.Helpers;
using EFNetCore6.Auxiliary.DI;

namespace EFNetCore6.DL.DI
{
    public class ConfigurationHelperFactory : SimpleFactory<IConfigurationHelper, ConfigurationHelper>, ISimpleFactory<IConfigurationHelper>
    {
    }
}

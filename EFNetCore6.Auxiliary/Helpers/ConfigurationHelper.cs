using Microsoft.Extensions.Configuration;

namespace EFNetCore6.Auxiliary.Helpers
{
    public class ConfigurationHelper : IConfigurationHelper
    {
        private const string appSettingsFileName = "app_settings.json";
        private IConfigurationRoot _confRoot;

        public ConfigurationHelper()
        {
            var builder = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile(appSettingsFileName, optional: true, reloadOnChange: true);

            _confRoot = builder.Build();
        }

        public virtual string GetItem(string section, string item)
        {
            if (string.IsNullOrEmpty(section))
                throw new ArgumentNullException(nameof(section));

            if (string.IsNullOrEmpty(item))
                throw new ArgumentNullException(nameof(item));

            var result = _confRoot.GetSection(section)[item];
            if (string.IsNullOrEmpty(item))
                throw new NotExistedConfigurationItemException(section, item);

            return (String)result;
        }
    }
}
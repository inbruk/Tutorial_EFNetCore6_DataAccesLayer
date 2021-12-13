using Microsoft.Extensions.Configuration;

namespace EFNetCore6.Auxiliary.Helpers
{
    public static class Configuration
    {
        private const string appSettingsFileName = "app_settings.json";
        private static IConfigurationRoot _confRoot;

        static Configuration()
        {
            var builder = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile(appSettingsFileName, optional: true, reloadOnChange: true);

            _confRoot = builder.Build();
        }

        public static string GetItem(string section, string item)
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
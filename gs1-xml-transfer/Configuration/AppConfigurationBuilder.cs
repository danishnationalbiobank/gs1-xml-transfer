using Microsoft.Extensions.Configuration;

namespace Gs1XmlTransfer.Configuration
{
    static class AppConfigurationBuilder
    {
        private static IConfiguration? _currentConfig;

        private static void Build()
        {
            string environment = String.Empty;

#if DEBUG
            environment = "Development";
#else
environment = "Production";
#endif

            _currentConfig = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true, true)
            .AddJsonFile($"appsettings.{environment}.json", true, true)
            .AddEnvironmentVariables()
            .Build();
        }

        public static IConfiguration Get()
        {
            if (_currentConfig is null)
            {
                Build();
            }
            return _currentConfig;
        }
    }
}
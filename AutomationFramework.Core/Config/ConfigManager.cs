using Microsoft.Extensions.Configuration;

namespace AutomationFramework.Core.Config;

public static class ConfigManager
{
    private static IConfiguration? _configuration;

    public static IConfiguration GetConfiguration()
    {
        if (_configuration != null)
        {
            return _configuration;
        }

        _configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        return _configuration;
    }
}
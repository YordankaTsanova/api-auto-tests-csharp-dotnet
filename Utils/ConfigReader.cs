using Microsoft.Extensions.Configuration;
using System.IO;

namespace ApiTestDemo.Utils
{
    public static class ConfigReader
    {
        private static readonly IConfigurationRoot Configuration;

        static ConfigReader()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static string BaseUrl => GetRequiredSetting("BaseUrl", "API_BASE_URL");

        public static string AdminUsername => GetRequiredSetting("AdminCredentials:Username", "API_ADMIN_USERNAME");

        public static string AdminPassword => GetRequiredSetting("AdminCredentials:Password", "API_ADMIN_PASSWORD");

        private static string GetRequiredSetting(string configKey, string envVarName)
        {
            var value = Environment.GetEnvironmentVariable(envVarName);
            if (string.IsNullOrWhiteSpace(value))
            {
                value = Configuration[configKey];
            }

            return string.IsNullOrWhiteSpace(value)
                ? throw new InvalidOperationException($"{configKey} is missing from appsettings.json or environment variables")
                : value;
        }
    }
}
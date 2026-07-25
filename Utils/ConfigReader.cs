using Microsoft.Extensions.Configuration;
using System.IO;

namespace ApiTestDemo.Utils
{
    public static class ConfigReader
    {
        private static readonly IConfigurationRoot Configuration;

        static ConfigReader()
        {
            // Locates appsettings.json in the execution directory
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static string BaseUrl => Configuration["BaseUrl"] 
        ?? throw new InvalidOperationException("BaseUrl is missing from appsettings.json");

        public static string AdminUsername => Configuration["AdminCredentials:Username"] 
        ?? throw new InvalidOperationException("AdminCredentials:Username is missing from appsettings.json");

        public static string AdminPassword => Configuration["AdminCredentials:Password"] 
        ?? throw new InvalidOperationException("AdminCredentials:Password is missing from appsettings.json");
    }
}
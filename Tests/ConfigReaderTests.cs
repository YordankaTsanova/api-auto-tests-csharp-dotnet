using NUnit.Framework;
using ApiTestDemo.Utils;

namespace ApiTestDemo.Tests
{
    [TestFixture]
    public class ConfigReaderTests
    {
        [Test]
        public void ConfigReader_UsesEnvironmentVariables_WhenProvided()
        {
            var originalBaseUrl = Environment.GetEnvironmentVariable("API_BASE_URL");
            var originalUsername = Environment.GetEnvironmentVariable("API_ADMIN_USERNAME");
            var originalPassword = Environment.GetEnvironmentVariable("API_ADMIN_PASSWORD");

            try
            {
                Environment.SetEnvironmentVariable("API_BASE_URL", "https://example.test");
                Environment.SetEnvironmentVariable("API_ADMIN_USERNAME", "env-user");
                Environment.SetEnvironmentVariable("API_ADMIN_PASSWORD", "env-password");

                Assert.That(ConfigReader.BaseUrl, Is.EqualTo("https://example.test"));
                Assert.That(ConfigReader.AdminUsername, Is.EqualTo("env-user"));
                Assert.That(ConfigReader.AdminPassword, Is.EqualTo("env-password"));
            }
            finally
            {
                Environment.SetEnvironmentVariable("API_BASE_URL", originalBaseUrl);
                Environment.SetEnvironmentVariable("API_ADMIN_USERNAME", originalUsername);
                Environment.SetEnvironmentVariable("API_ADMIN_PASSWORD", originalPassword);
            }
        }
    }
}

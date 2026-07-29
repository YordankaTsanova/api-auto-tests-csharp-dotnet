using NUnit.Framework;
using ApiTestDemo.Utils;

namespace ApiTestDemo.Tests
{
    [TestFixture]
    public class LoggingTests
    {
        [Test]
        public void Logger_CreatesLogFile_ForFailureMessage()
        {
            var scenario = "sample failure";
            var message = "This is a sample failure message";

            TestLogger.LogFailure(scenario, message);

            var logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            Assert.That(Directory.Exists(logDirectory), Is.True);
            Assert.That(Directory.GetFiles(logDirectory).Length, Is.GreaterThan(0));
        }
    }
}

using NUnit.Framework;
using ApiTestDemo.Endpoints;
using ApiTestDemo.Models;
using ApiTestDemo.Utils;
using System.Threading.Tasks;

namespace ApiTestDemo.Tests
{
    [TestFixture]
    public class AuthTests
    {
        [Test]
        public async Task Authenticate_WithValidCredentials_ShouldSucceed()
        {
            var authPayload = TestDataLoader.LoadJson<AuthModel>("authPayload.json");

            Assert.That(authPayload.Username, Is.EqualTo("admin"));
            Assert.That(authPayload.Password, Is.EqualTo("password123"));

            var authClient = new AuthClient();
            var response = await authClient.PostAuthTokenAsync(authPayload);

            TestAssertions.AssertSuccessfulResponse(response, "Authentication request");
        }
    }
}
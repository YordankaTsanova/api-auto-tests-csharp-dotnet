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
        public async Task TestAuthentication()
        {
            var authPayload = TestDataLoader.LoadJson<AuthModel>("authPayload.json");

            Assert.That(authPayload.Username, Is.EqualTo("admin"));
            Assert.That(authPayload.Password, Is.EqualTo("password123"));

            var authClient = new AuthClient();
            var response = await authClient.PostAuthTokenAsync(authPayload);

            Assert.That(response.IsSuccessful, Is.True, $"Auth failed with status: {response.StatusCode}");
            Assert.That((int)response.StatusCode, Is.EqualTo(200));
        }
    }
}
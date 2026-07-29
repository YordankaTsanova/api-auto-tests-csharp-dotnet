using NUnit.Framework;
using ApiTestDemo.Endpoints;
using ApiTestDemo.Models;
using ApiTestDemo.Utils;

namespace ApiTestDemo.Tests
{
    [TestFixture]
    public class AuthErrorTests : TestBase
    {
        [Test]
        public async Task Authenticate_WithInvalidCredentials_ShouldStillReturnOk()
        {
            var invalidPayload = new AuthModel
            {
                Username = "invalid-user",
                Password = "invalid-password"
            };

            var authClient = new AuthClient();
            var response = await authClient.PostAuthTokenAsync(invalidPayload);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(response.Content, Is.Not.Null.And.Not.Empty);
        }
    }
}

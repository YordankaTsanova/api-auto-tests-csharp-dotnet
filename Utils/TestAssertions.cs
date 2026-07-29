using NUnit.Framework;
using RestSharp;

namespace ApiTestDemo.Utils
{
    public static class TestAssertions
    {
        public static void AssertSuccessfulResponse(RestResponse response, string scenario)
        {
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessful, Is.True, $"{scenario} failed with status: {response.StatusCode}");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), $"{scenario} should return HTTP 200 OK");
            });
        }

        public static void AssertResponseStatus(RestResponse response, System.Net.HttpStatusCode expectedStatusCode, string scenario)
        {
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(expectedStatusCode), $"{scenario} returned unexpected status code");
                Assert.That(response.IsSuccessful, Is.False, $"{scenario} should not be successful for this case");
            });
        }
    }
}

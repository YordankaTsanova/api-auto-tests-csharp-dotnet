using RestSharp;
using ApiTestDemo.Models;
using ApiTestDemo.Utils;

namespace ApiTestDemo.Endpoints
{
    public class AuthClient
    {
        private readonly RestClient _client;

        public AuthClient()
        {
            _client = new RestClient(ConfigReader.BaseUrl);
        }

        public async Task<RestResponse> PostAuthTokenAsync(AuthModel payload)
        {
            var request = new RestRequest("/auth", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(payload);

            return await _client.ExecuteAsync(request);
        }
    }
}
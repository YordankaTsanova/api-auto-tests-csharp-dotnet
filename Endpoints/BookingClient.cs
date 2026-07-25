using System.Threading.Tasks;
using RestSharp;
using ApiTestDemo.Models;
using ApiTestDemo.Utils;

namespace ApiTestDemo.Endpoints
{
    public class BookingClient
    {
        private readonly RestClient _client;

        public BookingClient()
        {
            _client = new RestClient(ConfigReader.BaseUrl);
        }

        public async Task<RestResponse> CreateBookingAsync(BookingModel payload)
        {
            var request = new RestRequest("/booking", Method.Post);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(payload);

            return await _client.ExecuteAsync(request);
        }
    }
}
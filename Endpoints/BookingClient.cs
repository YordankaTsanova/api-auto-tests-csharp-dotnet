using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using ApiTestDemo.Models;
using ApiTestDemo.Utils;
using System;

namespace ApiTestDemo.Endpoints
{
    public class BookingClient
    {
        private readonly RestClient _client;

        public BookingClient()
        {
            _client = new RestClient(ConfigReader.BaseUrl);
        }

        // 1. Get all booking IDs -> returns List<BookingIdModel>
        public async Task<RestResponse<List<BookingIdModel>>> GetBookingIdsAsync()
        {
            var request = new RestRequest("/booking", Method.Get);
            request.AddHeader("Accept", "application/json");

            var response = await _client.ExecuteAsync<List<BookingIdModel>>(request);
            LogResponse("Get booking IDs", response);
            return response;
        }

        // 1b. Get filtered booking IDs using query parameters
        public async Task<RestResponse<List<BookingIdModel>>> GetBookingIdsWithFilterAsync(BookingFilterModel filter)
        {
            var request = new RestRequest("/booking", Method.Get);
            request.AddHeader("Accept", "application/json");

            if (!string.IsNullOrEmpty(filter.Firstname))
                request.AddQueryParameter("firstname", filter.Firstname);

            if (!string.IsNullOrEmpty(filter.Lastname))
                request.AddQueryParameter("lastname", filter.Lastname);

            return await _client.ExecuteAsync<List<BookingIdModel>>(request);
        }

        // 2. Get booking details by ID -> returns BookingModel
        public async Task<RestResponse<BookingModel>> GetBookingByIdAsync(int bookingId)
        {
            var request = new RestRequest($"/booking/{bookingId}", Method.Get);
            request.AddHeader("Accept", "application/json");

            var response = await _client.ExecuteAsync<BookingModel>(request);
            LogResponse($"Get booking by ID {bookingId}", response);
            return response;
        }

        // 3. Create booking -> returns BookingResponseModel (wrapper with Bookingid & Booking)
        public async Task<RestResponse<BookingResponseModel>> CreateBookingAsync(BookingModel payload)
        {
            var request = new RestRequest("/booking", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(payload);

            var response = await _client.ExecuteAsync<BookingResponseModel>(request);
            LogResponse("Create booking", response);
            return response;
        }

        // 4. Update booking (PUT) -> returns updated BookingModel
        public async Task<RestResponse<BookingModel>> UpdateBookingAsync(int bookingId, BookingModel payload, string token)
        {
            var request = new RestRequest($"/booking/{bookingId}", Method.Put);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", $"token={token}");

            request.AddJsonBody(payload);

            return await _client.ExecuteAsync<BookingModel>(request);
        }

        // 5. Partial update booking (PATCH) -> returns updated BookingModel
        // Added 'where T : class' constraint to fix error CS0452 with RestSharp's AddJsonBody
        public async Task<RestResponse<BookingModel>> PartialUpdateBookingAsync<T>(int bookingId, T partialPayload, string token) where T : class
        {
            var request = new RestRequest($"/booking/{bookingId}", Method.Patch);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", $"token={token}");

            request.AddJsonBody(partialPayload);

            return await _client.ExecuteAsync<BookingModel>(request);
        }

        // 6. Delete booking (DELETE) -> returns raw RestResponse (201 Created on success, no JSON body)
        public async Task<RestResponse> DeleteBookingAsync(int bookingId, string token)
        {
            var request = new RestRequest($"/booking/{bookingId}", Method.Delete);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", $"token={token}");

            var response = await _client.ExecuteAsync(request);
            LogResponse($"Delete booking {bookingId}", response);
            return response;
        }

        private static void LogResponse(string scenario, RestResponse response)
        {
            if (response is null)
            {
                return;
            }

            var message = $"Status: {(int)response.StatusCode} {response.StatusCode}\nContent: {response.Content ?? "<empty>"}";
            TestLogger.LogFailure(scenario, message);
        }
    }
}
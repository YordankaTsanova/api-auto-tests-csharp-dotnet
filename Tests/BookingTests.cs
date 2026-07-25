using NUnit.Framework;
using ApiTestDemo.Endpoints; // Ensure your BookingClient namespace is included
using ApiTestDemo.Models;
using ApiTestDemo.Utils;

namespace ApiTestDemo.Tests
{
    [TestFixture]
    public class BookingTests
    {
        private BookingClient _bookingClient;

        [SetUp]
        public void Setup()
        {
            // Initialize your client before each test runs
            _bookingClient = new BookingClient();
        }

        [Test]
        public async Task TestCreateBooking()
        {
            // 1. Load payload from TestData/createBookingPayload.json
            var bookingPayload = TestDataLoader.LoadJson<BookingModel>("createBookingPayload.json");

            // 2. Validate local JSON payload data
            Assert.That(bookingPayload.Firstname, Is.EqualTo("Jim"));
            Assert.That(bookingPayload.Totalprice, Is.EqualTo(111));

            // 3. Send the POST request to the API
            var response = await _bookingClient.CreateBookingAsync(bookingPayload);

            // 4. Assert HTTP status code and response success
            Assert.That(response.IsSuccessful, Is.True, $"Request failed with status code: {response.StatusCode}");
            Assert.That((int)response.StatusCode, Is.EqualTo(200));
        }
    }
}
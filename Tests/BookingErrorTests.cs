using NUnit.Framework;
using ApiTestDemo.Endpoints;
using ApiTestDemo.Models;
using ApiTestDemo.Utils;

namespace ApiTestDemo.Tests
{
    [TestFixture]
    public class BookingErrorTests : TestBase
    {

        [Test]
        public async Task GetBookingById_WithUnknownId_ShouldReturnNotFound()
        {
            var response = await BookingClient.GetBookingByIdAsync(99999999);

            TestAssertions.AssertResponseStatus(response, System.Net.HttpStatusCode.NotFound, "Get booking by ID");
        }

        [Test]
        public async Task CreateBooking_AcceptsIncompletePayload_AndReturnsOk()
        {
            var incompletePayload = new BookingModel
            {
                Firstname = string.Empty,
                Lastname = string.Empty,
                Totalprice = 0,
                Depositpaid = false,
                Bookingdates = new BookingDates
                {
                    Checkin = "2024-01-01",
                    Checkout = "2024-01-02"
                }
            };

            var response = await BookingClient.CreateBookingAsync(incompletePayload);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
        }
    }
}

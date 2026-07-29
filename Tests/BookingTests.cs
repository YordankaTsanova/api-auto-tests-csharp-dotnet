using NUnit.Framework;
using ApiTestDemo.Endpoints;
using ApiTestDemo.Models;
using ApiTestDemo.Utils;

namespace ApiTestDemo.Tests
{
    [TestFixture]
    public class BookingTests : TestBase
    {

        [Test]
        public async Task CreateBooking_WithValidPayload_ShouldReturnCreatedBooking()
        {
            var bookingPayload = TestDataLoader.LoadJson<BookingModel>("createBookingPayload.json");

            Assert.That(bookingPayload.Firstname, Is.EqualTo("Jim"));
            Assert.That(bookingPayload.Totalprice, Is.EqualTo(111));

            var response = await BookingClient.CreateBookingAsync(bookingPayload);

            TestAssertions.AssertSuccessfulResponse(response, "Create booking request");

            Assert.That(response.Data, Is.Not.Null, "Response body should not be null");
            Assert.That(response.Data.Bookingid, Is.GreaterThan(0), "API should generate a positive booking ID");
            Assert.That(response.Data.Booking.Firstname, Is.EqualTo(bookingPayload.Firstname));
            Assert.That(response.Data.Booking.Lastname, Is.EqualTo(bookingPayload.Lastname));
        }

        [Test]
        public async Task GetBookingIds_ShouldReturnAListOfBookingIds()
        {
            var response = await BookingClient.GetBookingIdsAsync();

            TestAssertions.AssertSuccessfulResponse(response, "Get booking IDs request");

            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data, Is.Not.Empty, "Expected booking IDs list to contain items.");
            Assert.That(response.Data[0].Bookingid, Is.GreaterThan(0));
        }
    }
}
using NUnit.Framework;
using ApiTestDemo.Models;
using ApiTestDemo.Utils;

namespace ApiTestDemo.Tests
{
    [TestFixture]
    public class BookingFlowTests : TestBase
    {
        [Test]
        public async Task CreateBooking_AndRetrieveItById_ShouldSucceed()
        {
            var bookingPayload = TestDataLoader.LoadJson<BookingModel>("createBookingPayload.json");

            var createResponse = await BookingClient.CreateBookingAsync(bookingPayload);
            TestAssertions.AssertSuccessfulResponse(createResponse, "Create booking request");

            Assert.That(createResponse.Data, Is.Not.Null);
            Assert.That(createResponse.Data.Bookingid, Is.GreaterThan(0));

            var getResponse = await BookingClient.GetBookingByIdAsync(createResponse.Data.Bookingid);
            TestAssertions.AssertSuccessfulResponse(getResponse, "Get booking by ID request");

            Assert.That(getResponse.Data, Is.Not.Null);
            Assert.That(getResponse.Data.Firstname, Is.EqualTo(bookingPayload.Firstname));
            Assert.That(getResponse.Data.Lastname, Is.EqualTo(bookingPayload.Lastname));
        }
    }
}

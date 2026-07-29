using ApiTestDemo.Endpoints;

namespace ApiTestDemo.Tests
{
    public class TestBase
    {
        protected BookingClient BookingClient { get; private set; } = null!;

        [NUnit.Framework.SetUp]
        public void BaseSetup()
        {
            BookingClient = new BookingClient();
        }
    }
}

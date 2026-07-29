namespace ApiTestDemo.Models
{
    public class BookingResponseModel
    {
        public int Bookingid { get; set; }
        public BookingModel Booking { get; set; } = new();
    }
}
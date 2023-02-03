namespace Booking.API.ViewModels.Booking
{
    public class CreateBookingViewModel
    {
        public decimal Price { get; set; }
        public DateTime BookingFrom { get; set; }
        public DateTime BookingTo { get; set; }
        public string? Description { get; set; }
    }
}

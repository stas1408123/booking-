namespace Booking.API.ViewModels;

public class GetParticularBookingsViewModel
{
    public DateTime BookingFrom { get; set; }
    public DateTime BookingTo { get; set; }
    public Guid HotelId { get; set; }
}
namespace Booking.API.ViewModels;

public class BookingViewModel
{
    public decimal Price { get; set; }
    public DateTime BookingFrom { get; set; }
    public DateTime BookingTo { get; set; }
    public string? Description { get; set; }
    public Guid? HotelId { get; set; }
}
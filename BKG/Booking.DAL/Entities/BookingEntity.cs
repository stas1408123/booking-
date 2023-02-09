namespace Booking.DAL.Entities;

public class BookingEntity : BaseEntity
{
    public decimal Price { get; set; }
    public DateTime BookingFrom { get; set; }
    public DateTime BookingTo { get; set; }
    public string? Description { get; set; }

    public Guid HotelId { get; set; }
    public HotelEntity Hotel { get; set; }
}
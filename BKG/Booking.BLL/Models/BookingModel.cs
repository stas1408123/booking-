using Booking.DAL.Entities;

namespace Booking.BLL.Models
{
    public class BookingModel
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public DateTime BookingFrom { get; set; }
        public DateTime BookingTo { get; set; }
        public string? Description { get; set; }

        public HotelEntity HotelId { get; set; }
    }
}

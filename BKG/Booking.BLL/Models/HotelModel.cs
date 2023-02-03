using Booking.DAL.Entities;

namespace Booking.BLL.Models
{
    public class HotelModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Owner { get; set; }
        public int Stars { get; set; }
        public int CountRooms { get; set; }
        public string PhoneNumber { get; set; }

        public List<BookingEntity>? Bookings { get; set; }
    }
}

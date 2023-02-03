using Booking.BLL.Models;

namespace Booking.API.ViewModels.Booking
{
    public class GetAllBookingsViewModel
    {
        public List<BookingModel>? Bookings { get; set; }
    }
}

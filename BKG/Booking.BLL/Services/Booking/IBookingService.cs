using Booking.BLL.Models;
using Booking.BLL.Services.Generic;

namespace Booking.BLL.Services.Booking
{
    public interface IBookingService : IGenericService<BookingModel>
    {
        Task<List<BookingModel>> GetParticularBookingsAsync(Guid hotelId, DateTime searchFrom, DateTime searchTo);
    }
}

using Booking.BLL.Models;

namespace Booking.BLL.Abstractions
{
    public interface IBookingService : IGenericService<BookingModel>
    {
        Task<List<BookingModel>> GetParticularBookingsAsync(Guid hotelId, DateTime searchFrom, DateTime searchTo);
    }
}

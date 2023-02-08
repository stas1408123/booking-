using Booking.DAL.Entities;

namespace Booking.DAL.Repositories.Booking
{
    public interface IBookingRepository
    {
        Task<List<BookingEntity>> GetParticularBookingsAsync(Guid hotelId, DateTime searchFrom, DateTime searchTo);
    }
}

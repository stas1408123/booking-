using Booking.DAL.Entities;
using Booking.DAL.Repositories.Generic;

namespace Booking.DAL.Repositories.Booking
{
    public interface IBookingRepository : IGenericRepository<BookingEntity>
    {
        Task<List<BookingEntity>> GetParticularBookingsAsync(Guid hotelId, DateTime searchFrom, DateTime searchTo);
    }
}

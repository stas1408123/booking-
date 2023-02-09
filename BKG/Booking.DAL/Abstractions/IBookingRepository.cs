using Booking.DAL.Entities;

namespace Booking.DAL.Abstractions;

public interface IBookingRepository : IGenericRepository<BookingEntity>
{
    Task<List<BookingEntity>> GetParticularBookingsAsync(Guid hotelId, DateTime searchFrom, DateTime searchTo);
}
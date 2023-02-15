using Booking.DAL.Entities;

namespace Booking.DAL.Abstractions;

public interface IBookingRepository : IGenericRepository<BookingEntity>
{
    Task<List<BookingEntity>> GetParticularBookings(Guid hotelId, DateTime searchFrom, DateTime searchTo);
}
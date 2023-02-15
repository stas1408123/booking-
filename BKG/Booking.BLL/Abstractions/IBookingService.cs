using Booking.BLL.Models;

namespace Booking.BLL.Abstractions;

public interface IBookingService : IGenericService<BookingModel>
{
    Task<List<BookingModel>> GetParticularBookings(Guid hotelId, DateTime searchFrom, DateTime searchTo);
}
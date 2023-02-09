using Booking.DAL.Abstractions;
using Booking.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.DAL.Repositories;

public class BookingRepository : GenericRepository<BookingEntity>, IBookingRepository
{
    public BookingRepository(BookingDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<BookingEntity>> GetParticularBookingsAsync(Guid hotelId, DateTime bookingFrom,
        DateTime bookingTo)
    {
        return await DbSet.Where(b => b.HotelId == hotelId)
            .Where(b => b.BookingFrom >= bookingFrom)
            .Where(b => b.BookingTo <= bookingTo)
            .ToListAsync();
    }
}
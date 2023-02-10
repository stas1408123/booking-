using Booking.DAL.Abstractions;
using Booking.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.DAL.Repositories;

public class BookingRepository : GenericRepository<BookingEntity>, IBookingRepository
{
    public BookingRepository(BookingDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<BookingEntity>> GetParticularBookingsAsync(Guid hotelId, DateTime searchFrom,
        DateTime searchTo)
    {
        return await DbSet.Where(b => b.HotelId == hotelId)
            .Where(b => b.BookingFrom >= searchFrom)
            .Where(b => b.BookingTo <= searchTo)
            .ToListAsync();
    }
}
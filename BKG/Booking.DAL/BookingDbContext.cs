using System.Reflection;
using Booking.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.DAL;

public class BookingDbContext : DbContext
{
    public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<HotelEntity> Hotels { get; set; }
    public DbSet<BookingEntity> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
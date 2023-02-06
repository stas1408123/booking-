using Booking.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.DAL.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<BookingEntity>
    {
        public void Configure(EntityTypeBuilder<BookingEntity> builder)
        {
            builder.HasKey(booking => booking.Id);

            builder.HasOne(booking => booking.Hotel)
                .WithMany(hotel => hotel.Bookings)
                .HasForeignKey(booking => booking.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(booking => booking.Price)
                .HasColumnType("decimal(18,4)");
        }
    }
}

using Booking.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.DAL.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<HotelEntity>
    {
        public void Configure(EntityTypeBuilder<HotelEntity> builder)
        {
            builder.HasKey(hotel => hotel.Id);

            builder.HasMany(hotel => hotel.Bookings)
                .WithOne(booking => booking.Hotel)
                .HasForeignKey(booking => booking.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(hotel => hotel.Title)
                .IsUnique();

            builder.HasIndex(hotel => hotel.Address)
                .IsUnique();

            builder.HasIndex(hotel => hotel.PhoneNumber)
                .IsUnique();
        }
    }
}

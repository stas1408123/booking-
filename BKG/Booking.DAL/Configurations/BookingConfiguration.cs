using Booking.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.DAL.Configurations;

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

        builder.HasData(new BookingEntity
            {
                Id = Guid.Parse("0c3db3ee-6f77-4b64-a5ec-27298749f421"),
                BookingFrom = DateTime.UtcNow,
                BookingTo = DateTime.UtcNow,
                Description = "Nvm",
                HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2")
            },
            new BookingEntity
            {
                Id = Guid.Parse("819f9de9-10d3-4459-a950-1561a34f0b9d"),
                BookingFrom = DateTime.UtcNow,
                BookingTo = DateTime.UtcNow,
                Description = "Nvm2",
                HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2")
            },
            new BookingEntity
            {
                Id = Guid.Parse("aae87a10-736e-47c0-9dba-b8550f902d0c"),
                BookingFrom = DateTime.UtcNow,
                BookingTo = DateTime.UtcNow,
                Description = "Idk",
                HotelId = Guid.Parse("60e6d76a-9c13-488b-afce-a3b21dbc3177")
            });
    }
}
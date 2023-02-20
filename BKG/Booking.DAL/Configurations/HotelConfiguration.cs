using Booking.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.DAL.Configurations;

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

        builder.HasData(new HotelEntity
            {
                Id = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2"),
                Title = "GYM HOTEL",
                Description = "Nvm",
                Stars = 5,
                Owner = "Dima Hatetovski",
                CreatedTime = DateTime.Parse("2020-01-01"),
                CountRooms = 125,
                PhoneNumber = "+375336869225",
                Address = "Nvm"
            },
            new HotelEntity
            {
                Id = Guid.Parse("60e6d76a-9c13-488b-afce-a3b21dbc3177"),
                Title = "Pashok Hotel",
                Description = "Idk",
                Stars = 3,
                Owner = "Pashok Gagarin",
                CreatedTime = DateTime.Parse("2023-01-01"),
                CountRooms = 233,
                PhoneNumber = "+123456802232",
                Address = "Idk"
            });
    }
}
using System.Text;
using Booking.API;
using Booking.DAL;
using Booking.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Booking.IntegrationTests.AutoData;

public static class BookingTestData
{
    internal static BookingEntity ExpectedBooking => new()
    {
        BookingFrom = DateTime.Parse("2023-05-01"),
        BookingTo = DateTime.Parse("2025-01-01"),
        Price = 1,
        Description = "Nvm",
        HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2")
    };

    internal static BookingEntity ValidBookingToAdd => new()
    {
        BookingFrom = DateTime.Parse("2023-12-12"),
        BookingTo = DateTime.Parse("2024-03-01"),
        Price = 2,
        Description = "Valid booking",
        HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2")
    };

    internal static BookingEntity ValidBookingToUpdate => new()
    {
        Id = Guid.Parse("0c3db3ee-6f77-4b64-a5ec-27298749f421"),
        BookingFrom = DateTime.Parse("2023-12-12"),
        BookingTo = DateTime.Parse("2024-03-01"),
        Price = 2,
        Description = "Valid booking",
        HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2")
    };

    internal static BookingEntity ValidGetParticularBookings => new()
    {
        HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2"),
        BookingFrom = DateTime.Parse("2023-04-01"),
        BookingTo = DateTime.Parse("2026-12-12")
    };

    internal static BookingEntity InvalidGetParticularBookings(string hotelId, string bookingTo, string bookingFrom)
    {
        return new BookingEntity
        {
            HotelId = Guid.Parse(hotelId),
            BookingFrom = DateTime.Parse(bookingFrom),
            BookingTo = DateTime.Parse(bookingTo)
        };
    }

    internal static List<BookingEntity> ExpectedGetParticularBookings()
    {
        var bookingList = new List<BookingEntity>
        {
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                BookingFrom = DateTime.Parse("2023-05-01"),
                BookingTo = DateTime.Parse("2025-01-01"),
                Price = 1,
                Description = "Nvm",
                HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2")
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                BookingFrom = DateTime.Parse("2023-06-01"),
                BookingTo = DateTime.Parse("2024-01-01"),
                Price = 2,
                Description = "Nvm2",
                HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2")
            }
        };

        return bookingList;
    }

    internal static List<BookingEntity> ExpectedBookingList()
    {
        var bookingList = new List<BookingEntity>
        {
            new()
            {
                Id = Guid.Parse("0c3db3ee-6f77-4b64-a5ec-27298749f421"),
                BookingFrom = DateTime.Parse("2023-05-01"),
                BookingTo = DateTime.Parse("2025-01-01"),
                Price = 1,
                Description = "Nvm",
                HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2")
            },
            new()
            {
                Id = Guid.Parse("819f9de9-10d3-4459-a950-1561a34f0b9d"),
                BookingFrom = DateTime.Parse("2023-06-01"),
                BookingTo = DateTime.Parse("2024-01-01"),
                Price = 2,
                Description = "Nvm2",
                HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2")
            },
            new()
            {
                Id = Guid.Parse("aae87a10-736e-47c0-9dba-b8550f902d0c"),
                BookingFrom = DateTime.Parse("2023-08-01"),
                BookingTo = DateTime.Parse("2023-12-01"),
                Price = 3,
                Description = "Idk",
                HotelId = Guid.Parse("60e6d76a-9c13-488b-afce-a3b21dbc3177")
            }
        };

        return bookingList;
    }

    internal static BookingEntity InvalidBookingToUpdate(string id, string bookingFrom, string bookingTo,
        string description, decimal price, string hotelId)
    {
        return new BookingEntity
        {
            Id = Guid.Parse(id),
            BookingFrom = DateTime.Parse(bookingFrom),
            BookingTo = DateTime.Parse(bookingTo),
            Description = description,
            Price = price,
            HotelId = Guid.Parse(hotelId)
        };
    }

    internal static BookingEntity InvalidBookingToAdd(string bookingFrom, string bookingTo, string description,
        decimal price, string hotelId)
    {
        return new BookingEntity
        {
            BookingFrom = DateTime.Parse(bookingFrom),
            BookingTo = DateTime.Parse(bookingTo),
            Description = description,
            Price = price,
            HotelId = Guid.Parse(hotelId)
        };
    }

    internal static async Task<BookingEntity> GetByIdBooking(HttpResponseMessage response)
    {
        return JsonConvert.DeserializeObject<BookingEntity>(await response.Content.ReadAsStringAsync());
    }

    internal static async Task<List<BookingEntity>> GetBookingList(HttpResponseMessage response)
    {
        return JsonConvert.DeserializeObject<List<BookingEntity>>(await response.Content.ReadAsStringAsync());
    }

    internal static StringContent NewStringContent(BookingEntity bookingEntity)
    {
        return new StringContent(JsonConvert.SerializeObject(bookingEntity), Encoding.UTF8,
            "application/json");
    }

    internal static void ReinitializeDbForTests(CustomWebApplicationFactory<Program> factory)
    {
        using var scope = factory.Services.CreateScope();
        var scopedServices = scope.ServiceProvider;
        var db = scopedServices.GetRequiredService<BookingDbContext>();

        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
    }
}
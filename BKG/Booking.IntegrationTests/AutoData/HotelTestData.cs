using System.Text;
using Booking.API;
using Booking.DAL;
using Booking.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Booking.IntegrationTests.AutoData;

public class HotelTestData
{
    internal static HotelEntity ExpectedHotel => new()
    {
        Title = "GYM HOTEL",
        Description = "Nvm",
        Stars = 5,
        Owner = "Dima Hatetovski",
        CreatedTime = DateTime.Parse("2020-01-01"),
        CountRooms = 125,
        PhoneNumber = "+375336869225",
        Address = "Nvm"
    };

    internal static HotelEntity ValidHotelToAdd => new()
    {
        Title = "ESHKERE",
        Description = "PUNK",
        Address = "Vietnam",
        CountRooms = 777,
        CreatedTime = DateTime.Parse("2020-01-01"),
        Owner = "SEREGA PIRAT",
        Stars = 5,
        PhoneNumber = "+37533686922523"
    };

    internal static HotelEntity ValidHotelToUpdate => new()
    {
        Id = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2"),
        Title = "ESHKERE",
        Description = "PUNK",
        Address = "Vietnam",
        CountRooms = 777,
        CreatedTime = DateTime.Parse("2020-01-01"),
        Owner = "SEREGA PIRAT",
        Stars = 5,
        PhoneNumber = "+37533686922523"
    };

    internal static List<HotelEntity> ExpectedHotelList()
    {
        var list = new List<HotelEntity>
        {
            new()
            {
                Id = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2"),
                Title = "GYM HOTEL",
                Description = "Nvm",
                Stars = 5,
                Owner = "Dima Hatetovski",
                CreatedTime = DateTime.Parse("2020-01-01"),
                CountRooms = 125,
                PhoneNumber = "+375336869225",
                Address = "Nvm",
                Bookings = new List<BookingEntity>()
            },
            new()
            {
                Id = Guid.Parse("60e6d76a-9c13-488b-afce-a3b21dbc3177"),
                Title = "Pashok Hotel",
                Description = "Idk",
                Stars = 3,
                Owner = "Pashok Gagarin",
                CreatedTime = DateTime.Parse("2023-01-01"),
                CountRooms = 233,
                PhoneNumber = "+123456802232",
                Address = "Idk",
                Bookings = new List<BookingEntity>()
            }
        };

        return list;
    }

    internal static HotelEntity InvalidHotelToUpdate(string title, string description, string address, int countRooms,
        string owner, int stars, string phoneNumber)
    {
        return new HotelEntity
        {
            Id = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2"),
            Title = title,
            Description = description,
            Address = address,
            CountRooms = countRooms,
            CreatedTime = DateTime.Parse("2020-01-01"),
            Owner = owner,
            Stars = stars,
            PhoneNumber = phoneNumber,
            Bookings = new List<BookingEntity>()
        };
    }

    internal static HotelEntity InvalidHotelToAdd(string title, string description, string address, int countRooms,
        string owner, int stars, string phoneNumber)
    {
        return new HotelEntity
        {
            Title = title,
            Description = description,
            Address = address,
            CountRooms = countRooms,
            CreatedTime = DateTime.Parse("2020-01-01"),
            Owner = owner,
            Stars = stars,
            PhoneNumber = phoneNumber,
            Bookings = new List<BookingEntity>()
        };
    }

    internal static async Task<HotelEntity> GetByIdHotel(HttpResponseMessage response)
    {
        return JsonConvert.DeserializeObject<HotelEntity>(await response.Content.ReadAsStringAsync());
    }

    internal static async Task<List<HotelEntity>> GetHotelList(HttpResponseMessage response)
    {
        return JsonConvert.DeserializeObject<List<HotelEntity>>(await response.Content.ReadAsStringAsync());
    }

    internal static StringContent NewStringContent(HotelEntity hotelEntity)
    {
        return new StringContent(JsonConvert.SerializeObject(hotelEntity), Encoding.UTF8,
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
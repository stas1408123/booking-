using Booking.API;
using Booking.API.ViewModels;
using Booking.BLL.Models;
using Booking.DAL;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Text;

namespace Booking.IntegrationTests.AutoData;

public class HotelTestData
{
    internal static HotelViewModel ExpectedHotel => new()
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

    internal static HotelViewModel ValidHotelToAdd => new()
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

    internal static HotelModel ValidHotelToUpdate => new()
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

    internal static List<HotelViewModel> ExpectedHotelList()
    {
        var list = new List<HotelViewModel>
        {
            new()
            {
                Title = "GYM HOTEL",
                Description = "Nvm",
                Stars = 5,
                Owner = "Dima Hatetovski",
                CreatedTime = DateTime.Parse("2020-01-01"),
                CountRooms = 125,
                PhoneNumber = "+375336869225",
                Address = "Nvm",
            },
            new()
            {
                Title = "Pashok Hotel",
                Description = "Idk",
                Stars = 3,
                Owner = "Pashok Gagarin",
                CreatedTime = DateTime.Parse("2023-01-01"),
                CountRooms = 233,
                PhoneNumber = "+123456802232",
                Address = "Idk",
            }
        };

        return list;
    }

    internal static HotelViewModel InvalidHotelToUpdate(string title, string description, string address, int countRooms,
        string owner, int stars, string phoneNumber)
    {
        return new HotelViewModel
        {
            Title = title,
            Description = description,
            Address = address,
            CountRooms = countRooms,
            CreatedTime = DateTime.Parse("2020-01-01"),
            Owner = owner,
            Stars = stars,
            PhoneNumber = phoneNumber,
        };
    }

    internal static HotelViewModel InvalidHotelToAdd(string title, string description, string address, int countRooms,
        string owner, int stars, string phoneNumber)
    {
        return new HotelViewModel
        {
            Title = title,
            Description = description,
            Address = address,
            CountRooms = countRooms,
            CreatedTime = DateTime.Parse("2020-01-01"),
            Owner = owner,
            Stars = stars,
            PhoneNumber = phoneNumber,
        };
    }

    internal static async Task<HotelViewModel> GetByIdHotel(HttpResponseMessage response)
    {
        return JsonConvert.DeserializeObject<HotelViewModel>(await response.Content.ReadAsStringAsync());
    }

    internal static async Task<HotelModel> GetByIdHotelModel(HttpResponseMessage response)
    {
        return JsonConvert.DeserializeObject<HotelModel>(await response.Content.ReadAsStringAsync());
    }

    internal static async Task<List<HotelViewModel>> GetHotelList(HttpResponseMessage response)
    {
        return JsonConvert.DeserializeObject<List<HotelViewModel>>(await response.Content.ReadAsStringAsync());
    }

    internal static StringContent NewStringContent(HotelViewModel hotelViewModel)
    {
        return new StringContent(JsonConvert.SerializeObject(hotelViewModel), Encoding.UTF8,
            "application/json");
    }

    internal static StringContent NewStringContent(HotelModel hotelModel)
    {
        return new StringContent(JsonConvert.SerializeObject(hotelModel), Encoding.UTF8,
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
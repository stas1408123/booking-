using System.Text;
using Booking.API;
using Booking.API.ViewModels;
using Booking.BLL.Models;
using Booking.DAL;
using Booking.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Booking.IntegrationTests.AutoData;

public static class BookingTestData
{
    internal static BookingViewModel ExpectedBooking => new()
    {
        BookingFrom = DateTime.Parse("2023-05-01"),
        BookingTo = DateTime.Parse("2025-01-01"),
        Price = 1,
        Description = "Nvm",
        HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2")
    };

    internal static BookingViewModel ValidBookingToAdd => new()
    {
        BookingFrom = DateTime.Parse("2023-12-12"),
        BookingTo = DateTime.Parse("2024-03-01"),
        Price = 2,
        Description = "Valid booking",
        HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2")
    };

    internal static BookingModel ValidBookingToUpdate => new()
    {
        Id = Guid.Parse("0c3db3ee-6f77-4b64-a5ec-27298749f421"),
        BookingFrom = DateTime.Parse("2023-12-12"),
        BookingTo = DateTime.Parse("2024-03-01"),
        Price = 2,
        Description = "Valid booking",
        HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2")
    };

    internal static BookingViewModel ValidGetParticularBookings => new()
    {
        HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2"),
        BookingFrom = DateTime.Parse("2023-04-01"),
        BookingTo = DateTime.Parse("2026-12-12")
    };

    internal static BookingViewModel InvalidGetParticularBookings(string hotelId, string bookingTo, string bookingFrom)
    {
        return new BookingViewModel
        {
            HotelId = Guid.Parse(hotelId),
            BookingFrom = DateTime.Parse(bookingFrom),
            BookingTo = DateTime.Parse(bookingTo)
        };
    }

    internal static List<BookingViewModel> ExpectedGetParticularBookings()
    {
        var bookingList = new List<BookingViewModel>
        {
            new()
            {
                BookingFrom = DateTime.Parse("2023-05-01"),
                BookingTo = DateTime.Parse("2025-01-01"),
                Price = 1,
                Description = "Nvm",
                HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2")
            },
            new()
            {
                BookingFrom = DateTime.Parse("2023-06-01"),
                BookingTo = DateTime.Parse("2024-01-01"),
                Price = 2,
                Description = "Nvm2",
                HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2")
            }
        };

        return bookingList;
    }

    internal static List<BookingViewModel> ExpectedBookingList()
    {
        var bookingList = new List<BookingViewModel>
        {
            new()
            {
                BookingFrom = DateTime.Parse("2023-05-01"),
                BookingTo = DateTime.Parse("2025-01-01"),
                Price = 1,
                Description = "Nvm",
                HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2")
            },
            new()
            {
                BookingFrom = DateTime.Parse("2023-06-01"),
                BookingTo = DateTime.Parse("2024-01-01"),
                Price = 2,
                Description = "Nvm2",
                HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2")
            },
            new()
            {
                BookingFrom = DateTime.Parse("2023-08-01"),
                BookingTo = DateTime.Parse("2023-12-01"),
                Price = 3,
                Description = "Idk",
                HotelId = Guid.Parse("60e6d76a-9c13-488b-afce-a3b21dbc3177")
            }
        };

        return bookingList;
    }

    internal static BookingModel InvalidBookingToUpdate(string id, string bookingFrom, string bookingTo,
        string description, decimal price, string hotelId)
    {
        return new BookingModel
        {
            Id = Guid.Parse(id),
            BookingFrom = DateTime.Parse(bookingFrom),
            BookingTo = DateTime.Parse(bookingTo),
            Description = description,
            Price = price,
            HotelId = Guid.Parse(hotelId)
        };
    }

    internal static BookingViewModel InvalidBookingToAdd(string bookingFrom, string bookingTo, string description,
        decimal price, string hotelId)
    {
        return new BookingViewModel
        {
            BookingFrom = DateTime.Parse(bookingFrom),
            BookingTo = DateTime.Parse(bookingTo),
            Description = description,
            Price = price,
            HotelId = Guid.Parse(hotelId)
        };
    }

    internal static async Task<BookingViewModel> GetByIdBooking(HttpResponseMessage response)
    {
        return JsonConvert.DeserializeObject<BookingViewModel>(await response.Content.ReadAsStringAsync());
    }

    internal static async Task<BookingModel> GetByIdBookingModel(HttpResponseMessage response)
    {
        return JsonConvert.DeserializeObject<BookingModel>(await response.Content.ReadAsStringAsync());
    }

    internal static async Task<List<BookingViewModel>> GetBookingList(HttpResponseMessage response)
    {
        return JsonConvert.DeserializeObject<List<BookingViewModel>>(await response.Content.ReadAsStringAsync());
    }

    internal static StringContent NewStringContent(BookingViewModel bookingViewModel)
    {
        return new StringContent(JsonConvert.SerializeObject(bookingViewModel), Encoding.UTF8,
            "application/json");
    }

    internal static StringContent NewStringContent(BookingModel bookingModel)
    {
        return new StringContent(JsonConvert.SerializeObject(bookingModel), Encoding.UTF8,
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
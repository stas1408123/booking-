using Booking.API.ViewModels;

namespace Booking.API.Tests.AutoData.ViewModels;

public static class BookingViewModelData
{
    internal static BookingViewModel GetInvalidBookingFrom = new()
    {
        BookingFrom = DateTime.Parse("2020-01-01")
    };

    internal static BookingViewModel GetValidBookingFrom = new()
    {
        BookingFrom = DateTime.Parse("2024-03-01")
    };

    internal static BookingViewModel GetInvalidBookingTo = new()
    {
        BookingTo = DateTime.Parse("2020-01-01")
    };

    internal static BookingViewModel GetValidBookingTo = new()
    {
        BookingTo = DateTime.Parse("2024-01-01")
    };

    internal static BookingViewModel GetNullDescription = new()
    {
        Description = null
    };

    internal static BookingViewModel GetEmptyDescription = new()
    {
        Description = ""
    };

    internal static BookingViewModel GetValidDescription = new()
    {
        Description = "Correct"
    };

    internal static BookingViewModel GetInvalidPrice = new()
    {
        Price = -1
    };

    internal static BookingViewModel GetValidPrice = new()
    {
        Price = 1
    };

    internal static BookingViewModel GetEmptyHotelId = new()
    {
        HotelId = Guid.Empty
    };

    internal static BookingViewModel GetValidHotelId = new()
    {
        HotelId = Guid.NewGuid()
    };

    internal static BookingViewModel ValidViewModelForMapping => new()
    {
        BookingFrom = DateTime.Parse("2023-05-01"),
        BookingTo = DateTime.Parse("2025-01-01"),
        Price = 1,
        Description = "Nvm",
        HotelId = Guid.Parse("d990989f-bd61-450d-a6e9-b8eed2fd5ba2")
    };

    internal static BookingViewModel ViewModelWithEmptyPropertiesForMapping => new()
    {
        BookingFrom = DateTime.Parse("2023-05-01"),
        BookingTo = DateTime.Parse("2025-01-01"),
        Price = 1,
        Description = null,
    };
}
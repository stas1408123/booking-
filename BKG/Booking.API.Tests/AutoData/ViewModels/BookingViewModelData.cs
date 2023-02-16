using Booking.API.ViewModels;

namespace Booking.API.Tests.AutoData.ViewModels
{
    public static class BookingViewModelData
    {
        internal static BookingViewModel GetInCorrectBookingFrom = new()
        {
            BookingFrom = DateTime.Parse("2020-01-01")
        };

        internal static BookingViewModel GetCorrectBookingFrom = new()
        {
            BookingFrom = DateTime.Parse("2023-03-01")
        };

        internal static BookingViewModel GetInCorrectBookingTo = new()
        {
            BookingTo = DateTime.Parse("2020-01-01")
        };

        internal static BookingViewModel GetCorrectBookingTo = new()
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

        internal static BookingViewModel GetCorrectDescription = new()
        {
            Description = "Correct"
        };

        internal static BookingViewModel GetInCorrectPrice = new()
        {
            Price = -1
        };

        internal static BookingViewModel GetCorrectPrice = new()
        {
            Price = 1
        };

        internal static BookingViewModel GetEmptyHotelId = new()
        {
            HotelId = Guid.Empty
        };

        internal static BookingViewModel GetCorrectHotelId = new()
        {
            HotelId = Guid.NewGuid()
        };
    }
}

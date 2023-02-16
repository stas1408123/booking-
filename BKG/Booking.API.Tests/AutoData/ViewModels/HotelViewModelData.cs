using Booking.API.ViewModels;

namespace Booking.API.Tests.AutoData.ViewModels;

public class HotelViewModelData
{
    internal static HotelViewModel GetNullTitle = new()
    {
        Title = null
    };

    internal static HotelViewModel GetEmptyTitle = new()
    {
        Title = ""
    };

    internal static HotelViewModel GetInCorrectLengthTitle = new()
    {
        Title = "Maximum length is 20, but this title have more than 20"
    };

    internal static HotelViewModel GetCorrectTitle = new()
    {
        Title = "Correct"
    };

    internal static HotelViewModel GetNullAddress = new()
    {
        Address = null
    };

    internal static HotelViewModel GetEmptyAddress = new()
    {
        Address = ""
    };

    internal static HotelViewModel GetCorrectAddress = new()
    {
        Address = "Belarus, Mogilev, Pervomayskaya, 41"
    };

    internal static HotelViewModel GetTooFewCountRooms = new()
    {
        CountRooms = -1
    };

    internal static HotelViewModel GetTooMuchCountRooms = new()
    {
        CountRooms = 2134
    };

    internal static HotelViewModel GetCorrectCountRooms = new()
    {
        CountRooms = 666
    };

    internal static HotelViewModel GetNullDescription = new()
    {
        Description = null
    };

    internal static HotelViewModel GetEmptyDescription = new()
    {
        Description = ""
    };

    internal static HotelViewModel GetCorrectDescription = new()
    {
        Description = "Correct"
    };

    internal static HotelViewModel GetTooSmallStars = new()
    {
        Stars = -1
    };

    internal static HotelViewModel GetTooBigStars = new()
    {
        Stars = 7
    };

    internal static HotelViewModel GetCorrectStars = new()
    {
        Stars = 5
    };

    internal static HotelViewModel GetNullPhoneNumber = new()
    {
        PhoneNumber = null
    };

    internal static HotelViewModel GetEmptyPhoneNumber = new()
    {
        PhoneNumber = ""
    };

    internal static HotelViewModel GetTooShortLengthPhoneNumber = new()
    {
        PhoneNumber = "+343222"
    };

    internal static HotelViewModel GetTooBigLengthPhoneNumber = new()
    {
        PhoneNumber = "+3757243821741287471274127471247"
    };

    internal static HotelViewModel GetNotValidPhoneNumber = new()
    {
        PhoneNumber = "375336869225"
    };

    internal static HotelViewModel GetCorrectPhoneNumber = new()
    {
        PhoneNumber = "+375336869225"
    };

    internal static HotelViewModel GetNullOwner = new()
    {
        Owner = null
    };

    internal static HotelViewModel GetEmptyOwner = new()
    {
        Owner = ""
    };

    internal static HotelViewModel GetCorrectOwner = new()
    {
        Owner = "Stasyambich"
    };
}
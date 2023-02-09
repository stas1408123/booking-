using AutoMapper;
using Booking.API.ViewModels;
using Booking.BLL.Models;

namespace Booking.API.Mapping;

public class BookingViewModelMapping : Profile
{
    public BookingViewModelMapping()
    {
        CreateMap<BookingViewModel, BookingModel>().ReverseMap();
    }
}
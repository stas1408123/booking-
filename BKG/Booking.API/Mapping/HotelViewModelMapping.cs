using AutoMapper;
using Booking.API.ViewModels;
using Booking.BLL.Models;

namespace Booking.API.Mapping;

public class HotelViewModelMapping : Profile
{
    public HotelViewModelMapping()
    {
        CreateMap<HotelViewModel, HotelModel>().ReverseMap();
    }
}
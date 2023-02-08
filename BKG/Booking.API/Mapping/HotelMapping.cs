using AutoMapper;
using Booking.API.ViewModels;
using Booking.BLL.Models;
using Booking.DAL.Entities;

namespace Booking.API.Mapping
{
    public class HotelMapping : Profile
    {
        public HotelMapping()
        {
            CreateMap<HotelViewModel, HotelModel>().ReverseMap();
            CreateMap<HotelModel, HotelEntity>().ReverseMap();
        }
    }
}

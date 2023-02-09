using AutoMapper;
using Booking.BLL.Models;
using Booking.DAL.Entities;

namespace Booking.BLL.Mapping;

public class HotelModelMapping : Profile
{
    public HotelModelMapping()
    {
        CreateMap<HotelModel, HotelEntity>().ReverseMap();
    }
}
using AutoMapper;
using Booking.API.ViewModels;
using Booking.BLL.Models;
using Booking.DAL.Entities;

namespace Booking.API.Mapping
{
    public class BookingMapping : Profile
    {
        public BookingMapping()
        {
            CreateMap<BookingViewModel, BookingModel>().ReverseMap();
            CreateMap<BookingModel, BookingEntity>().ReverseMap();
        }
    }
}

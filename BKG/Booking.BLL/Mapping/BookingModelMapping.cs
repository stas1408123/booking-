using AutoMapper;
using Booking.BLL.Models;
using Booking.DAL.Entities;

namespace Booking.BLL.Mapping
{
    public class BookingModelMapping : Profile
    {
        public BookingModelMapping()
        {
            CreateMap<BookingModel, BookingEntity>().ReverseMap();
        }
    }
}

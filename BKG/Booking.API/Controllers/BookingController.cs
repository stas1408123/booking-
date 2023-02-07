using AutoMapper;
using Booking.API.ViewModels;
using Booking.BLL.Models;
using Booking.BLL.Services.Generic;
using Booking.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    public class BookingController : GenericController<BookingEntity, BookingModel, BookingViewModel>
    {
        public BookingController(IGenericService<BookingEntity, BookingModel> genericService,
            IMapper mapper) : base(genericService, mapper) { }
    }
}

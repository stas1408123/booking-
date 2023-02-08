using AutoMapper;
using Booking.API.ViewModels;
using Booking.BLL.Models;
using Booking.BLL.Services.Generic;
using Booking.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    public class BookingController : GenericController<BookingModel, BookingViewModel>
    {
        public BookingController(IGenericService<BookingModel> genericService,
            IMapper mapper) : base(genericService, mapper) { }
    }
}

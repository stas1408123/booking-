using AutoMapper;
using Booking.API.ViewModels;
using Booking.BLL.Models;
using Booking.BLL.Services.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    public class HotelController : GenericController<HotelModel, HotelViewModel>
    {
        public HotelController(IGenericService<HotelModel> genericService,
            IMapper mapper) : base(genericService, mapper) { }
    }
}

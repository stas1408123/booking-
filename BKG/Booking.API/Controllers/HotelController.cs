using AutoMapper;
using Booking.API.ViewModels;
using Booking.BLL.Models;
using Booking.BLL.Services.Generic;
using Booking.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    public class HotelController : GenericController<HotelEntity, HotelModel, HotelViewModel>
    {
        public HotelController(IGenericService<HotelEntity, HotelModel> genericService,
            IMapper mapper) : base(genericService, mapper) { }
    }
}

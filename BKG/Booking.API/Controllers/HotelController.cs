using AutoMapper;
using Booking.API.ViewModels;
using Booking.BLL.Abstractions;
using Booking.BLL.Models;

namespace Booking.API.Controllers;

public class HotelController : GenericController<HotelModel, HotelViewModel>
{
    public HotelController(IGenericService<HotelModel> genericService,
        IMapper mapper) : base(genericService, mapper)
    {
    }
}
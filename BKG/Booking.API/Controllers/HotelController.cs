using AutoMapper;
using Booking.API.ViewModels;
using Booking.BLL.Abstractions;
using Booking.BLL.Models;
using FluentValidation;

namespace Booking.API.Controllers;

public class HotelController : GenericController<HotelModel, HotelViewModel>
{
    public HotelController(IGenericService<HotelModel> genericService,
        IMapper mapper,
        IValidator<HotelViewModel> validator) : base(genericService, mapper, validator)
    {
    }
}
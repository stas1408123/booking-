using AutoMapper;
using Booking.API.ViewModels;
using Booking.BLL.Abstractions;
using Booking.BLL.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Booking.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;
    private readonly IMapper _mapper;
    private readonly IValidator<BookingViewModel> _validator;

    public BookingController(IMapper mapper,
        IBookingService bookingService,
        IValidator<BookingViewModel> validator)
    {
        _bookingService = bookingService;
        _mapper = mapper;
        _validator = validator;
    }

    [HttpPost("get-particular-bookings")]
    public async Task<IActionResult> GetParticularBookings(BookingViewModel viewModel)
    {
        await _validator.ValidateAndThrowAsync(viewModel);

        var bookingsModels =
            await _bookingService.GetParticularBookingsAsync(viewModel.HotelId, viewModel.BookingFrom,
                viewModel.BookingTo);
        var bookingViewModels = _mapper.Map<List<BookingModel>, List<BookingViewModel>>(bookingsModels);

        return Ok(bookingViewModels);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var models = await _bookingService.GetAllAsync();

        return Ok(models);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var model = await _bookingService.GetByIdAsync(id);
        var viewModel = _mapper.Map<BookingViewModel>(model);

        return Ok(viewModel);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(BookingViewModel viewModel)
    {
        await _validator.ValidateAndThrowAsync(viewModel);

        var model = _mapper.Map<BookingModel>(viewModel);
        await _bookingService.AddAsync(model);

        return Ok(viewModel);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(Guid id, BookingViewModel viewModel)
    {
        await _validator.ValidateAndThrowAsync(viewModel);

        var model = _mapper.Map<BookingModel>(viewModel);
        model.Id = id;
        await _bookingService.UpdateAsync(model);

        return Ok(viewModel);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _bookingService.DeleteAsync(id);

        return Ok();
    }
}
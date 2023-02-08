using AutoMapper;
using Booking.API.ViewModels;
using Booking.BLL.Models;
using Booking.BLL.Services.Booking;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IMapper mapper,
            IBookingService bookingService)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet("get-particular-bookings")]
        public async Task<IActionResult> GetParticularBookings(Guid hotelId, DateTime bookingFrom, DateTime bookingTo)
        {
            var bookingsModels = await _bookingService.GetParticularBookingsAsync(hotelId, bookingFrom, bookingTo);
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
            var model = _mapper.Map<BookingModel>(viewModel);
            await _bookingService.AddAsync(model);

            return Ok(viewModel);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Guid id, BookingViewModel viewModel)
        {
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
}

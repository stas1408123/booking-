using AutoMapper;
using Booking.API.ViewModels;
using Booking.BLL.Models;
using Booking.BLL.Services.Booking;
using Booking.BLL.Services.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    public class BookingController : GenericController<BookingModel, BookingViewModel>
    {
        private readonly IBookingService _bookingService;

        public BookingController(IGenericService<BookingModel> genericService,
            IMapper mapper,
            IBookingService bookingService) : base(genericService, mapper)
        {
            _bookingService = bookingService;
        }

        [HttpGet("get-particular-bookings")]
        public async Task<IActionResult> GetParticularBookings(Guid hotelId, DateTime bookingFrom, DateTime bookingTo)
        {
            var bookingsModels = await _bookingService.GetParticularBookingsAsync(hotelId, bookingFrom, bookingTo);
            var bookingViewModels = Mapper.Map<List<BookingModel>, List<BookingViewModel>>(bookingsModels);

            return Ok(bookingViewModels);
        }
    }
}

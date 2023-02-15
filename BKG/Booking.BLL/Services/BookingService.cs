using AutoMapper;
using Booking.BLL.Abstractions;
using Booking.BLL.Models;
using Booking.DAL.Abstractions;
using Booking.DAL.Entities;

namespace Booking.BLL.Services;

public class BookingService : GenericService<BookingEntity, BookingModel>, IBookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository,
        IMapper mapper) : base(bookingRepository, mapper)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<List<BookingModel>> GetParticularBookings(Guid hotelId, DateTime searchFrom,
        DateTime searchTo)
    {
        if (searchFrom > searchTo)
            throw new ArgumentException("Booking from date cannot get ahead of time booking to date");
        if (searchFrom < DateTime.UtcNow)
            throw new ArgumentException("Booking from date cannot get past time");

        var bookingEntities = await _bookingRepository.GetParticularBookings(hotelId, searchFrom, searchTo);
        var bookingModels = Mapper.Map<List<BookingModel>>(bookingEntities);

        return bookingModels;
    }
}
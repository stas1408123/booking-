using AutoMapper;
using Booking.BLL.Abstractions;
using Booking.BLL.Models;
using Booking.DAL.Abstractions;
using Booking.DAL.Entities;

namespace Booking.BLL.Services;

public class BookingService : GenericService<BookingEntity, BookingModel>, IBookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IGenericRepository<BookingEntity> repository,
        IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<List<BookingModel>> GetParticularBookingsAsync(Guid hotelId, DateTime bookingFrom,
        DateTime bookingTo)
    {
        var bookingEntities = await _bookingRepository.GetParticularBookingsAsync(hotelId, bookingFrom, bookingTo);
        var bookingModels = Mapper.Map<List<BookingEntity>, List<BookingModel>>(bookingEntities);

        return bookingModels;
    }
}
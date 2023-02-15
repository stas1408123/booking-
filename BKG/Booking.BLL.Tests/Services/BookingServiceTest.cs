using FluentAssertions;

namespace Booking.BLL.Tests.Services;

public class BookingServiceTest
{
    private readonly Mock<IBookingRepository> _bookingRepository;
    private readonly IBookingService _bookingService;
    private readonly Mock<IMapper> _mapper;

    public BookingServiceTest()
    {
        _bookingRepository = new Mock<IBookingRepository>();
        _mapper = new Mock<IMapper>();
        _bookingService = new BookingService(_bookingRepository.Object, _mapper.Object);
    }

    [Fact]
    public async Task GetAll_WhenEntitiesExist_ShouldReturnListOfModels_Async()
    {
        // Act
        _bookingRepository.Setup(r => r.GetAllAsync())
            .ReturnsAsync(BookingEntityData.CreateBookingsList());
        _mapper.Setup(m => m.Map<List<BookingModel>>(It.IsAny<List<BookingEntity>>()))
            .Returns(BookingModelData.CreateBookingsList());

        // Arrange
        var result = await _bookingService.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(BookingModelData.CreateBookingsList());
    }

    [Fact]
    public async Task GetById_WhenEntityNotExist_ShouldThrowException_Async()
    {
        // Act
        _bookingRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(value: null);

        // Arrange + Assert
        await Assert.ThrowsAsync<ArgumentNullException>(
            async () => await _bookingService.GetByIdAsync(It.IsAny<Guid>()));
    }

    [Fact]
    public async Task GetById_WhenEntityExist_ShouldReturnModel_Async()
    {
        // Act
        _bookingRepository.Setup(r => r.GetByIdAsync(BookingEntityData.GetBookingEntity.Id))
            .ReturnsAsync(BookingEntityData.GetBookingEntity);
        _mapper.Setup(m => m.Map<BookingModel>(It.IsAny<BookingEntity>()))
            .Returns(BookingModelData.GetBookingModel);

        // Arrange
        var result = await _bookingService.GetByIdAsync(BookingEntityData.GetBookingEntity.Id);

        // Act
        _bookingRepository.Verify(r => r.GetByIdAsync(BookingEntityData.GetBookingEntity.Id));
        result.Should().NotBeNull();
        result.Should().BeOfType<BookingModel>();
        result.Should().BeEquivalentTo(BookingModelData.GetBookingModel);
    }

    [Fact]
    public async Task Create_WhenBookingModelIsSet_ShouldReturnCorrectModel_Async()
    {
        // Act
        _mapper.Setup(m => m.Map<BookingEntity>(It.IsAny<BookingModel>()))
            .Returns(BookingEntityData.GetBookingEntity);
        _bookingRepository.Setup(r => r.AddAsync(BookingEntityData.GetBookingEntity))
            .ReturnsAsync(BookingEntityData.GetBookingEntity);
        _mapper.Setup(m => m.Map<BookingModel>(It.IsAny<BookingEntity>()))
            .Returns(BookingModelData.GetBookingModel);

        // Arrange
        var result = await _bookingService.AddAsync(BookingModelData.GetBookingModel);

        // Assert
        _bookingRepository.Verify(r => r.AddAsync(BookingEntityData.GetBookingEntity));
        result.Should().NotBeNull();
        result.Should().BeOfType<BookingModel>();
        result.Should().BeEquivalentTo(BookingModelData.GetBookingModel);
    }


    [Fact]
    public async Task DeleteById_WhenEntityNotExist_ShouldReturnNull_Async()
    {
        // Act
        _bookingRepository.Setup(r => r.DeleteAsync(It.IsAny<Guid>()))
            .ReturnsAsync(value: null);

        // Arrange
        var result = await _bookingService.DeleteAsync(It.IsAny<Guid>());

        // Assert
        _bookingRepository.Verify(r => r.DeleteAsync(It.IsAny<Guid>()));
        result.Should().BeNull();
    }

    [Fact]
    public async Task DeleteById_WhenEntityExist_ShouldReturnModel_Async()
    {
        // Act
        _bookingRepository.Setup(r => r.DeleteAsync(BookingEntityData.GetBookingEntity.Id))
            .ReturnsAsync(BookingEntityData.GetBookingEntity);
        _mapper.Setup(m => m.Map<BookingModel>(It.IsAny<BookingEntity>()))
            .Returns(BookingModelData.GetBookingModel);

        // Arrange
        var result = await _bookingService.DeleteAsync(BookingEntityData.GetBookingEntity.Id);

        // Assert
        _bookingRepository.Verify(r => r.DeleteAsync(BookingEntityData.GetBookingEntity.Id));
        result.Should().NotBeNull();
        result.Should().BeOfType<BookingModel>();
        result.Should().BeEquivalentTo(BookingModelData.GetBookingModel);
    }

    [Fact]
    public async Task Update_WhenBookingModelIsSet_ShouldReturnCorrectModel_Async()
    {
        // Act
        _mapper.Setup(m => m.Map<BookingEntity>(BookingModelData.GetBookingModelToUpdate))
            .Returns(BookingEntityData.GetBookingEntityToUpdate);
        _bookingRepository.Setup(r => r.UpdateAsync(BookingEntityData.GetBookingEntityToUpdate))
            .ReturnsAsync(BookingEntityData.GetBookingEntityToUpdate);
        _mapper.Setup(m => m.Map<BookingModel>(BookingEntityData.GetBookingEntityToUpdate))
            .Returns(BookingModelData.GetBookingModelToUpdate);

        // Arrange
        var result = await _bookingService.UpdateAsync(BookingModelData.GetBookingModelToUpdate);

        // Assert
        _bookingRepository.Verify(r => r.UpdateAsync(BookingEntityData.GetBookingEntityToUpdate));
        result.Should().NotBeNull();
        result.Should().BeOfType<BookingModel>();
        result.Should().NotBeEquivalentTo(BookingModelData.GetBookingModel);
    }

    [Theory]
    [InlineData("c839050c-e854-414a-93ea-f558e993e75e", "2023-03-01", "2024-01-01")]
    [InlineData("c839050c-e854-414a-93ea-f558e993e75e", "2023-03-01", "2026-01-01")]
    public async Task GetParticularBookings_WhenBookingDataIsCorrect_ShouldReturnListOfModels_Async(string hotelId,
        string bookingFrom, string bookingTo)
    {
        // Act
        var correctHotelId = Guid.Parse(hotelId);
        var correctBookingFrom = DateTime.Parse(bookingFrom);
        var correctBookingTo = DateTime.Parse(bookingTo);

        _bookingRepository
            .Setup(r => r.GetParticularBookingsAsync(correctHotelId, correctBookingFrom, correctBookingTo))
            .ReturnsAsync(BookingEntityData.SortedList(correctHotelId, correctBookingFrom, correctBookingTo));
        _mapper.Setup(m => m.Map<List<BookingEntity>>(It.IsAny<List<BookingModel>>()))
            .Returns(BookingEntityData.SortedList(correctHotelId, correctBookingFrom, correctBookingTo));
        _mapper.Setup(m => m.Map<List<BookingModel>>(It.IsAny<List<BookingEntity>>()))
            .Returns(BookingModelData.SortedList(correctHotelId, correctBookingFrom, correctBookingTo));

        // Arrange
        var result =
            await _bookingService.GetParticularBookingsAsync(correctHotelId, correctBookingFrom, correctBookingTo);

        // Assert
        _bookingRepository.Verify(r =>
            r.GetParticularBookingsAsync(correctHotelId, correctBookingFrom, correctBookingTo));
        result.Should().NotBeNull();
        result.Should().BeOfType<List<BookingModel>>();
        result.Should()
            .BeEquivalentTo(BookingModelData.SortedList(correctHotelId, correctBookingFrom, correctBookingTo));
    }

    [Theory]
    [InlineData("c839050c-e854-414a-93ea-f558e993e75e", "2020-03-01", "2026-01-01")]
    [InlineData("c839050c-e854-414a-93ea-f558e993e75e", "2023-06-01", "2022-01-01")]
    public async Task GetParticularBookings_WhenBookingDatesIsIncorrect_ShouldReturnException_Async(string hotelId,
        string bookingFrom, string bookingTo)
    {
        // Act
        var correctHotelId = Guid.Parse(hotelId);
        var correctBookingFrom = DateTime.Parse(bookingFrom);
        var correctBookingTo = DateTime.Parse(bookingTo);

        _bookingRepository
            .Setup(r => r.GetParticularBookingsAsync(correctHotelId, correctBookingFrom, correctBookingTo))
            .ReturnsAsync(BookingEntityData.SortedList(correctHotelId, correctBookingFrom, correctBookingTo));
        _mapper.Setup(m => m.Map<List<BookingEntity>>(It.IsAny<List<BookingModel>>()))
            .Returns(BookingEntityData.SortedList(correctHotelId, correctBookingFrom, correctBookingTo));
        _mapper.Setup(m => m.Map<List<BookingModel>>(It.IsAny<List<BookingEntity>>()))
            .Returns(BookingModelData.SortedList(correctHotelId, correctBookingFrom, correctBookingTo));

        // Arrange + Assert
        await Assert.ThrowsAsync<ArgumentException>(async () =>
            await _bookingService.GetParticularBookingsAsync(correctHotelId, correctBookingFrom, correctBookingTo));
    }
}
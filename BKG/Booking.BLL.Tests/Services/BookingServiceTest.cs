using FluentAssertions;

namespace Booking.BLL.Tests.Services;

public class BookingServiceTest
{
    private readonly Mock<IBookingRepository> _bookingRepoMock;
    private readonly IBookingService _bookingService;
    private readonly Mock<IMapper> _mapperMock;

    public BookingServiceTest()
    {
        _bookingRepoMock = new Mock<IBookingRepository>();
        _mapperMock = new Mock<IMapper>();
        _bookingService = new BookingService(_bookingRepoMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task GetAll_WhenEntitiesExist_ShouldReturnListOfModels()
    {
        // Arrange
        _bookingRepoMock.Setup(r => r.GetAll())
            .ReturnsAsync(BookingEntityData.CreateBookingsList());
        _mapperMock.Setup(m => m.Map<List<BookingModel>>(It.IsAny<List<BookingEntity>>()))
            .Returns(BookingModelData.CreateBookingsList());

        // Act
        var result = await _bookingService.GetAll();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(BookingModelData.CreateBookingsList());
    }

    [Fact]
    public async Task GetById_WhenEntityNotExist_ShouldThrowException()
    {
        // Arrange
        _bookingRepoMock.Setup(r => r.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(value: null);

        // Act + Assert
        await Assert.ThrowsAsync<ArgumentNullException>(
            async () => await _bookingService.GetById(It.IsAny<Guid>()));
    }

    [Fact]
    public async Task GetById_WhenEntityExist_ShouldReturnModel()
    {
        // Arrange
        _bookingRepoMock.Setup(r => r.GetById(BookingEntityData.GetBookingEntity.Id))
            .ReturnsAsync(BookingEntityData.GetBookingEntity);
        _mapperMock.Setup(m => m.Map<BookingModel>(It.IsAny<BookingEntity>()))
            .Returns(BookingModelData.GetBookingModel);

        // Act
        var result = await _bookingService.GetById(BookingEntityData.GetBookingEntity.Id);

        // Assert
        _bookingRepoMock.Verify(r => r.GetById(BookingEntityData.GetBookingEntity.Id));
        result.Should().NotBeNull();
        result.Should().BeOfType<BookingModel>();
        result.Should().BeEquivalentTo(BookingModelData.GetBookingModel);
    }

    [Fact]
    public async Task Create_WhenBookingModelIsSet_ShouldReturnCorrectModel()
    {
        // Arrange
        _mapperMock.Setup(m => m.Map<BookingEntity>(It.IsAny<BookingModel>()))
            .Returns(BookingEntityData.GetBookingEntity);
        _bookingRepoMock.Setup(r => r.Add(BookingEntityData.GetBookingEntity))
            .ReturnsAsync(BookingEntityData.GetBookingEntity);
        _mapperMock.Setup(m => m.Map<BookingModel>(It.IsAny<BookingEntity>()))
            .Returns(BookingModelData.GetBookingModel);

        // Act
        var result = await _bookingService.Add(BookingModelData.GetBookingModel);

        // Assert
        _bookingRepoMock.Verify(r => r.Add(BookingEntityData.GetBookingEntity));
        result.Should().NotBeNull();
        result.Should().BeOfType<BookingModel>();
        result.Should().BeEquivalentTo(BookingModelData.GetBookingModel);
    }


    [Fact]
    public async Task DeleteById_WhenEntityNotExist_ShouldReturnsException()
    {
        // Arrange
        _bookingRepoMock.Setup(r => r.Delete(It.IsAny<Guid>()))
            .ReturnsAsync(value: null);

        // Act + Assert
        await Assert.ThrowsAsync<ArgumentNullException>(
            async () => await _bookingService.Delete(It.IsAny<Guid>()));
    }

    [Fact]
    public async Task DeleteById_WhenEntityExist_ShouldReturnModel()
    {
        // Arrange
        _bookingRepoMock.Setup(r => r.Delete(BookingEntityData.GetBookingEntity.Id))
            .ReturnsAsync(BookingEntityData.GetBookingEntity);
        _mapperMock.Setup(m => m.Map<BookingModel>(It.IsAny<BookingEntity>()))
            .Returns(BookingModelData.GetBookingModel);

        // Act
        var result = await _bookingService.Delete(BookingEntityData.GetBookingEntity.Id);

        // Assert
        _bookingRepoMock.Verify(r => r.Delete(BookingEntityData.GetBookingEntity.Id));
        result.Should().NotBeNull();
        result.Should().BeOfType<BookingModel>();
        result.Should().BeEquivalentTo(BookingModelData.GetBookingModel);
    }

    [Fact]
    public async Task Update_WhenBookingModelIsSet_ShouldReturnCorrectModel()
    {
        // Arrange
        _mapperMock.Setup(m => m.Map<BookingEntity>(BookingModelData.GetBookingModelToUpdate))
            .Returns(BookingEntityData.GetBookingEntityToUpdate);
        _bookingRepoMock.Setup(r => r.Update(BookingEntityData.GetBookingEntityToUpdate))
            .ReturnsAsync(BookingEntityData.GetBookingEntityToUpdate);
        _mapperMock.Setup(m => m.Map<BookingModel>(BookingEntityData.GetBookingEntityToUpdate))
            .Returns(BookingModelData.GetBookingModelToUpdate);

        // Act
        var result = await _bookingService.Update(BookingModelData.GetBookingModelToUpdate);

        // Assert
        _bookingRepoMock.Verify(r => r.Update(BookingEntityData.GetBookingEntityToUpdate));
        result.Should().NotBeNull();
        result.Should().BeOfType<BookingModel>();
        result.Should().NotBeEquivalentTo(BookingModelData.GetBookingModel);
    }

    [Theory]
    [InlineData("c839050c-e854-414a-93ea-f558e993e75e", "2024-03-01", "2025-01-01")]
    [InlineData("c839050c-e854-414a-93ea-f558e993e75e", "2024-03-01", "2026-01-01")]
    public async Task GetParticularBookings_WhenBookingDataIsCorrect_ShouldReturnListOfModels(string hotelId,
        string bookingFrom, string bookingTo)
    {
        // Arrange
        var correctHotelId = Guid.Parse(hotelId);
        var correctBookingFrom = DateTime.Parse(bookingFrom);
        var correctBookingTo = DateTime.Parse(bookingTo);

        _bookingRepoMock
            .Setup(r => r.GetParticularBookings(correctHotelId, correctBookingFrom, correctBookingTo))
            .ReturnsAsync(BookingEntityData.SortedList(correctHotelId, correctBookingFrom, correctBookingTo));
        _mapperMock.Setup(m => m.Map<List<BookingEntity>>(It.IsAny<List<BookingModel>>()))
            .Returns(BookingEntityData.SortedList(correctHotelId, correctBookingFrom, correctBookingTo));
        _mapperMock.Setup(m => m.Map<List<BookingModel>>(It.IsAny<List<BookingEntity>>()))
            .Returns(BookingModelData.SortedList(correctHotelId, correctBookingFrom, correctBookingTo));

        // Act
        var result =
            await _bookingService.GetParticularBookings(correctHotelId, correctBookingFrom, correctBookingTo);

        // Assert
        _bookingRepoMock.Verify(r =>
            r.GetParticularBookings(correctHotelId, correctBookingFrom, correctBookingTo));
        result.Should().NotBeNull();
        result.Should().BeOfType<List<BookingModel>>();
        result.Should()
            .BeEquivalentTo(BookingModelData.SortedList(correctHotelId, correctBookingFrom, correctBookingTo));
    }

    [Theory]
    [InlineData("c839050c-e854-414a-93ea-f558e993e75e", "2020-03-01", "2026-01-01")]
    [InlineData("c839050c-e854-414a-93ea-f558e993e75e", "2023-06-01", "2022-01-01")]
    public async Task GetParticularBookings_WhenBookingDatesIsIncorrect_ShouldReturnException(string hotelId,
        string bookingFrom, string bookingTo)
    {
        // Arrange
        var correctHotelId = Guid.Parse(hotelId);
        var correctBookingFrom = DateTime.Parse(bookingFrom);
        var correctBookingTo = DateTime.Parse(bookingTo);

        _bookingRepoMock
            .Setup(r => r.GetParticularBookings(correctHotelId, correctBookingFrom, correctBookingTo))
            .ReturnsAsync(BookingEntityData.SortedList(correctHotelId, correctBookingFrom, correctBookingTo));
        _mapperMock.Setup(m => m.Map<List<BookingEntity>>(It.IsAny<List<BookingModel>>()))
            .Returns(BookingEntityData.SortedList(correctHotelId, correctBookingFrom, correctBookingTo));
        _mapperMock.Setup(m => m.Map<List<BookingModel>>(It.IsAny<List<BookingEntity>>()))
            .Returns(BookingModelData.SortedList(correctHotelId, correctBookingFrom, correctBookingTo));

        // Act + Assert
        await Assert.ThrowsAsync<ArgumentException>(async () =>
            await _bookingService.GetParticularBookings(correctHotelId, correctBookingFrom, correctBookingTo));
    }
}
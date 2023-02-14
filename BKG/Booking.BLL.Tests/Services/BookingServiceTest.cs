﻿using AutoMapper;
using Booking.BLL.Abstractions;
using Booking.BLL.Models;
using Booking.BLL.Services;
using Booking.BLL.Tests.AutoData.Entities;
using Booking.BLL.Tests.AutoData.Models;
using Booking.DAL.Abstractions;
using Booking.DAL.Entities;
using Moq;
using Shouldly;

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
        result.ShouldNotBeNull();
        result.Count.ShouldBe(11);
    }

    [Theory]
    [InlineData("35edf9c3-7bb7-40b7-9ead-41ec4efec537")]
    [InlineData("489e445b-e68b-4324-8b1e-4e2b01f03cdc")]
    public async Task GetById_WhenEntityNotExist_ShouldReturnNull_Async(string id)
    {
        // Act
        var guidId = Guid.Parse(id);
        _bookingRepository.Setup(r => r.GetByIdAsync(guidId))
            .ReturnsAsync(value: null);

        // Arrange

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () => await _bookingService.GetByIdAsync(guidId));
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
        result.ShouldNotBeNull();
        result.ShouldBeOfType<BookingModel>();
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
        result.ShouldNotBeNull();
        result.ShouldBeOfType<BookingModel>();
    }

    [Theory]
    [InlineData("35edf9c3-7bb7-40b7-9ead-41ec4efec537")]
    [InlineData("489e445b-e68b-4324-8b1e-4e2b01f03cdc")]
    public async Task DeleteById_WhenEntityNotExist_ShouldReturnNull_Async(string id)
    {
        // Act
        var guidId = Guid.Parse(id);
        _bookingRepository.Setup(r => r.GetByIdAsync(guidId))
            .ReturnsAsync(value: null);

        // Arrange
        var result = await _bookingService.DeleteAsync(guidId);

        result.ShouldBeNull();
    }

    [Fact]
    public async Task DeleteById_WhenEntityExist_ShouldReturnModel_Async()
    {
        // Act
        _bookingRepository.Setup(r => r.GetByIdAsync(BookingEntityData.GetBookingEntity.Id))
            .ReturnsAsync(BookingEntityData.GetBookingEntity);
        _bookingRepository.Setup(r => r.DeleteAsync(BookingEntityData.GetBookingEntity.Id));
        _mapper.Setup(m => m.Map<BookingModel>(It.IsAny<BookingEntity>()))
            .Returns(BookingModelData.GetBookingModel);

        // Arrange
        var result = await _bookingService.DeleteAsync(BookingEntityData.GetBookingEntity.Id);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<BookingModel>();
    }

    [Fact]
    public async Task Update_WhenBookingModelIsSet_ShouldReturnCorrectModel_Async()
    {
        // Act
        _mapper.Setup(m => m.Map<BookingEntity>(BookingModelData.GetBookingModel))
            .Returns(BookingEntityData.GetBookingEntity);
        _bookingRepository.Setup(r => r.UpdateAsync(BookingEntityData.GetBookingEntity))
            .ReturnsAsync(BookingEntityData.GetBookingEntity);
        _mapper.Setup(m => m.Map<BookingModel>(BookingEntityData.GetBookingEntity))
            .Returns(BookingModelData.GetBookingModel);

        // Arrange
        var result = await _bookingService.UpdateAsync(BookingModelData.GetBookingModel);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<BookingModel>();
    }

    [Theory]
    [InlineData("c839050c-e854-414a-93ea-f558e993e75e", "2023-03-01", "2024-01-01")]
    [InlineData("c839050c-e854-414a-93ea-f558e993e75e", "2023-03-01", "2026-01-01")]
    [InlineData("c839050c-e854-414a-93ea-f558e993e75e", "2023-06-01", "2026-01-01")]
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

        // Act
        result.ShouldNotBeNull();
        result.ShouldBeOfType<List<BookingModel>>();
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

        // Arrange

        // Act
        await Assert.ThrowsAsync<ArgumentException>(async () =>
            await _bookingService.GetParticularBookingsAsync(correctHotelId, correctBookingFrom, correctBookingTo));
    }
}
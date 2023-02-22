using AutoMapper;
using Booking.API.Mapping;
using Booking.BLL.Models;
using FluentAssertions;

namespace Booking.API.Tests.Mapping;

public class BookingViewModelMappingTest
{
    [Fact]
    public void BookingViewModelMapping_ValidMappingConfiguration_ReturnsIsValid()
    {
        // Arrange
        var config = new MapperConfiguration(cfg => cfg.AddProfile<BookingViewModelMapping>());
        var mapper = config.CreateMapper();
        var bookingViewModel = BookingViewModelData.ValidViewModelForMapping;

        // Act
        var result = mapper.Map<BookingModel>(bookingViewModel);

        // Assert
        result.Should().BeOfType<BookingModel>();
        result.Should().BeEquivalentTo(bookingViewModel);
    }

    [Fact]
    public void BookingViewModelMapping_InvalidMappingConfiguration_ReturnsException()
    {
        // Arrange
        var config = new MapperConfiguration(cfg => cfg.AddProfile<BookingViewModelMapping>());
        var mapper = config.CreateMapper();
        var hotelViewModel = HotelViewModelData.ValidViewModelForMapping;

        // Act + Assert
        Assert.Throws<AutoMapperMappingException>(() => mapper.Map<BookingModel>(hotelViewModel));
    }

    [Fact]
    public void BookingViewModelMapping_WithEmptyProperties_ReturnsIsValid()
    {
        // Arrange
        var config = new MapperConfiguration(cfg => cfg.AddProfile<BookingViewModelMapping>());
        var mapper = config.CreateMapper();
        var bookingViewModel = BookingViewModelData.ViewModelWithEmptyPropertiesForMapping;

        // Act
        var result = mapper.Map<BookingModel>(bookingViewModel);

        // Assert
        result.Should().BeOfType<BookingModel>();
        result.Should().BeEquivalentTo(bookingViewModel);
    }
}
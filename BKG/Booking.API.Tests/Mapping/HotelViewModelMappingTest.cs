using AutoMapper;
using Booking.API.Mapping;
using Booking.BLL.Models;
using FluentAssertions;

namespace Booking.API.Tests.Mapping
{
    public class HotelViewModelMappingTest
    {
        [Fact]
        public void HotelViewModelMapping_ValidMappingConfiguration_ReturnsIsValid()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<HotelViewModelMapping>());
            var mapper = config.CreateMapper();
            var hotelViewModel = HotelViewModelData.ValidViewModelForMapping;

            // Act
            var result = mapper.Map<HotelModel>(hotelViewModel);

            // Assert
            result.Should().BeOfType<HotelModel>();
            result.Should().BeEquivalentTo(hotelViewModel);
        }

        [Fact]
        public void HotelViewModelMapping_InvalidMappingConfiguration_ReturnsException()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<HotelViewModelMapping>());
            var mapper = config.CreateMapper();
            var bookingViewModel = BookingViewModelData.ValidViewModelForMapping;

            // Act + Assert
            Assert.Throws<AutoMapperMappingException>(() => mapper.Map<HotelModel>(bookingViewModel));
        }

        [Fact]
        public void HotelViewModelMapping_WithEmptyProperties_ReturnsIsValid()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<HotelViewModelMapping>());
            var mapper = config.CreateMapper();
            var hotelViewModel = HotelViewModelData.ViewModelWithEmptyPropertiesForMapping;

            // Act
            var result = mapper.Map<HotelModel>(hotelViewModel);

            // Assert
            result.Should().BeOfType<HotelModel>();
            result.Should().BeEquivalentTo(hotelViewModel);
        }
    }
}

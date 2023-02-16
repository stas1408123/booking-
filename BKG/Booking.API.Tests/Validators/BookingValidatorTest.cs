using Booking.API.Tests.AutoData.ViewModels;
using Booking.API.Validators;
using Booking.API.ViewModels;
using FluentValidation.TestHelper;

namespace Booking.API.Tests.Validators
{
    public class BookingValidatorTest
    {
        private readonly BookingValidator _validator;

        public BookingValidatorTest()
        {
            _validator = new BookingValidator();
        }

        [Fact]
        public void Should_HaveErrorWhen_BookingFromHaveThePastDate()
        {
            // Act
            var viewModel = BookingViewModelData.GetInCorrectBookingFrom;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(booking => booking.BookingFrom);
        }

        [Fact]
        public void Should_NotHaveErrorWhen_BookingFromHaveCorrectDate()
        {
            // Act
            var viewModel = BookingViewModelData.GetCorrectBookingFrom;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldNotHaveValidationErrorFor(booking => booking.BookingFrom);
        }

        [Fact]
        public void Should_HaveErrorWhen_BookingToHaveThePastDate()
        {
            // Act
            var viewModel = BookingViewModelData.GetInCorrectBookingTo;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(booking => booking.BookingTo);
        }

        [Fact]
        public void Should_NotHaveErrorWhen_BookingToHaveCorrectDate()
        {
            // Act
            var viewModel = BookingViewModelData.GetCorrectBookingTo;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldNotHaveValidationErrorFor(booking => booking.BookingTo);
        }

        [Fact]
        public void Should_HaveErrorWhen_DescriptionIsNull()
        {
            // Act
            var viewModel = BookingViewModelData.GetNullDescription;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(booking => booking.Description);
        }

        [Fact]
        public void Should_HaveErrorWhen_DescriptionIsEmpty()
        {
            // Act
            var viewModel = BookingViewModelData.GetEmptyDescription;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(booking => booking.Description);
        }

        [Fact]
        public void Should_NotHaveErrorWhen_DescriptionIsCorrect()
        {
            // Act
            var viewModel = BookingViewModelData.GetCorrectDescription;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldNotHaveValidationErrorFor(booking => booking.Description);
        }

        [Fact]
        public void Should_HaveErrorWhen_PriceIsInCorrect()
        {
            // Act
            var viewModel = BookingViewModelData.GetInCorrectPrice;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(booking => booking.Price);
        }

        [Fact]
        public void Should_NotHaveErrorWhen_PriceIsCorrect()
        {
            // Act
            var viewModel = BookingViewModelData.GetCorrectPrice;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldNotHaveValidationErrorFor(booking => booking.Price);
        }

        [Fact]
        public void Should_HaveErrorWhen_HotelIdIsEmpty()
        {
            // Act
            var viewModel = BookingViewModelData.GetEmptyHotelId;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(booking => booking.HotelId);
        }

        [Fact]
        public void Should_NotHaveErrorWhen_HotelIdIsCorrect()
        {
            // Act
            var viewModel = BookingViewModelData.GetCorrectHotelId;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldNotHaveValidationErrorFor(booking => booking.HotelId);
        }
    }
}

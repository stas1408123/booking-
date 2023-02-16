using Booking.API.Tests.AutoData.ViewModels;
using Booking.API.Validators;
using FluentValidation.TestHelper;

namespace Booking.API.Tests.Validators;

public class BookingValidatorTest
{
    private readonly BookingValidator _validator;

    public BookingValidatorTest()
    {
        _validator = new BookingValidator();
    }

    [Fact]
    public void BookingValidator_BookingFromHaveThePastDate_ShouldHaveError()
    {
        // Act
        var viewModel = BookingViewModelData.GetInvalidBookingFrom;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(booking => booking.BookingFrom);
    }

    [Fact]
    public void BookingValidator_BookingFromHaveValidDate_ShouldNotHaveError()
    {
        // Act
        var viewModel = BookingViewModelData.GetValidBookingFrom;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(booking => booking.BookingFrom);
    }

    [Fact]
    public void BookingValidator_BookingToHaveThePastDate_ShouldHaveError()
    {
        // Act
        var viewModel = BookingViewModelData.GetInvalidBookingTo;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(booking => booking.BookingTo);
    }

    [Fact]
    public void BookingValidator_BookingToHaveValidDate_ShouldNotHaveError()
    {
        // Act
        var viewModel = BookingViewModelData.GetValidBookingTo;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(booking => booking.BookingTo);
    }

    [Fact]
    public void BookingValidator_DescriptionIsNull_ShouldHaveError()
    {
        // Act
        var viewModel = BookingViewModelData.GetNullDescription;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(booking => booking.Description);
    }

    [Fact]
    public void BookingValidator_DescriptionIsEmpty_ShouldHaveError()
    {
        // Act
        var viewModel = BookingViewModelData.GetEmptyDescription;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(booking => booking.Description);
    }

    [Fact]
    public void BookingValidator_DescriptionIsValid_ShouldNotHaveError()
    {
        // Act
        var viewModel = BookingViewModelData.GetValidDescription;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(booking => booking.Description);
    }

    [Fact]
    public void BookingValidator_PriceIsInvalid_ShouldHaveError()
    {
        // Act
        var viewModel = BookingViewModelData.GetInvalidPrice;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(booking => booking.Price);
    }

    [Fact]
    public void BookingValidator_PriceIsValid_ShouldNotHaveError()
    {
        // Act
        var viewModel = BookingViewModelData.GetValidPrice;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(booking => booking.Price);
    }

    [Fact]
    public void BookingValidator_HotelIdIsEmpty_ShouldHaveError()
    {
        // Act
        var viewModel = BookingViewModelData.GetEmptyHotelId;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(booking => booking.HotelId);
    }

    [Fact]
    public void BookingValidator_HotelIdIsValid_ShouldNotHaveError()
    {
        // Act
        var viewModel = BookingViewModelData.GetValidHotelId;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(booking => booking.HotelId);
    }
}
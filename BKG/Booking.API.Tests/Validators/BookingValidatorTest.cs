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
        var viewModel = BookingViewModelData.GetInCorrectBookingFrom;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(booking => booking.BookingFrom);
    }

    [Fact]
    public void BookingValidator_BookingFromHaveCorrectDate_ShouldNotHaveError()
    {
        // Act
        var viewModel = BookingViewModelData.GetCorrectBookingFrom;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(booking => booking.BookingFrom);
    }

    [Fact]
    public void BookingValidator_BookingToHaveThePastDate_ShouldHaveError()
    {
        // Act
        var viewModel = BookingViewModelData.GetInCorrectBookingTo;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(booking => booking.BookingTo);
    }

    [Fact]
    public void BookingValidator_BookingToHaveCorrectDate_ShouldNotHaveError()
    {
        // Act
        var viewModel = BookingViewModelData.GetCorrectBookingTo;

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
    public void BookingValidator_DescriptionIsCorrect_ShouldNotHaveError()
    {
        // Act
        var viewModel = BookingViewModelData.GetCorrectDescription;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(booking => booking.Description);
    }

    [Fact]
    public void BookingValidator_PriceIsInCorrect_ShouldHaveError()
    {
        // Act
        var viewModel = BookingViewModelData.GetInCorrectPrice;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(booking => booking.Price);
    }

    [Fact]
    public void BookingValidator_PriceIsCorrect_ShouldNotHaveError()
    {
        // Act
        var viewModel = BookingViewModelData.GetCorrectPrice;

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
    public void BookingValidator_HotelIdIsCorrect_ShouldNotHaveError()
    {
        // Act
        var viewModel = BookingViewModelData.GetCorrectHotelId;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(booking => booking.HotelId);
    }
}
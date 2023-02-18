using Booking.API.Tests.AutoData.ViewModels;
using Booking.API.Validators;

namespace Booking.API.Tests.Validators;

public class BookingValidatorTest
{
    private readonly BookingValidator _validator;

    public BookingValidatorTest()
    {
        _validator = new BookingValidator();
    }

    [Fact]
    public void BookingValidator_BookingFromHaveThePastDate_ReturnsError()
    {
        // Arrange
        var viewModel = BookingViewModelData.GetInvalidBookingFrom;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(booking => booking.BookingFrom);
    }

    [Fact]
    public void BookingValidator_BookingFromHaveValidDate_ReturnsNotError()
    {
        // Arrange
        var viewModel = BookingViewModelData.GetValidBookingFrom;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(booking => booking.BookingFrom);
    }

    [Fact]
    public void BookingValidator_BookingToHaveThePastDate_ReturnsError()
    {
        // Arrange
        var viewModel = BookingViewModelData.GetInvalidBookingTo;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(booking => booking.BookingTo);
    }

    [Fact]
    public void BookingValidator_BookingToHaveValidDate_ReturnsNotError()
    {
        // Arrange
        var viewModel = BookingViewModelData.GetValidBookingTo;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(booking => booking.BookingTo);
    }

    [Fact]
    public void BookingValidator_DescriptionIsNull_ReturnsError()
    {
        // Arrange
        var viewModel = BookingViewModelData.GetNullDescription;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(booking => booking.Description);
    }

    [Fact]
    public void BookingValidator_DescriptionIsEmpty_ReturnsError()
    {
        // Arrange
        var viewModel = BookingViewModelData.GetEmptyDescription;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(booking => booking.Description);
    }

    [Fact]
    public void BookingValidator_DescriptionIsValid_ReturnsNotError()
    {
        // Arrange
        var viewModel = BookingViewModelData.GetValidDescription;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(booking => booking.Description);
    }

    [Fact]
    public void BookingValidator_PriceIsInvalid_ReturnsError()
    {
        // Arrange
        var viewModel = BookingViewModelData.GetInvalidPrice;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(booking => booking.Price);
    }

    [Fact]
    public void BookingValidator_PriceIsValid_ReturnsNotError()
    {
        // Arrange
        var viewModel = BookingViewModelData.GetValidPrice;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(booking => booking.Price);
    }

    [Fact]
    public void BookingValidator_HotelIdIsEmpty_ReturnsError()
    {
        // Arrange
        var viewModel = BookingViewModelData.GetEmptyHotelId;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(booking => booking.HotelId);
    }

    [Fact]
    public void BookingValidator_HotelIdIsValid_ReturnsNotError()
    {
        // Arrange
        var viewModel = BookingViewModelData.GetValidHotelId;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(booking => booking.HotelId);
    }
}
using Booking.API.Tests.AutoData.ViewModels;
using Booking.API.Validators;

namespace Booking.API.Tests.Validators;

public class HotelValidatorTest
{
    private readonly HotelValidator _validator;

    public HotelValidatorTest()
    {
        _validator = new HotelValidator();
    }

    [Fact]
    public void HotelValidator_TitleIsNull_ReturnsError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetNullTitle;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Title);
    }

    [Fact]
    public void HotelValidator_TitleIsEmpty_ReturnsError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetEmptyTitle;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Title);
    }

    [Fact]
    public void HotelValidator_TitleLengthIsInvalid_ReturnsError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetInvalidLengthTitle;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Title);
    }

    [Fact]
    public void HotelValidator_TitleIsValid_ReturnsNotError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetValidTitle;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(hotel => hotel.Title);
    }

    [Fact]
    public void HotelValidator_AddressIsNull_ReturnsError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetNullAddress;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Address);
    }

    [Fact]
    public void HotelValidator_AddressIsEmpty_ReturnsError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetEmptyAddress;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Address);
    }

    [Fact]
    public void HotelValidator_AddressIsValid_ReturnsNotError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetValidAddress;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(hotel => hotel.Address);
    }

    [Fact]
    public void HotelValidator_CountRoomsIsTooFew_ReturnsError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetTooFewCountRooms;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.CountRooms);
    }

    [Fact]
    public void HotelValidator_CountRoomsIsTooMuch_ReturnsError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetTooMuchCountRooms;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.CountRooms);
    }

    [Fact]
    public void HotelValidator_CountRoomsIsValid_ReturnsNotError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetValidCountRooms;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(hotel => hotel.CountRooms);
    }

    [Fact]
    public void HotelValidator_DescriptionIsNull_ReturnsError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetNullDescription;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Description);
    }

    [Fact]
    public void HotelValidator_DescriptionIsEmpty_ReturnsError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetEmptyDescription;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Description);
    }

    [Fact]
    public void HotelValidator_DescriptionIsValid_ReturnsNotError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetValidDescription;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(hotel => hotel.Description);
    }

    [Fact]
    public void HotelValidator_StarsIsTooSmall_ReturnsError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetTooSmallStars;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Stars);
    }

    [Fact]
    public void HotelValidator_StarsIsTooBig_ReturnsError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetTooBigStars;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Stars);
    }

    [Fact]
    public void HotelValidator_StarsIsValid_ReturnsNotError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetValidStars;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(hotel => hotel.Stars);
    }

    [Fact]
    public void HotelValidator_PhoneNumberIsNull_ReturnsError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetNullPhoneNumber;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.PhoneNumber);
    }

    [Fact]
    public void HotelValidator_PhoneNumberIsEmpty_ReturnsError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetEmptyPhoneNumber;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.PhoneNumber);
    }

    [Fact]
    public void HotelValidator_PhoneNumberLengthIsTooShort_ReturnsError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetTooShortLengthPhoneNumber;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.PhoneNumber);
    }

    [Fact]
    public void HotelValidator_PhoneNumberLengthIsTooBig_ReturnsError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetTooBigLengthPhoneNumber;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.PhoneNumber);
    }

    [Fact]
    public void HotelValidator_PhoneNumberIsInvalid_ReturnsError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetInvalidPhoneNumber;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.PhoneNumber);
    }

    [Fact]
    public void HotelValidator_PhoneNumberIsValid_ReturnsNotError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetValidPhoneNumber;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(hotel => hotel.PhoneNumber);
    }

    [Fact]
    public void HotelValidator_OwnerIsNull_ReturnsError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetNullOwner;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Owner);
    }

    [Fact]
    public void HotelValidator_OwnerIsEmpty_ReturnsError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetValidPhoneNumber;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Owner);
    }

    [Fact]
    public void HotelValidator_OwnerIsValid_ReturnsNotError()
    {
        // Arrange
        var viewModel = HotelViewModelData.GetCorrectOwner;

        // Act
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(hotel => hotel.Owner);
    }
}
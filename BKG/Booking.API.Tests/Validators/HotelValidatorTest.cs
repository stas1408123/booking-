using Booking.API.Tests.AutoData.ViewModels;
using Booking.API.Validators;
using FluentValidation.TestHelper;

namespace Booking.API.Tests.Validators;

public class HotelValidatorTest
{
    private readonly HotelValidator _validator;

    public HotelValidatorTest()
    {
        _validator = new HotelValidator();
    }

    [Fact]
    public void HotelValidator_TitleIsNull_ShouldHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetNullTitle;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Title);
    }

    [Fact]
    public void HotelValidator_TitleIsEmpty_ShouldHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetEmptyTitle;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Title);
    }

    [Fact]
    public void HotelValidator_TitleLengthIsInCorrect_ShouldHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetInCorrectLengthTitle;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Title);
    }

    [Fact]
    public void HotelValidator_TitleIsCorrect_ShouldNotHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetCorrectTitle;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(hotel => hotel.Title);
    }

    [Fact]
    public void HotelValidator_AddressIsNull_ShouldHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetNullAddress;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Address);
    }

    [Fact]
    public void HotelValidator_AddressIsEmpty_ShouldHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetEmptyAddress;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Address);
    }

    [Fact]
    public void HotelValidator_AddressIsCorrect_NotHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetCorrectAddress;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(hotel => hotel.Address);
    }

    [Fact]
    public void HotelValidator_CountRoomsIsTooFew_ShouldHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetTooFewCountRooms;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.CountRooms);
    }

    [Fact]
    public void HotelValidator_CountRoomsIsTooMuch_ShouldHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetTooMuchCountRooms;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.CountRooms);
    }

    [Fact]
    public void HotelValidator_CountRoomsIsCorrect_ShouldNotHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetCorrectCountRooms;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(hotel => hotel.CountRooms);
    }

    [Fact]
    public void HotelValidator_DescriptionIsNull_ShouldHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetNullDescription;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Description);
    }

    [Fact]
    public void HotelValidator_DescriptionIsEmpty_ShouldHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetEmptyDescription;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Description);
    }

    [Fact]
    public void HotelValidator_DescriptionIsCorrect_ShouldNotHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetCorrectDescription;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(hotel => hotel.Description);
    }

    [Fact]
    public void HotelValidator_StarsIsTooSmall_ShouldHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetTooSmallStars;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Stars);
    }

    [Fact]
    public void HotelValidator_StarsIsTooBig_ShouldHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetTooBigStars;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Stars);
    }

    [Fact]
    public void HotelValidator_StarsIsCorrect_ShouldNotHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetCorrectStars;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(hotel => hotel.Stars);
    }

    [Fact]
    public void HotelValidator_PhoneNumberIsNull_ShouldHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetNullPhoneNumber;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.PhoneNumber);
    }

    [Fact]
    public void HotelValidator_PhoneNumberIsEmpty_ShouldHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetEmptyPhoneNumber;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.PhoneNumber);
    }

    [Fact]
    public void HotelValidator_PhoneNumberLengthIsTooShort_ShouldHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetTooShortLengthPhoneNumber;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.PhoneNumber);
    }

    [Fact]
    public void HotelValidator_PhoneNumberLengthIsTooBig_ShouldHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetTooBigLengthPhoneNumber;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.PhoneNumber);
    }

    [Fact]
    public void HotelValidator_PhoneNumberIsNotValid_ShouldHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetNotValidPhoneNumber;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.PhoneNumber);
    }

    [Fact]
    public void HotelValidator_PhoneNumberIsCorrect_ShouldNotHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetCorrectPhoneNumber;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(hotel => hotel.PhoneNumber);
    }

    [Fact]
    public void HotelValidator_OwnerIsNull_ShouldHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetNullOwner;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Owner);
    }

    [Fact]
    public void HotelValidator_OwnerIsEmpty_ShouldHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetCorrectPhoneNumber;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldHaveValidationErrorFor(hotel => hotel.Owner);
    }

    [Fact]
    public void HotelValidator_OwnerIsCorrect_ShouldNotHaveError()
    {
        // Act
        var viewModel = HotelViewModelData.GetCorrectOwner;

        // Arrange
        var result = _validator.TestValidate(viewModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(hotel => hotel.Owner);
    }
}
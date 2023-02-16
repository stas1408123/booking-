using Booking.API.Tests.AutoData.ViewModels;
using Booking.API.Validators;
using FluentValidation.TestHelper;

namespace Booking.API.Tests.Validators
{
    public class HotelValidatorTest
    {
        private readonly HotelValidator _validator;

        public HotelValidatorTest()
        {
            _validator = new HotelValidator();
        }

        [Fact]
        public void Should_HaveErrorWhen_TitleIsNull()
        {
            // Act
            var viewModel = HotelViewModelData.GetNullTitle;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(hotel => hotel.Title);
        }

        [Fact]
        public void Should_HaveErrorWhen_TitleIsEmpty()
        {
            // Act
            var viewModel = HotelViewModelData.GetEmptyTitle;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(hotel => hotel.Title);
        }

        [Fact]
        public void Should_HaveErrorWhen_TitleLengthIsInCorrect()
        {
            // Act
            var viewModel = HotelViewModelData.GetInCorrectLengthTitle;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(hotel => hotel.Title);
        }

        [Fact]
        public void Should_NotHaveErrorWhen_TitleIsCorrect()
        {
            // Act
            var viewModel = HotelViewModelData.GetCorrectTitle;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldNotHaveValidationErrorFor(hotel => hotel.Title);
        }

        [Fact]
        public void Should_HaveErrorWhen_AddressIsNull()
        {
            // Act
            var viewModel = HotelViewModelData.GetNullAddress;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(hotel => hotel.Address);
        }

        [Fact]
        public void Should_HaveErrorWhen_AddressIsEmpty()
        {
            // Act
            var viewModel = HotelViewModelData.GetEmptyAddress;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(hotel => hotel.Address);
        }

        [Fact]
        public void Should_NotHaveErrorWhen_AddressIsCorrect()
        {
            // Act
            var viewModel = HotelViewModelData.GetCorrectAddress;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldNotHaveValidationErrorFor(hotel => hotel.Address);
        }

        [Fact]
        public void Should_HaveErrorWhen_CountRoomsIsTooFew()
        {
            // Act
            var viewModel = HotelViewModelData.GetTooFewCountRooms;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(hotel => hotel.CountRooms);
        }

        [Fact]
        public void Should_HaveErrorWhen_CountRoomsIsTooMuch()
        {
            // Act
            var viewModel = HotelViewModelData.GetTooMuchCountRooms;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(hotel => hotel.CountRooms);
        }

        [Fact]
        public void Should_NotHaveErrorWhen_CountRoomsIsCorrect()
        {
            // Act
            var viewModel = HotelViewModelData.GetCorrectCountRooms;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldNotHaveValidationErrorFor(hotel => hotel.CountRooms);
        }

        [Fact]
        public void Should_HaveErrorWhen_DescriptionIsNull()
        {
            // Act
            var viewModel = HotelViewModelData.GetNullDescription;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(hotel => hotel.Description);
        }

        [Fact]
        public void Should_HaveErrorWhen_DescriptionIsEmpty()
        {
            // Act
            var viewModel = HotelViewModelData.GetEmptyDescription;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(hotel => hotel.Description);
        }

        [Fact]
        public void Should_NotHaveErrorWhen_DescriptionIsCorrect()
        {
            // Act
            var viewModel = HotelViewModelData.GetCorrectDescription;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldNotHaveValidationErrorFor(hotel => hotel.Description);
        }

        [Fact]
        public void Should_HaveErrorWhen_StarsIsTooSmall()
        {
            // Act
            var viewModel = HotelViewModelData.GetTooSmallStars;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(hotel => hotel.Stars);
        }

        [Fact]
        public void Should_HaveErrorWhen_StarsIsTooBig()
        {
            // Act
            var viewModel = HotelViewModelData.GetTooBigStars;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(hotel => hotel.Stars);
        }

        [Fact]
        public void Should_NotHaveErrorWhen_StarsIsCorrect()
        {
            // Act
            var viewModel = HotelViewModelData.GetCorrectStars;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldNotHaveValidationErrorFor(hotel => hotel.Stars);
        }

        [Fact]
        public void Should_HaveErrorWhen_PhoneNumberIsNull()
        {
            // Act
            var viewModel = HotelViewModelData.GetNullPhoneNumber;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(hotel => hotel.PhoneNumber);
        }

        [Fact]
        public void Should_HaveErrorWhen_PhoneNumberIsEmpty()
        {
            // Act
            var viewModel = HotelViewModelData.GetEmptyPhoneNumber;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(hotel => hotel.PhoneNumber);
        }

        [Fact]
        public void Should_HaveErrorWhen_PhoneNumberLengthIsTooShort()
        {
            // Act
            var viewModel = HotelViewModelData.GetTooShortLengthPhoneNumber;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(hotel => hotel.PhoneNumber);
        }

        [Fact]
        public void Should_HaveErrorWhen_PhoneNumberLengthIsTooBig()
        {
            // Act
            var viewModel = HotelViewModelData.GetTooBigLengthPhoneNumber;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(hotel => hotel.PhoneNumber);
        }

        [Fact]
        public void Should_HaveErrorWhen_PhoneNumberIsNotValid()
        {
            // Act
            var viewModel = HotelViewModelData.GetNotValidPhoneNumber;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(hotel => hotel.PhoneNumber);
        }

        [Fact]
        public void Should_NotHaveErrorWhen_PhoneNumberIsCorrect()
        {
            // Act
            var viewModel = HotelViewModelData.GetCorrectPhoneNumber;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldNotHaveValidationErrorFor(hotel => hotel.PhoneNumber);
        }

        [Fact]
        public void Should_HaveErrorWhen_OwnerIsNull()
        {
            // Act
            var viewModel = HotelViewModelData.GetNullOwner;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(hotel => hotel.Owner);
        }

        [Fact]
        public void Should_HaveErrorWhen_OwnerIsEmpty()
        {
            // Act
            var viewModel = HotelViewModelData.GetCorrectPhoneNumber;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldHaveValidationErrorFor(hotel => hotel.Owner);
        }

        [Fact]
        public void Should_NotHaveErrorWhen_OwnerIsCorrect()
        {
            // Act
            var viewModel = HotelViewModelData.GetCorrectOwner;

            // Arrange
            var result = _validator.TestValidate(viewModel);

            // Assert
            result.ShouldNotHaveValidationErrorFor(hotel => hotel.Owner);
        }
    }
}

using Booking.API.ViewModels;
using FluentValidation;

namespace Booking.API.Validators;

public class HotelValidator : AbstractValidator<HotelViewModel>
{
    public HotelValidator()
    {
        RuleFor(h => h.Title)
            .NotNull().NotEmpty().WithMessage("Title is required")
            .MaximumLength(20).WithMessage("Required maximum length is 20 symbols");
        RuleFor(h => h.Address)
            .NotNull().NotEmpty().WithMessage("Address is required");
        RuleFor(h => h.CountRooms)
            .NotNull().NotEmpty().WithMessage("Count rooms is required")
            .Must(r => r <= 1000).WithMessage("Count rooms cannot be more than 1000");
        RuleFor(h => h.Description)
            .NotNull().NotEmpty().WithMessage("Description is required");
        RuleFor(h => h.Owner)
            .NotNull().NotEmpty().WithMessage("Owner is required");
        RuleFor(h => h.Stars)
            .NotNull().NotEmpty().WithMessage("Stars is required")
            .Must(s => s is >= 1 and <= 5).WithMessage("Stars cannot be less than 1 and more than 5");
        RuleFor(h => h.PhoneNumber)
            .NotNull().NotEmpty().WithMessage("Phone number is required")
            .MinimumLength(10).WithMessage("Phone number length cannot be less than 10 numbers")
            .MaximumLength(20).WithMessage("Phone number length cannot be more than 20 numbers")
            .Matches(@"^\+\d{10}").WithMessage("Phone number is not valid");
    }
}
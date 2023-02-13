using Booking.API.ViewModels;
using FluentValidation;

namespace Booking.API.Validators;

public class GetParticularBookingsValidator : AbstractValidator<BookingViewModel>
{
    public GetParticularBookingsValidator()
    {
        RuleFor(b => b.BookingFrom)
            .NotNull().NotEmpty().WithMessage("Booking from is required")
            .Must(bf => bf >= DateTime.UtcNow).WithMessage("Booking from cannot be with past date or time");
        RuleFor(b => b.BookingTo)
            .NotNull().NotEmpty().WithMessage("Booking to is required")
            .Must(bt => bt >= DateTime.UtcNow).WithMessage("Booking to cannot be with past date or time");
        RuleFor(b => b.HotelId)
            .NotNull().NotEmpty().WithMessage("Hotel for booking is required");
    }
}
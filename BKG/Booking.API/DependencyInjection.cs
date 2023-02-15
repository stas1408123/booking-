using Booking.API.Mapping;
using Booking.API.Validators;
using Booking.BLL.DI;
using FluentValidation;

namespace Booking.API;

public static class DependencyInjection
{
    public static void AddApiAccessDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(BookingViewModelMapping).Assembly);
        services.AddValidatorsFromAssemblyContaining<BookingValidator>();
        services.AddBusinessAccessDependencies(configuration);
    }
}
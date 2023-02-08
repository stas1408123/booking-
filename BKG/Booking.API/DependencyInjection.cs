using Booking.API.Mapping;
using Booking.BLL.DI;

namespace Booking.API
{
    public static class DependencyInjection
    {
        public static void AddApiAccessDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(BookingViewModelMapping).Assembly);
            services.AddBusinessAccessDependencies(configuration);
        }
    }
}

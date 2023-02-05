using Booking.DAL.Repositories.Generic;

namespace Booking.API
{
    public static class DependencyInjection
    {
        public static void AddMyDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}

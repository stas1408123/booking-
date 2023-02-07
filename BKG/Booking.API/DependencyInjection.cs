using Booking.BLL.Services.Generic;
using Booking.DAL;
using Booking.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Booking.API
{
    public static class DependencyInjection
    {
        public static void AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookingDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
        }
    }
}

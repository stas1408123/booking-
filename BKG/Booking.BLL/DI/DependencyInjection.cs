using Booking.BLL.Mapping;
using Booking.BLL.Models;
using Booking.BLL.Services.Booking;
using Booking.BLL.Services.Generic;
using Booking.BLL.Services.Booking;
using Booking.DAL.DI;
using Booking.DAL.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.BLL.DI
{
    public static class DependencyInjection
    {
        public static void AddBusinessAccessDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IGenericService<HotelModel>, GenericService<HotelEntity, HotelModel>>();
            services.AddTransient<IGenericService<BookingModel>, GenericService<BookingEntity, BookingModel>>();
            services.AddTransient<IBookingService, BookingService>();
            services.AddAutoMapper(typeof(BookingModelMapping).Assembly);
            services.AddDataAccessDependencies(configuration);
        }
    }
}

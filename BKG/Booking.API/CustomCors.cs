namespace Booking.API
{
    public static class CustomCors
    {
        public static void AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", builder => builder
                    .WithOrigins("https://localhost:7291")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });
        }
    }
}

using Booking.API.Extensions;

namespace Booking.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddApiAccessDependencies(builder.Configuration);
        builder.Services.AddCustomCors();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        var logger = app.Services.GetRequiredService<ILogger<Program>>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("MyPolicy");

        app.ConfigureExceptionHandler(logger);

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

internal static class CustomExtensionsMethods
{
    public static IServiceCollection AddCustomCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("MyPolicy", builder => builder
                .WithOrigins("https://localhost:7291")
                .AllowAnyHeader()
                .AllowAnyMethod());
        });

        return services;
    }
}
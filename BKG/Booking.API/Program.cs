using Booking.API;
using Booking.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiAccessDependencies(builder.Configuration);
AddCustomCors();

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

void AddCustomCors()
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("MyPolicy", builder => builder
            .WithOrigins("https://localhost:7291")
            .AllowAnyHeader()
            .AllowAnyMethod());
    });
}
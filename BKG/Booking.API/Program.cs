using Booking.API;
using Booking.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiAccessDependencies(builder.Configuration);

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

app.ConfigureExceptionHandler(logger);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Booking.API;

namespace Booking.IntegrationTests.Controllers;

public class BookingControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public BookingControllerTest(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetAll()
    {
        // Act
        var client = _factory.CreateClient();

        // Arrange
        var response = await client.GetAsync("api/Booking");

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal("application/json; charset=utf-8",
            response.Content.Headers.ContentType?.ToString());
    }
}
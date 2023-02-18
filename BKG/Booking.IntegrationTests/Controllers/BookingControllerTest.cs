using System.Net;
using System.Text;
using Booking.API;
using Booking.DAL.Entities;
using Booking.IntegrationTests.AutoData;
using Newtonsoft.Json;

namespace Booking.IntegrationTests.Controllers;

public class BookingControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public BookingControllerTest(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetAll_BookingListIsExist_ReturnsEquals()
    {
        // Arrange
        var client = _factory.CreateClient();
        var expectedList = BookingTestData.CreateExpectedBookingList();

        // Act
        var response = await client.GetAsync("/api/Booking");
        var returnedList =
            JsonConvert.DeserializeObject<List<BookingEntity>>(await response.Content.ReadAsStringAsync());

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal("application/json; charset=utf-8",
            response.Content.Headers.ContentType?.ToString());
        Assert.Equal(expectedList, returnedList);
    }

    [Fact]
    public async Task GetById_BookingNotExist_ReturnsInternalServerError()
    {
        // Arrange
        var client = _factory.CreateClient();
        var expectedBooking = BookingTestData.ExpectedBooking;

        // Act
        var response = await client.GetAsync("api/Booking/78aaa6d0-f338-422f-9229-6cfad70ead05");
        var returnedBooking = JsonConvert.DeserializeObject<BookingEntity>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        Assert.NotEqual(expectedBooking.Description, returnedBooking.Description);
    }

    [Fact]
    public async Task GetById_BookingExist_ReturnsValidBooking()
    {
        // Arrange
        var client = _factory.CreateClient();
        var expectedBooking = BookingTestData.ExpectedBooking;

        // Act
        var response = await client.GetAsync("api/Booking/0c3db3ee-6f77-4b64-a5ec-27298749f421");
        var returnedBooking = JsonConvert.DeserializeObject<BookingEntity>(await response.Content.ReadAsStringAsync());

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal("application/json; charset=utf-8",
            response.Content.Headers.ContentType?.ToString());
        Assert.Equal(expectedBooking.Description, returnedBooking.Description);
    }

    [Fact]
    public async Task Add_BookingPropertiesIsValid_ReturnsValidBooking()
    {
        // Arrange
        var client = _factory.CreateClient();
        var bookingAddRequest = BookingTestData.ValidBookingToAdd;
        var stringContent = new StringContent(JsonConvert.SerializeObject(bookingAddRequest), Encoding.UTF8,
            "application/json");

        // Act
        var response = await client.PostAsync("api/Booking/add", stringContent);
        var returnedBooking = JsonConvert.DeserializeObject<BookingEntity>(await response.Content.ReadAsStringAsync());

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal("application/json; charset=utf-8",
            response.Content.Headers.ContentType?.ToString());
        Assert.Equal(bookingAddRequest.Description, returnedBooking.Description);
    }

    [Theory]
    [InlineData("2020-01-01", "2025-01-01", "valid", "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1,
        HttpStatusCode.InternalServerError)]
    [InlineData("2025-01-01", "2025-02-01", "valid", "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1,
        HttpStatusCode.InternalServerError)]
    [InlineData("2023-05-01", "2020-01-01", "valid", "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1,
        HttpStatusCode.InternalServerError)]
    [InlineData("2023-05-01", "2023-01-01", "valid", "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1,
        HttpStatusCode.InternalServerError)]
    [InlineData("2023-05-01", "2023-12-12", "", "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1,
        HttpStatusCode.InternalServerError)]
    [InlineData("2023-01-01", "2023-12-12", null, "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1,
        HttpStatusCode.InternalServerError)]
    [InlineData("2023-01-01", "2023-12-12", "valid", "00000000-0000-0000-0000-000000000000", 1,
        HttpStatusCode.InternalServerError)]
    [InlineData("2023-01-01", "2023-12-12", "valid", "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", -1,
        HttpStatusCode.InternalServerError)]
    public async Task Add_BookingPropertiesIsNotValid_ReturnsInternalServerError(string bookingFrom, string bookingTo,
        string description, string hotelId, decimal price,
        HttpStatusCode actualStatusCode)
    {
        // Arrange
        var client = _factory.CreateClient();
        var bookingAddRequest =
            BookingTestData.InvalidBookingToAdd(bookingFrom, bookingTo, description, price, hotelId);
        var stringContent = new StringContent(JsonConvert.SerializeObject(bookingAddRequest), Encoding.UTF8,
            "application/json");

        // Act
        var response = await client.PostAsync("api/Booking/add", stringContent);
        var returnedBooking = JsonConvert.DeserializeObject<BookingEntity>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.InternalServerError, actualStatusCode);
        Assert.NotEqual(bookingAddRequest, returnedBooking);
    }

    [Theory]
    [InlineData("0c3db3ee-6f77-4b64-a5ec-27298749f421", "2020-01-01", "2025-01-01", "valid",
        "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1,
        HttpStatusCode.InternalServerError)]
    [InlineData("0c3db3ee-6f77-4b64-a5ec-27298749f421", "2025-01-01", "2025-02-01", "valid",
        "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1,
        HttpStatusCode.InternalServerError)]
    [InlineData("0c3db3ee-6f77-4b64-a5ec-27298749f421", "2023-05-01", "2020-01-01", "valid",
        "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1,
        HttpStatusCode.InternalServerError)]
    [InlineData("0c3db3ee-6f77-4b64-a5ec-27298749f421", "2023-05-01", "2023-01-01", "valid",
        "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1,
        HttpStatusCode.InternalServerError)]
    [InlineData("0c3db3ee-6f77-4b64-a5ec-27298749f421", "2023-05-01", "2023-12-12", "",
        "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1,
        HttpStatusCode.InternalServerError)]
    [InlineData("0c3db3ee-6f77-4b64-a5ec-27298749f421", "2023-01-01", "2023-12-12", null,
        "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1,
        HttpStatusCode.InternalServerError)]
    [InlineData("0c3db3ee-6f77-4b64-a5ec-27298749f421", "2023-01-01", "2023-12-12", "valid",
        "00000000-0000-0000-0000-000000000000", 1,
        HttpStatusCode.InternalServerError)]
    [InlineData("0c3db3ee-6f77-4b64-a5ec-27298749f421", "2023-01-01", "2023-12-12", "valid",
        "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", -1,
        HttpStatusCode.InternalServerError)]
    public async Task Update_BookingPropertiesIsNotValid_ReturnsInternalServerError(string id, string bookingFrom,
        string bookingTo,
        string description, string hotelId, decimal price,
        HttpStatusCode actualStatusCode)
    {
        // Arrange
        var client = _factory.CreateClient();
        var bookingUpdateRequest =
            BookingTestData.InvalidBookingToUpdate(id, bookingFrom, bookingTo, description, price, hotelId);
        var stringContent = new StringContent(JsonConvert.SerializeObject(bookingUpdateRequest), Encoding.UTF8,
            "application/json");

        // Act
        var response = await client.PutAsync("api/Booking/update", stringContent);
        var returnedBooking = JsonConvert.DeserializeObject<BookingEntity>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.InternalServerError, actualStatusCode);
        Assert.NotEqual(bookingUpdateRequest, returnedBooking);
    }

    [Fact]
    public async Task Update_BookingPropertiesIsValid_ReturnsValidBooking()
    {
        // Arrange
        var client = _factory.CreateClient();
        var bookingUpdateRequest = BookingTestData.ValidBookingToUpdate;
        var stringContent = new StringContent(JsonConvert.SerializeObject(bookingUpdateRequest), Encoding.UTF8,
            "application/json");

        // Act
        var response = await client.PutAsync("api/Booking/update", stringContent);
        var returnedBooking = JsonConvert.DeserializeObject<BookingEntity>(await response.Content.ReadAsStringAsync());

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal("application/json; charset=utf-8",
            response.Content.Headers.ContentType?.ToString());
        Assert.Equal(bookingUpdateRequest.Description, returnedBooking.Description);
    }

    [Fact]
    public async Task Delete_BookingExist_ReturnsSuccess()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.DeleteAsync("api/Booking/delete/0c3db3ee-6f77-4b64-a5ec-27298749f421");

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Delete_BookingNotExist_ReturnsInternalServerError()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.DeleteAsync("api/Booking/delete/0c3db3ee-3277-4b64-a5ec-27298749f421");

        // Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }
}
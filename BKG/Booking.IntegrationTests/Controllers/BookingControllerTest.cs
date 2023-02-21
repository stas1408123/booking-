using System.Net;
using Booking.API;
using Booking.IntegrationTests.AutoData;
using FluentAssertions;

namespace Booking.IntegrationTests.Controllers;

public class BookingControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public BookingControllerTest(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetAll_BookingListIsExist_ReturnsValidList()
    {
        // Arrange
        var client = _factory.CreateClient();
        var expectedList = BookingTestData.ExpectedBookingList();
        BookingTestData.ReinitializeDbForTests(_factory);

        // Act
        var response = await client.GetAsync("/api/Booking");
        var returnedList = BookingTestData.GetBookingList(response).Result;

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        expectedList.Should().BeEquivalentTo(returnedList);
    }

    [Fact]
    public async Task GetParticularBookings_BookingsIsValid_ReturnsValidBookingList()
    {
        // Arrange
        var client = _factory.CreateClient();
        var getParticularBookings = BookingTestData.ValidGetParticularBookings;
        var expectedList = BookingTestData.ExpectedGetParticularBookings();
        var stringContent = BookingTestData.NewStringContent(getParticularBookings);

        // Act
        var response = await client.PostAsync("/api/Booking/get-particular-bookings", stringContent);
        var returnedList = BookingTestData.GetBookingList(response).Result;

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        returnedList.Should().BeEquivalentTo(expectedList);
    }

    [Theory]
    [InlineData("d990989f-bd61-450d-a6e9-b8eed2fd5ba2", "2020-01-01", "2026-01-01")]
    [InlineData("d990989f-bd61-450d-a6e9-b8eed2fd5ba2", "2026-01-01", "2020-01-01")]
    public async Task GetParticularBookings_BookingsIsInvalid_ReturnsInternalServerError(string hotelId,
        string bookingFrom, string bookingTo)
    {
        // Arrange
        var client = _factory.CreateClient();
        var getParticularBookings = BookingTestData.InvalidGetParticularBookings(hotelId, bookingFrom, bookingTo);
        var stringContent = BookingTestData.NewStringContent(getParticularBookings);

        // Act
        var response = await client.PostAsync("/api/Booking/get-particular-bookings", stringContent);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
    }

    [Fact]
    public async Task GetById_BookingNotExist_ReturnsInternalServerError()
    {
        // Arrange
        var client = _factory.CreateClient();
        var expectedBooking = BookingTestData.ExpectedBooking;

        // Act
        var response = await client.GetAsync("api/Booking/78aaa6d0-f338-422f-9229-6cfad70ead05");
        var returnedBooking = BookingTestData.GetByIdBooking(response).Result;

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        returnedBooking.Should().NotBeEquivalentTo(expectedBooking);
    }

    [Fact]
    public async Task GetById_BookingExist_ReturnsValidBooking()
    {
        // Arrange
        var client = _factory.CreateClient();
        var expectedBooking = BookingTestData.ExpectedBooking;

        // Act
        var response = await client.GetAsync("api/Booking/0c3db3ee-6f77-4b64-a5ec-27298749f421");
        var returnedBooking = BookingTestData.GetByIdBooking(response).Result;

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        returnedBooking.Should().BeEquivalentTo(expectedBooking);
    }

    [Fact]
    public async Task Add_BookingPropertiesIsValid_ReturnsValidBooking()
    {
        // Arrange
        var client = _factory.CreateClient();
        var bookingAddRequest = BookingTestData.ValidBookingToAdd;
        var stringContent = BookingTestData.NewStringContent(bookingAddRequest);

        // Act
        var response = await client.PostAsync("api/Booking/add", stringContent);
        var returnedBooking = BookingTestData.GetByIdBooking(response).Result;

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        returnedBooking.Should().BeEquivalentTo(bookingAddRequest);
    }

    [Theory]
    [InlineData("2020-01-01", "2025-01-01", "valid", "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1)]
    [InlineData("2023-05-01", "2020-01-01", "valid", "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1)]
    [InlineData("2023-05-01", "2023-12-12", "", "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1)]
    [InlineData("2023-05-01", "2023-12-12", null, "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1)]
    [InlineData("2023-05-01", "2023-12-12", "valid", "00000000-0000-0000-0000-000000000000", 1)]
    [InlineData("2023-05-01", "2023-12-12", null, "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", -1)]
    public async Task Add_BookingPropertiesIsNotValid_ReturnsInternalServerError(string bookingFrom, string bookingTo,
        string description, string hotelId, decimal price)
    {
        // Arrange
        var client = _factory.CreateClient();
        var bookingAddRequest =
            BookingTestData.InvalidBookingToAdd(bookingFrom, bookingTo, description, price, hotelId);
        var stringContent = BookingTestData.NewStringContent(bookingAddRequest);

        // Act
        var response = await client.PostAsync("api/Booking/add", stringContent);
        var returnedBooking = BookingTestData.GetByIdBooking(response).Result;

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        returnedBooking.Should().NotBeEquivalentTo(bookingAddRequest);
    }

    [Theory]
    [InlineData("0c3db3ee-6f77-4b64-a5ec-27298749f421", "2020-01-01", "2025-01-01", "valid",
        "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1)]
    [InlineData("0c3db3ee-6f77-4b64-a5ec-27298749f421", "2025-01-01", "2020-01-01", "valid",
        "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1)]
    [InlineData("0c3db3ee-6f77-4b64-a5ec-27298749f421", "2023-05-01", "2023-12-12", "",
        "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1)]
    [InlineData("0c3db3ee-6f77-4b64-a5ec-27298749f421", "2023-05-01", "2023-12-12", null,
        "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", 1)]
    [InlineData("0c3db3ee-6f77-4b64-a5ec-27298749f421", "2023-05-01", "2023-12-12", "valid",
        "00000000-0000-0000-0000-000000000000", 1)]
    [InlineData("0c3db3ee-6f77-4b64-a5ec-27298749f421", "2023-05-01", "2023-12-12", "valid",
        "d990989f-bd61-450d-a6e9-b8eed2fd5ba2", -1)]
    public async Task Update_BookingPropertiesIsNotValid_ReturnsInternalServerError(string id, string bookingFrom,
        string bookingTo,
        string description, string hotelId, decimal price)
    {
        // Arrange
        var client = _factory.CreateClient();
        var bookingUpdateRequest =
            BookingTestData.InvalidBookingToUpdate(id, bookingFrom, bookingTo, description, price, hotelId);
        var stringContent = BookingTestData.NewStringContent(bookingUpdateRequest);

        // Act
        var response = await client.PutAsync("api/Booking/update", stringContent);
        var returnedBooking = BookingTestData.GetByIdBooking(response).Result;

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        returnedBooking.Should().NotBeEquivalentTo(bookingUpdateRequest);
    }

    [Fact]
    public async Task Update_BookingPropertiesIsValid_ReturnsValidBooking()
    {
        // Arrange
        var client = _factory.CreateClient();
        var bookingUpdateRequest = BookingTestData.ValidBookingToUpdate;
        var stringContent = BookingTestData.NewStringContent(bookingUpdateRequest);

        // Act
        var response = await client.PutAsync("api/Booking/update", stringContent);
        var returnedBooking = BookingTestData.GetByIdBooking(response).Result;
        returnedBooking.Id = bookingUpdateRequest.Id;

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        returnedBooking.Should().BeEquivalentTo(bookingUpdateRequest);
    }

    [Fact]
    public async Task Delete_BookingIsExist_ReturnsSuccess()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.DeleteAsync("api/Booking/delete/0c3db3ee-6f77-4b64-a5ec-27298749f421");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Delete_BookingIsNotExist_ReturnsInternalServerError()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.DeleteAsync("api/Booking/delete/0c3db3ee-3277-4b64-a5ec-27298749f421");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
    }
}
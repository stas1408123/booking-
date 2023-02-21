using System.Net;
using Booking.API;
using Booking.IntegrationTests.AutoData;
using FluentAssertions;

namespace Booking.IntegrationTests.Controllers;

public class HotelControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public HotelControllerTest(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetAll_HotelListIsExist_ReturnsValidList()
    {
        // Arrange
        var client = _factory.CreateClient();
        var expectedList = HotelTestData.ExpectedHotelList();
        HotelTestData.ReinitializeDbForTests(_factory);

        // Act
        var response = await client.GetAsync("api/Hotel");
        var returnedList = HotelTestData.GetHotelList(response).Result;

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        returnedList.Should().BeEquivalentTo(expectedList);
    }

    [Fact]
    public async Task GetById_HotelIsExist_ReturnsValidHotel()
    {
        // Arrange
        var client = _factory.CreateClient();
        var expectedHotel = HotelTestData.ExpectedHotel;

        // Act
        var response = await client.GetAsync("api/Hotel/d990989f-bd61-450d-a6e9-b8eed2fd5ba2");
        var returnedHotel = HotelTestData.GetByIdHotel(response).Result;

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        returnedHotel.Should().BeEquivalentTo(expectedHotel);
    }

    [Fact]
    public async Task GetById_HotelIsNotExist_ReturnsInternalServerError()
    {
        // Arrange
        var client = _factory.CreateClient();
        var expectedHotel = HotelTestData.ExpectedHotel;

        // Act
        var response = await client.GetAsync("api/Hotel/7a38b367-68d0-4506-a6ad-6d717bb88913");
        var returnedHotel = HotelTestData.GetByIdHotel(response).Result;

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        returnedHotel.Should().NotBeEquivalentTo(expectedHotel);
    }

    [Theory]
    [InlineData("", "Valid", "Valid", 15, "Valid", 5, "+375336869225")]
    [InlineData("Valid", "", "Valid", 15, "Valid", 5, "+375336869225")]
    [InlineData("Valid", "Valid", "", 15, "Valid", 5, "+375336869225")]
    [InlineData("Valid", "Valid", "Valid", -1, "Valid", 5, "+375336869225")]
    [InlineData("Valid", "Valid", "Valid", 1111, "Valid", 5, "+375336869225")]
    [InlineData("Valid", "Valid", "Valid", 15, "", 5, "+375336869225")]
    [InlineData("Valid", "Valid", "Valid", 15, "Valid", -1, "+375336869225")]
    [InlineData("Valid", "Valid", "Valid", 15, "Valid", 6, "+375336869225")]
    [InlineData("Valid", "Valid", "Valid", 15, "Valid", 5, "375336869225")]
    [InlineData("Valid", "Valid", "Valid", 15, "Valid", 5, "+37533686922521312312323232")]
    [InlineData("Valid", "Valid", "Valid", 15, "Valid", 5, "+375")]
    public async Task Add_HotelPropertiesIsNotValid_ReturnsInternalServerError(string title, string description,
        string address, int countRooms, string owner, int stars, string phoneNumber)
    {
        // Arrange
        var client = _factory.CreateClient();
        var hotelAddRequest =
            HotelTestData.InvalidHotelToAdd(title, description, address, countRooms, owner, stars, phoneNumber);
        var stringContent = HotelTestData.NewStringContent(hotelAddRequest);

        // Act
        var response = await client.PostAsync("api/Hotel/add", stringContent);
        var returnedHotel = HotelTestData.GetByIdHotel(response).Result;

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        returnedHotel.Should().NotBeEquivalentTo(hotelAddRequest);
    }

    [Fact]
    public async Task Add_HotelPropertiesIsValid_ReturnsValidHotel()
    {
        // Arrange
        var client = _factory.CreateClient();
        var hotelAddRequest = HotelTestData.ValidHotelToAdd;
        var stringContent = HotelTestData.NewStringContent(hotelAddRequest);

        // Act
        var response = await client.PostAsync("api/Hotel/add", stringContent);
        var returnedHotel = HotelTestData.GetByIdHotel(response).Result;

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        returnedHotel.Should().BeEquivalentTo(hotelAddRequest);
    }

    [Theory]
    [InlineData("", "Valid", "Valid", 15, "Valid", 5, "+375336869225")]
    [InlineData("Valid", "", "Valid", 15, "Valid", 5, "+375336869225")]
    [InlineData("Valid", "Valid", "", 15, "Valid", 5, "+375336869225")]
    [InlineData("Valid", "Valid", "Valid", -1, "Valid", 5, "+375336869225")]
    [InlineData("Valid", "Valid", "Valid", 1111, "Valid", 5, "+375336869225")]
    [InlineData("Valid", "Valid", "Valid", 15, "", 5, "+375336869225")]
    [InlineData("Valid", "Valid", "Valid", 15, "Valid", -1, "+375336869225")]
    [InlineData("Valid", "Valid", "Valid", 15, "Valid", 6, "+375336869225")]
    [InlineData("Valid", "Valid", "Valid", 15, "Valid", 5, "375336869225")]
    [InlineData("Valid", "Valid", "Valid", 15, "Valid", 5, "+37533686922521312312323232")]
    [InlineData("Valid", "Valid", "Valid", 15, "Valid", 5, "+375")]
    public async Task Update_HotelPropertiesIsNotValid_ReturnsInternalServerError(string title, string description,
        string address, int countRooms, string owner, int stars, string phoneNumber)
    {
        // Arrange
        var client = _factory.CreateClient();
        var hotelUpdateRequest =
            HotelTestData.InvalidHotelToUpdate(title, description, address, countRooms, owner, stars, phoneNumber);
        var stringContent = HotelTestData.NewStringContent(hotelUpdateRequest);

        // Act
        var response = await client.PostAsync("api/Hotel/add", stringContent);
        var returnedHotel = HotelTestData.GetByIdHotel(response).Result;

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        returnedHotel.Should().NotBeEquivalentTo(hotelUpdateRequest);
    }

    [Fact]
    public async Task Update_HotelPropertiesIsValid_ReturnsValidHotel()
    {
        // Arrange
        var client = _factory.CreateClient();
        var hotelUpdateRequest = HotelTestData.ValidHotelToUpdate;
        var stringContent = HotelTestData.NewStringContent(hotelUpdateRequest);

        // Act
        var response = await client.PostAsync("api/Hotel/add", stringContent);
        var returnedHotel = HotelTestData.GetByIdHotelModel(response).Result;
        returnedHotel.Id = hotelUpdateRequest.Id;

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        returnedHotel.Should().BeEquivalentTo(hotelUpdateRequest);
    }

    [Fact]
    public async Task Delete_HotelIsExist_ReturnsSuccess()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.DeleteAsync("api/Hotel/delete/d990989f-bd61-450d-a6e9-b8eed2fd5ba2");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Delete_HotelIsNotExist_ReturnsInternalServerError()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.DeleteAsync("api/Hotel/delete/0c3db3ee-3277-4b64-a5ec-27298749f421");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
    }
}
namespace Booking.BLL.Tests.AutoData.Entities;

public static class BookingEntityData
{
    internal static BookingEntity GetBookingEntity = new()
    {
        Id = Guid.Parse("6bb0d987-4364-41c7-a873-6ffc01d7d3c1"),
        BookingFrom = DateTime.Parse("2020-01-01"),
        BookingTo = DateTime.Parse("2025-01-01"),
        Price = 1,
        HotelId = Guid.Parse("c839050c-e854-414a-93ea-f558e993e75e"),
        Description = "Uncorrect dates where BookingFrom have past date"
    };

    public static List<BookingEntity> CreateBookingsList()
    {
        var bookingList = new List<BookingEntity>
        {
            new()
            {
                Id = Guid.Parse("6bb0d987-4364-41c7-a873-6ffc01d7d3c1"),
                BookingFrom = DateTime.Parse("2020-01-01"),
                BookingTo = DateTime.Parse("2025-01-01"),
                Price = 1,
                HotelId = Guid.Parse("c839050c-e854-414a-93ea-f558e993e75e"),
                Description = "Uncorrect dates where BookingFrom have past date"
            },
            new()
            {
                Id = Guid.Parse("40e5efb2-d096-411e-a5e1-5053b3a826e7"),
                BookingFrom = DateTime.Parse("2025-01-01"),
                BookingTo = DateTime.Parse("2026-01-01"),
                Price = 10,
                HotelId = Guid.Parse("c839050c-e854-414a-93ea-f558e993e75e"),
                Description = "Correct dates"
            },
            new()
            {
                Id = Guid.Parse("2ba0b826-57d2-42ed-8689-7ac2362b3037"),
                BookingFrom = DateTime.Parse("2024-01-01"),
                BookingTo = DateTime.Parse("2022-01-01"),
                Price = 13,
                HotelId = Guid.Parse("c839050c-e854-414a-93ea-f558e993e75e"),
                Description = "Uncorrect dates where BookingTo have past date"
            },
            new()
            {
                Id = Guid.Parse("ff29160d-68f8-4542-978b-59046bf1be65"),
                BookingFrom = DateTime.Parse("2024-01-01"),
                BookingTo = DateTime.Parse("2025-01-01"),
                Price = 0,
                HotelId = Guid.Parse("c839050c-e854-414a-93ea-f558e993e75e"),
                Description = "Uncorrect price"
            },
            new()
            {
                Id = Guid.Parse("f6face9c-42d4-4b3f-a95e-78504197ca62"),
                BookingFrom = DateTime.Parse("2024-01-01"),
                BookingTo = DateTime.Parse("2025-01-01"),
                Price = 13,
                HotelId = Guid.Parse("c839050c-e854-414a-93ea-f558e993e75e"),
                Description = ""
            },
            new()
            {
                Id = Guid.Parse("4f6f84cb-ed8f-45f6-ae40-7c2e7f525f3d"),
                BookingFrom = DateTime.Parse("2023-05-06"),
                BookingTo = DateTime.Parse("2025-01-01"),
                Price = 13,
                HotelId = Guid.Parse("c839050c-e854-414a-93ea-f558e993e75e"),
                Description = "All correct data"
            },
            new()
            {
                Id = Guid.Parse("6bb0d987-4364-41c7-a873-6ffc01d7d3c1"),
                BookingFrom = DateTime.Parse("2020-01-01"),
                BookingTo = DateTime.Parse("2025-01-01"),
                Price = 1,
                HotelId = Guid.Parse("c839050c-e854-414a-93ea-f558e993e75e"),
                Description = "Uncorrect dates where BookingFrom have past date"
            },
            new()
            {
                Id = Guid.Parse("de3ce49e-5286-4e2f-a9ff-d31ace33dec1"),
                BookingFrom = DateTime.Parse("2023-10-01"),
                BookingTo = DateTime.Parse("2027-01-01"),
                Price = 1,
                HotelId = Guid.Parse("c839050c-e854-414a-93ea-f558e993e75e"),
                Description = "Correct dates"
            },
            new()
            {
                Id = Guid.Parse("a944c33d-17eb-4bd0-a47f-05eb4c238b0d"),
                BookingFrom = DateTime.Parse("2023-07-01"),
                BookingTo = DateTime.Parse("2025-01-01"),
                Price = 1,
                HotelId = Guid.Parse("c839050c-e854-414a-93ea-f558e993e75e"),
                Description = "Correct dates"
            },
            new()
            {
                Id = Guid.Parse("a4a06f4b-9992-4eb3-a132-f119eb6b6555"),
                BookingFrom = DateTime.Parse("2023-04-01"),
                BookingTo = DateTime.Parse("2024-01-01"),
                Price = 1,
                HotelId = Guid.Parse("c839050c-e854-414a-93ea-f558e993e75e"),
                Description = "Correct dates"
            },
            new()
            {
                Id = Guid.Parse("b4924786-af90-4026-a5cc-37d91532f8fe"),
                BookingFrom = DateTime.Parse("2023-03-01"),
                BookingTo = DateTime.Parse("2025-01-01"),
                Price = 1,
                HotelId = Guid.Parse("c839050c-e854-414a-93ea-f558e993e75e"),
                Description = "Correct dates"
            }
        };

        return bookingList;
    }

    public static List<BookingEntity> SortedList(Guid hotelId, DateTime bookingFrom, DateTime bookingTo)
    {
        return CreateBookingsList()
            .Where(r => r.HotelId == hotelId)
            .Where(r => r.BookingFrom >= bookingFrom)
            .Where(r => r.BookingTo <= bookingTo)
            .ToList();
    }
}
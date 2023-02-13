using Booking.BLL.Models;

namespace Booking.BLL.Tests.AutoData;

public static class BookingData
{
    public static List<BookingModel> CreateBookingsList()
    {
        var bookingList = new List<BookingModel>
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
                HotelId = Guid.Parse("0eecbe4c-caab-4854-89ff-0d4ed4478307"),
                Description = "Correct dates"
            },
            new()
            {
                Id = Guid.Parse("2ba0b826-57d2-42ed-8689-7ac2362b3037"),
                BookingFrom = DateTime.Parse("2024-01-01"),
                BookingTo = DateTime.Parse("2022-01-01"),
                Price = 13,
                HotelId = Guid.Parse("77e429f8-5be4-468d-983a-d2d14ad7a018"),
                Description = "Uncorrect dates where BookingTo have past date"
            },
            new()
            {
                Id = Guid.Parse("ff29160d-68f8-4542-978b-59046bf1be65"),
                BookingFrom = DateTime.Parse("2024-01-01"),
                BookingTo = DateTime.Parse("2025-01-01"),
                Price = 0,
                HotelId = Guid.Parse("38b1a441-8799-49fb-bbea-28646e67bc19"),
                Description = "Uncorrect price"
            },
            new()
            {
                Id = Guid.Parse("f6face9c-42d4-4b3f-a95e-78504197ca62"),
                BookingFrom = DateTime.Parse("2024-01-01"),
                BookingTo = DateTime.Parse("2025-01-01"),
                Price = 13,
                HotelId = Guid.Parse("e44c05c4-b09f-4c16-add6-71a5aef10063"),
                Description = ""
            },
            new()
            {
                Id = Guid.Parse("4f6f84cb-ed8f-45f6-ae40-7c2e7f525f3d"),
                BookingFrom = DateTime.Parse("2023-05-06"),
                BookingTo = DateTime.Parse("2025-01-01"),
                Price = 13,
                HotelId = Guid.Parse("0eecbe4c-caab-4854-89ff-0d4ed4478307"),
                Description = "All correct data"
            }
        };

        return bookingList;
    }
}
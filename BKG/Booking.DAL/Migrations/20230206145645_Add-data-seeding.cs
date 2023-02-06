using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Booking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Adddataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountRooms", "CreatedTime", "Description", "Owner", "PhoneNumber", "Stars", "Title" },
                values: new object[,]
                {
                    { new Guid("60e6d76a-9c13-488b-afce-a3b21dbc3177"), "Idk", 233, new DateTime(2023, 2, 6, 14, 56, 45, 541, DateTimeKind.Utc).AddTicks(1346), "Idk", "Pashok Gagarin", "+123456802232", 3, "Pashok Hotel" },
                    { new Guid("d990989f-bd61-450d-a6e9-b8eed2fd5ba2"), "Nvm", 125, new DateTime(2023, 2, 6, 14, 56, 45, 541, DateTimeKind.Utc).AddTicks(1342), "Nvm", "Dima Hatetovski", "+375336869225", 5, "GYM HOTEL" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingFrom", "BookingTo", "Description", "HotelId", "Price" },
                values: new object[,]
                {
                    { new Guid("0c3db3ee-6f77-4b64-a5ec-27298749f421"), new DateTime(2023, 2, 6, 14, 56, 45, 540, DateTimeKind.Utc).AddTicks(7897), new DateTime(2023, 2, 6, 14, 56, 45, 540, DateTimeKind.Utc).AddTicks(7898), "Nvm", new Guid("d990989f-bd61-450d-a6e9-b8eed2fd5ba2"), 0m },
                    { new Guid("819f9de9-10d3-4459-a950-1561a34f0b9d"), new DateTime(2023, 2, 6, 14, 56, 45, 540, DateTimeKind.Utc).AddTicks(7903), new DateTime(2023, 2, 6, 14, 56, 45, 540, DateTimeKind.Utc).AddTicks(7903), "Nvm2", new Guid("d990989f-bd61-450d-a6e9-b8eed2fd5ba2"), 0m },
                    { new Guid("aae87a10-736e-47c0-9dba-b8550f902d0c"), new DateTime(2023, 2, 6, 14, 56, 45, 540, DateTimeKind.Utc).AddTicks(7905), new DateTime(2023, 2, 6, 14, 56, 45, 540, DateTimeKind.Utc).AddTicks(7906), "Idk", new Guid("60e6d76a-9c13-488b-afce-a3b21dbc3177"), 0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("0c3db3ee-6f77-4b64-a5ec-27298749f421"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("819f9de9-10d3-4459-a950-1561a34f0b9d"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("aae87a10-736e-47c0-9dba-b8550f902d0c"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("60e6d76a-9c13-488b-afce-a3b21dbc3177"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("d990989f-bd61-450d-a6e9-b8eed2fd5ba2"));
        }
    }
}

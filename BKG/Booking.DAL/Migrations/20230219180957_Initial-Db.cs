using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Booking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    CountRooms = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    BookingFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountRooms", "CreatedTime", "Description", "Owner", "PhoneNumber", "Stars", "Title" },
                values: new object[,]
                {
                    { new Guid("60e6d76a-9c13-488b-afce-a3b21dbc3177"), "Idk", 233, new DateTime(2023, 2, 19, 18, 9, 57, 707, DateTimeKind.Utc).AddTicks(7238), "Idk", "Pashok Gagarin", "+123456802232", 3, "Pashok Hotel" },
                    { new Guid("d990989f-bd61-450d-a6e9-b8eed2fd5ba2"), "Nvm", 125, new DateTime(2023, 2, 19, 18, 9, 57, 707, DateTimeKind.Utc).AddTicks(7234), "Nvm", "Dima Hatetovski", "+375336869225", 5, "GYM HOTEL" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingFrom", "BookingTo", "Description", "HotelId", "Price" },
                values: new object[,]
                {
                    { new Guid("0c3db3ee-6f77-4b64-a5ec-27298749f421"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nvm", new Guid("d990989f-bd61-450d-a6e9-b8eed2fd5ba2"), 1m },
                    { new Guid("819f9de9-10d3-4459-a950-1561a34f0b9d"), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nvm2", new Guid("d990989f-bd61-450d-a6e9-b8eed2fd5ba2"), 2m },
                    { new Guid("aae87a10-736e-47c0-9dba-b8550f902d0c"), new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Idk", new Guid("60e6d76a-9c13-488b-afce-a3b21dbc3177"), 3m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HotelId",
                table: "Bookings",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_Address",
                table: "Hotels",
                column: "Address",
                unique: true,
                filter: "[Address] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_PhoneNumber",
                table: "Hotels",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_Title",
                table: "Hotels",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Updatedataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Hotels_Address",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_PhoneNumber",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_Title",
                table: "Hotels");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Hotels",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Hotels",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Owner",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Hotels",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("0c3db3ee-6f77-4b64-a5ec-27298749f421"),
                columns: new[] { "BookingFrom", "BookingTo", "Price" },
                values: new object[] { new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("819f9de9-10d3-4459-a950-1561a34f0b9d"),
                columns: new[] { "BookingFrom", "BookingTo", "Price" },
                values: new object[] { new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("aae87a10-736e-47c0-9dba-b8550f902d0c"),
                columns: new[] { "BookingFrom", "BookingTo", "Price" },
                values: new object[] { new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("60e6d76a-9c13-488b-afce-a3b21dbc3177"),
                column: "CreatedTime",
                value: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("d990989f-bd61-450d-a6e9-b8eed2fd5ba2"),
                column: "CreatedTime",
                value: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
            migrationBuilder.DropIndex(
                name: "IX_Hotels_Address",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_PhoneNumber",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_Title",
                table: "Hotels");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Hotels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Hotels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Owner",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Hotels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("0c3db3ee-6f77-4b64-a5ec-27298749f421"),
                columns: new[] { "BookingFrom", "BookingTo", "Price" },
                values: new object[] { new DateTime(2023, 2, 6, 14, 56, 45, 540, DateTimeKind.Utc).AddTicks(7897), new DateTime(2023, 2, 6, 14, 56, 45, 540, DateTimeKind.Utc).AddTicks(7898), 0m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("819f9de9-10d3-4459-a950-1561a34f0b9d"),
                columns: new[] { "BookingFrom", "BookingTo", "Price" },
                values: new object[] { new DateTime(2023, 2, 6, 14, 56, 45, 540, DateTimeKind.Utc).AddTicks(7903), new DateTime(2023, 2, 6, 14, 56, 45, 540, DateTimeKind.Utc).AddTicks(7903), 0m });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("aae87a10-736e-47c0-9dba-b8550f902d0c"),
                columns: new[] { "BookingFrom", "BookingTo", "Price" },
                values: new object[] { new DateTime(2023, 2, 6, 14, 56, 45, 540, DateTimeKind.Utc).AddTicks(7905), new DateTime(2023, 2, 6, 14, 56, 45, 540, DateTimeKind.Utc).AddTicks(7906), 0m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("60e6d76a-9c13-488b-afce-a3b21dbc3177"),
                column: "CreatedTime",
                value: new DateTime(2023, 2, 6, 14, 56, 45, 541, DateTimeKind.Utc).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("d990989f-bd61-450d-a6e9-b8eed2fd5ba2"),
                column: "CreatedTime",
                value: new DateTime(2023, 2, 6, 14, 56, 45, 541, DateTimeKind.Utc).AddTicks(1342));

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_Address",
                table: "Hotels",
                column: "Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_PhoneNumber",
                table: "Hotels",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_Title",
                table: "Hotels",
                column: "Title",
                unique: true);
        }
    }
}

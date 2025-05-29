using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gotorz.Migrations
{
    /// <inheritdoc />
    public partial class AddFlightAndHotelTimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReturnTime",
                table: "Bookings",
                newName: "TakeoffTimeReturnFlight");

            migrationBuilder.RenameColumn(
                name: "DepartureTime",
                table: "Bookings",
                newName: "TakeoffTimeDepartureFlight");

            migrationBuilder.AddColumn<DateTime>(
                name: "HotelCheckIn",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HotelCheckOut",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HotelName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LandingTimeDepartureFlight",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LandingTimeReturnFlight",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelCheckIn",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "HotelCheckOut",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "HotelName",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "LandingTimeDepartureFlight",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "LandingTimeReturnFlight",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "TakeoffTimeReturnFlight",
                table: "Bookings",
                newName: "ReturnTime");

            migrationBuilder.RenameColumn(
                name: "TakeoffTimeDepartureFlight",
                table: "Bookings",
                newName: "DepartureTime");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gotorz.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingDetailsToTravelPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TravelPackages");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TravelPackages",
                newName: "ReturnFlightId");

            migrationBuilder.RenameColumn(
                name: "HotelName",
                table: "TravelPackages",
                newName: "DepartureFlightId");

            migrationBuilder.AddColumn<int>(
                name: "Adults",
                table: "TravelPackages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "TravelPackages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "TravelPackages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "DeparturePriceAtBooking",
                table: "TravelPackages",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "HotelPriceAtBooking",
                table: "TravelPackages",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "TravelPackages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "ReturnPriceAtBooking",
                table: "TravelPackages",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adults",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "DeparturePriceAtBooking",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "HotelPriceAtBooking",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "ReturnPriceAtBooking",
                table: "TravelPackages");

            migrationBuilder.RenameColumn(
                name: "ReturnFlightId",
                table: "TravelPackages",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "DepartureFlightId",
                table: "TravelPackages",
                newName: "HotelName");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TravelPackages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

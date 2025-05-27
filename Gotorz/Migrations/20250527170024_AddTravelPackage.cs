using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gotorz.Migrations
{
    /// <inheritdoc />
    public partial class AddTravelPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReturnPriceAtBooking",
                table: "TravelPackages",
                newName: "ReturnPriceAtCreation");

            migrationBuilder.RenameColumn(
                name: "HotelPriceAtBooking",
                table: "TravelPackages",
                newName: "HotelPriceAtCreation");

            migrationBuilder.RenameColumn(
                name: "DeparturePriceAtBooking",
                table: "TravelPackages",
                newName: "DeparturePriceAtCreation");

            migrationBuilder.RenameColumn(
                name: "BookingDate",
                table: "TravelPackages",
                newName: "CreationDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReturnPriceAtCreation",
                table: "TravelPackages",
                newName: "ReturnPriceAtBooking");

            migrationBuilder.RenameColumn(
                name: "HotelPriceAtCreation",
                table: "TravelPackages",
                newName: "HotelPriceAtBooking");

            migrationBuilder.RenameColumn(
                name: "DeparturePriceAtCreation",
                table: "TravelPackages",
                newName: "DeparturePriceAtBooking");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "TravelPackages",
                newName: "BookingDate");
        }
    }
}

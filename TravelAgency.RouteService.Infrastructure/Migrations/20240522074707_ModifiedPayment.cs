using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.RouteService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "TravelAgencyId",
                table: "Payment",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Payment",
                newName: "TravelAgencyId");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionDate",
                table: "Payment",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

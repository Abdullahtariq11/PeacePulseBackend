using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeacePulse_Backend.Migrations
{
    /// <inheritdoc />
    public partial class update30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "completedPercentage",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "failedPercentage",
                table: "Dashboards");

            migrationBuilder.AddColumn<int>(
                name: "UnfilledPrayer",
                table: "Dashboards",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnfilledPrayer",
                table: "Dashboards");

            migrationBuilder.AddColumn<decimal>(
                name: "completedPercentage",
                table: "Dashboards",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "failedPercentage",
                table: "Dashboards",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeacePulse_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Intial13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrayerID",
                table: "Dashboards",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrayerID",
                table: "Dashboards");
        }
    }
}

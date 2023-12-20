using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class InfoPlantState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Plant",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Info",
                table: "Plant");
        }
    }
}

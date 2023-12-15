using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class SettingsPlantCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxTemperature = table.Column<int>(type: "int", nullable: false),
                    MinTemperature = table.Column<int>(type: "int", nullable: false),
                    MaxLight = table.Column<int>(type: "int", nullable: false),
                    MinLight = table.Column<int>(type: "int", nullable: false),
                    MaxPressure = table.Column<int>(type: "int", nullable: false),
                    MinPressure = table.Column<int>(type: "int", nullable: false),
                    MaxHumidity = table.Column<int>(type: "int", nullable: false),
                    MinHumidity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}

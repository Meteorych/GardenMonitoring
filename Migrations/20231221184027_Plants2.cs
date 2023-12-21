using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class Plants2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "MaxHumidity", "MaxLight", "MaxPressure", "MaxTemperature", "MinHumidity", "MinLight", "MinPressure", "MinTemperature" },
                values: new object[] { 1, 85, 3500, 900, 30, 65, 2500, 730, 20 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

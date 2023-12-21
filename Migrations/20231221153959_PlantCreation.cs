using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class PlantCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlantClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SensorType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SensorState = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Plant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plant_PlantClass_ClassId",
                        column: x => x.ClassId,
                        principalTable: "PlantClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantState",
                columns: table => new
                {
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperature = table.Column<int>(type: "int", nullable: false),
                    Light = table.Column<int>(type: "int", nullable: false),
                    Pressure = table.Column<int>(type: "int", nullable: false),
                    Humidity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantState", x => x.PlantId);
                    table.ForeignKey(
                        name: "FK_PlantState_Plant_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plant_ClassId",
                table: "Plant",
                column: "ClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantState");

            migrationBuilder.DropTable(
                name: "Sensor");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Plant");

            migrationBuilder.DropTable(
                name: "PlantClass");
        }
    }
}

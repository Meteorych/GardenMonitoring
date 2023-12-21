using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class PlantModelCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Plant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantState_PlantId",
                table: "PlantState",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_ClassId",
                table: "Plant",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_PlantClass_ClassId",
                table: "Plant",
                column: "ClassId",
                principalTable: "PlantClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantState_Plant_PlantId",
                table: "PlantState",
                column: "PlantId",
                principalTable: "Plant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plant_PlantClass_ClassId",
                table: "Plant");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantState_Plant_PlantId",
                table: "PlantState");

            migrationBuilder.DropIndex(
                name: "IX_PlantState_PlantId",
                table: "PlantState");

            migrationBuilder.DropIndex(
                name: "IX_Plant_ClassId",
                table: "Plant");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "Plant");
        }
    }
}

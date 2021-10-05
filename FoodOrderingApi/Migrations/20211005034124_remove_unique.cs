using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodOrderingApi.Migrations
{
    public partial class remove_unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Selections_CartId",
                table: "Selections");

            migrationBuilder.DropIndex(
                name: "IX_Selections_MenuItemId",
                table: "Selections");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_CartId",
                table: "Selections",
                column: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Selections_CartId",
                table: "Selections");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_CartId",
                table: "Selections",
                column: "CartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Selections_MenuItemId",
                table: "Selections",
                column: "MenuItemId",
                unique: true);
        }
    }
}

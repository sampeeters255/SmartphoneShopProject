using Microsoft.EntityFrameworkCore.Migrations;

namespace Peeters_Sam_r049890.Migrations
{
    public partial class loggedinuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCars_AspNetUsers_CustomUserId",
                table: "ShoppingCars");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCars_Smartphone_SmartphoneId",
                table: "ShoppingCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCars",
                table: "ShoppingCars");

            migrationBuilder.RenameTable(
                name: "ShoppingCars",
                newName: "ShoppingCart");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCars_SmartphoneId",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_SmartphoneId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCars_CustomUserId",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_CustomUserId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_CustomUserId",
                table: "ShoppingCart",
                column: "CustomUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Smartphone_SmartphoneId",
                table: "ShoppingCart",
                column: "SmartphoneId",
                principalTable: "Smartphone",
                principalColumn: "SmartphoneId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_CustomUserId",
                table: "ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Smartphone_SmartphoneId",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "ShoppingCart",
                newName: "ShoppingCars");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_SmartphoneId",
                table: "ShoppingCars",
                newName: "IX_ShoppingCars_SmartphoneId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_CustomUserId",
                table: "ShoppingCars",
                newName: "IX_ShoppingCars_CustomUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCars",
                table: "ShoppingCars",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCars_AspNetUsers_CustomUserId",
                table: "ShoppingCars",
                column: "CustomUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCars_Smartphone_SmartphoneId",
                table: "ShoppingCars",
                column: "SmartphoneId",
                principalTable: "Smartphone",
                principalColumn: "SmartphoneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

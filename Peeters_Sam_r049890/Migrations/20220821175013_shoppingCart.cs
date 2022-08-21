using Microsoft.EntityFrameworkCore.Migrations;

namespace Peeters_Sam_r049890.Migrations
{
    public partial class shoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCars",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmartphoneId = table.Column<int>(nullable: false),
                    Hoeveelheid = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    CustomUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCars", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_ShoppingCars_AspNetUsers_CustomUserId",
                        column: x => x.CustomUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCars_Smartphone_SmartphoneId",
                        column: x => x.SmartphoneId,
                        principalTable: "Smartphone",
                        principalColumn: "SmartphoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCars_CustomUserId",
                table: "ShoppingCars",
                column: "CustomUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCars_SmartphoneId",
                table: "ShoppingCars",
                column: "SmartphoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCars");
        }
    }
}

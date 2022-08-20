using Microsoft.EntityFrameworkCore.Migrations;

namespace Peeters_Sam_r049890.Migrations
{
    public partial class RemoveFkMerkSmartphone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Smartphone_Merken_MerkId",
                table: "Smartphone");

            migrationBuilder.DropIndex(
                name: "IX_Smartphone_MerkId",
                table: "Smartphone");

            migrationBuilder.DropColumn(
                name: "MerkId",
                table: "Smartphone");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Smartphone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Merk",
                table: "Smartphone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Merk",
                table: "Smartphone");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Smartphone",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "MerkId",
                table: "Smartphone",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Smartphone_MerkId",
                table: "Smartphone",
                column: "MerkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Smartphone_Merken_MerkId",
                table: "Smartphone",
                column: "MerkId",
                principalTable: "Merken",
                principalColumn: "MerkId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

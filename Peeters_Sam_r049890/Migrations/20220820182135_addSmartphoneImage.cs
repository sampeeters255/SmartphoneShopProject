using Microsoft.EntityFrameworkCore.Migrations;

namespace Peeters_Sam_r049890.Migrations
{
    public partial class addSmartphoneImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Smartphone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Smartphone");
        }
    }
}

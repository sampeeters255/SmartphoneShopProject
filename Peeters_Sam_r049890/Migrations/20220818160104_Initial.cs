using Microsoft.EntityFrameworkCore.Migrations;

namespace Peeters_Sam_r049890.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klanten",
                columns: table => new
                {
                    KlantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    Voornaam = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klanten", x => x.KlantId);
                });

            migrationBuilder.CreateTable(
                name: "Merken",
                columns: table => new
                {
                    MerkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Merknaam = table.Column<string>(nullable: true),
                    Herkomst = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merken", x => x.MerkId);
                });

            migrationBuilder.CreateTable(
                name: "Smartphone",
                columns: table => new
                {
                    SmartphoneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Model = table.Column<string>(nullable: true),
                    MerkId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smartphone", x => x.SmartphoneId);
                    table.ForeignKey(
                        name: "FK_Smartphone_Merken_MerkId",
                        column: x => x.MerkId,
                        principalTable: "Merken",
                        principalColumn: "MerkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Smartphone_MerkId",
                table: "Smartphone",
                column: "MerkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klanten");

            migrationBuilder.DropTable(
                name: "Smartphone");

            migrationBuilder.DropTable(
                name: "Merken");
        }
    }
}

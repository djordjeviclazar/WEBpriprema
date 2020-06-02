using Microsoft.EntityFrameworkCore.Migrations;

namespace Drugi.Migrations
{
    public partial class Proba2_KnjigaRecepata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recept",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    VremePripreme = table.Column<int>(nullable: false),
                    Tip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recept", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sastojak",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Kolicina = table.Column<int>(nullable: false),
                    Jedinica = table.Column<string>(nullable: true),
                    PoPotrebi = table.Column<bool>(nullable: false),
                    ReceptId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sastojak", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sastojak_Recept_ReceptId",
                        column: x => x.ReceptId,
                        principalTable: "Recept",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sastojak_ReceptId",
                table: "Sastojak",
                column: "ReceptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sastojak");

            migrationBuilder.DropTable(
                name: "Recept");
        }
    }
}

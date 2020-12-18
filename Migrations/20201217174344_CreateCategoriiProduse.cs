using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_WebApp.Migrations
{
    public partial class CreateCategoriiProduse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Produs",
                type: "decimal(6, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "VanzatorID",
                table: "Produs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vanzator",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vanzator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategoriiProduse",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdusID = table.Column<int>(nullable: false),
                    IDCategorie = table.Column<int>(nullable: false),
                    CategorieID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriiProduse", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategoriiProduse_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoriiProduse_Produs_ProdusID",
                        column: x => x.ProdusID,
                        principalTable: "Produs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produs_VanzatorID",
                table: "Produs",
                column: "VanzatorID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriiProduse_CategorieID",
                table: "CategoriiProduse",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriiProduse_ProdusID",
                table: "CategoriiProduse",
                column: "ProdusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produs_Vanzator_VanzatorID",
                table: "Produs",
                column: "VanzatorID",
                principalTable: "Vanzator",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produs_Vanzator_VanzatorID",
                table: "Produs");

            migrationBuilder.DropTable(
                name: "CategoriiProduse");

            migrationBuilder.DropTable(
                name: "Vanzator");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Produs_VanzatorID",
                table: "Produs");

            migrationBuilder.DropColumn(
                name: "VanzatorID",
                table: "Produs");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Produs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6, 2)");
        }
    }
}

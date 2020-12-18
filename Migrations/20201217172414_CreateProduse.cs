using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_WebApp.Migrations
{
    public partial class CreateProduse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(nullable: true),
                    Descriere = table.Column<string>(nullable: true),
                    Pret = table.Column<decimal>(nullable: false),
                    DataAdaugarii = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produs", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produs");
        }
    }
}

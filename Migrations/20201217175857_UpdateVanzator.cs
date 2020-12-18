using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_WebApp.Migrations
{
    public partial class UpdateVanzator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Vanzator",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prenume",
                table: "Vanzator",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telef",
                table: "Vanzator",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Vanzator");

            migrationBuilder.DropColumn(
                name: "Prenume",
                table: "Vanzator");

            migrationBuilder.DropColumn(
                name: "Telef",
                table: "Vanzator");
        }
    }
}

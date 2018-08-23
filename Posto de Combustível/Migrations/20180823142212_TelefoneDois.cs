using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto_de_Combustivel.Migrations
{
    public partial class TelefoneDois : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Pessoas",
                newName: "TelefoneUm");

            migrationBuilder.AddColumn<string>(
                name: "TelefoneDois",
                table: "Pessoas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelefoneDois",
                table: "Pessoas");

            migrationBuilder.RenameColumn(
                name: "TelefoneUm",
                table: "Pessoas",
                newName: "Telefone");
        }
    }
}

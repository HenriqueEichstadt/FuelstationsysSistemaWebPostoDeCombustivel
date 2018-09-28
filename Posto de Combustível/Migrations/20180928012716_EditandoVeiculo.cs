using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto_de_Combustivel.Migrations
{
    public partial class EditandoVeiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "Veiculos",
                newName: "TipoDeVeiculo");

            migrationBuilder.AddColumn<string>(
                name: "Fabricante",
                table: "Veiculos",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fabricante",
                table: "Veiculos");

            migrationBuilder.RenameColumn(
                name: "TipoDeVeiculo",
                table: "Veiculos",
                newName: "Marca");
        }
    }
}

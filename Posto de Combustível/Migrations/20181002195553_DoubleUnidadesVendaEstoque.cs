using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto_de_Combustivel.Migrations
{
    public partial class DoubleUnidadesVendaEstoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Unidades",
                table: "VendaEstoque",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Unidades",
                table: "VendaEstoque",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto_de_Combustivel.Migrations
{
    public partial class doubleEstoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "LimiteEstoque",
                table: "Estoques",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "EstoqueAtual",
                table: "Estoques",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LimiteEstoque",
                table: "Estoques",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstoqueAtual",
                table: "Estoques",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}

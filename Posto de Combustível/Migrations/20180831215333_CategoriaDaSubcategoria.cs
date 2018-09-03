using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto_de_Combustivel.Migrations
{
    public partial class CategoriaDaSubcategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaDaSubcategoriaId",
                table: "Estoques",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_CategoriaDaSubcategoriaId",
                table: "Estoques",
                column: "CategoriaDaSubcategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Categorias_CategoriaDaSubcategoriaId",
                table: "Estoques",
                column: "CategoriaDaSubcategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Categorias_CategoriaDaSubcategoriaId",
                table: "Estoques");

            migrationBuilder.DropIndex(
                name: "IX_Estoques_CategoriaDaSubcategoriaId",
                table: "Estoques");

            migrationBuilder.DropColumn(
                name: "CategoriaDaSubcategoriaId",
                table: "Estoques");
        }
    }
}

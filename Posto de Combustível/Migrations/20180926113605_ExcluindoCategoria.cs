using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto_de_Combustivel.Migrations
{
    public partial class ExcluindoCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Categorias_CategoriaId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Categorias_SubcategoriaId",
                table: "Estoques");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_CategoriaId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Categorias");

            migrationBuilder.RenameColumn(
                name: "SubcategoriaId",
                table: "Estoques",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Estoques_SubcategoriaId",
                table: "Estoques",
                newName: "IX_Estoques_CategoriaId");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Categorias",
                newName: "NomeCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Categorias_CategoriaId",
                table: "Estoques",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Categorias_CategoriaId",
                table: "Estoques");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Estoques",
                newName: "SubcategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Estoques_CategoriaId",
                table: "Estoques",
                newName: "IX_Estoques_SubcategoriaId");

            migrationBuilder.RenameColumn(
                name: "NomeCategoria",
                table: "Categorias",
                newName: "Nome");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Categorias",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_CategoriaId",
                table: "Categorias",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Categorias_CategoriaId",
                table: "Categorias",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Categorias_SubcategoriaId",
                table: "Estoques",
                column: "SubcategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto_de_Combustivel.Migrations
{
    public partial class CorrigindoCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Categorias_CategoriaDaSubcategoriaId",
                table: "Estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Categorias_CategoriaId",
                table: "Estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Categorias_SubcategoriaId",
                table: "Estoques");

            migrationBuilder.DropIndex(
                name: "IX_Estoques_CategoriaDaSubcategoriaId",
                table: "Estoques");

            migrationBuilder.DropIndex(
                name: "IX_Estoques_CategoriaId",
                table: "Estoques");

            migrationBuilder.DropColumn(
                name: "CategoriaDaSubcategoriaId",
                table: "Estoques");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Estoques");

            migrationBuilder.AlterColumn<int>(
                name: "SubcategoriaId",
                table: "Estoques",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Categorias_SubcategoriaId",
                table: "Estoques",
                column: "SubcategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Categorias_SubcategoriaId",
                table: "Estoques");

            migrationBuilder.AlterColumn<int>(
                name: "SubcategoriaId",
                table: "Estoques",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CategoriaDaSubcategoriaId",
                table: "Estoques",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Estoques",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_CategoriaDaSubcategoriaId",
                table: "Estoques",
                column: "CategoriaDaSubcategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_CategoriaId",
                table: "Estoques",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Categorias_CategoriaDaSubcategoriaId",
                table: "Estoques",
                column: "CategoriaDaSubcategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Categorias_CategoriaId",
                table: "Estoques",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Categorias_SubcategoriaId",
                table: "Estoques",
                column: "SubcategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto_de_Combustivel.Migrations
{
    public partial class CategoriaEstoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Categorias");

            migrationBuilder.AddColumn<int>(
                name: "SubcategoriaId",
                table: "Estoques",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Categorias",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Categorias",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_SubcategoriaId",
                table: "Estoques",
                column: "SubcategoriaId");

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Categorias_CategoriaId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Categorias_SubcategoriaId",
                table: "Estoques");

            migrationBuilder.DropIndex(
                name: "IX_Estoques_SubcategoriaId",
                table: "Estoques");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_CategoriaId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "SubcategoriaId",
                table: "Estoques");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Categorias");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Categorias",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Categorias",
                nullable: true);
        }
    }
}

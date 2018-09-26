using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto_de_Combustivel.Migrations
{
    public partial class Categoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Categorias_CategoriaId",
                table: "Estoques");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Estoques_CategoriaId",
                table: "Estoques");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Estoques");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Estoques",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Estoques");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Estoques",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeCategoria = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_CategoriaId",
                table: "Estoques",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Categorias_CategoriaId",
                table: "Estoques",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

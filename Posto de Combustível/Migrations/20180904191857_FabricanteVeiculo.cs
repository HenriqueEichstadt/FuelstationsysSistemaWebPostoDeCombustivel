using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto_de_Combustivel.Migrations
{
    public partial class FabricanteVeiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FabricanteVeiculos_FabricanteVeiculos_FabricanteVeiculoId",
                table: "FabricanteVeiculos");

            migrationBuilder.DropIndex(
                name: "IX_FabricanteVeiculos_FabricanteVeiculoId",
                table: "FabricanteVeiculos");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaDaSubCategoriaId",
                table: "Veiculos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubcategoriaId",
                table: "FabricanteVeiculos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_CategoriaDaSubCategoriaId",
                table: "Veiculos",
                column: "CategoriaDaSubCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_FabricanteVeiculos_SubcategoriaId",
                table: "FabricanteVeiculos",
                column: "SubcategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_FabricanteVeiculos_Categorias_SubcategoriaId",
                table: "FabricanteVeiculos",
                column: "SubcategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Veiculos_CategoriaDaSubCategoriaId",
                table: "Veiculos",
                column: "CategoriaDaSubCategoriaId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FabricanteVeiculos_Categorias_SubcategoriaId",
                table: "FabricanteVeiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Veiculos_CategoriaDaSubCategoriaId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_CategoriaDaSubCategoriaId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_FabricanteVeiculos_SubcategoriaId",
                table: "FabricanteVeiculos");

            migrationBuilder.DropColumn(
                name: "CategoriaDaSubCategoriaId",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "SubcategoriaId",
                table: "FabricanteVeiculos");

            migrationBuilder.CreateIndex(
                name: "IX_FabricanteVeiculos_FabricanteVeiculoId",
                table: "FabricanteVeiculos",
                column: "FabricanteVeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_FabricanteVeiculos_FabricanteVeiculos_FabricanteVeiculoId",
                table: "FabricanteVeiculos",
                column: "FabricanteVeiculoId",
                principalTable: "FabricanteVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

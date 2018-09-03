using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto_de_Combustivel.Migrations
{
    public partial class FabricanteVeiculos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FabricanteVeiculos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoEFabricante = table.Column<string>(maxLength: 50, nullable: true),
                    FabricanteVeiculoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricanteVeiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FabricanteVeiculos_FabricanteVeiculos_FabricanteVeiculoId",
                        column: x => x.FabricanteVeiculoId,
                        principalTable: "FabricanteVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FabricanteVeiculos_FabricanteVeiculoId",
                table: "FabricanteVeiculos",
                column: "FabricanteVeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FabricanteVeiculos");
        }
    }
}

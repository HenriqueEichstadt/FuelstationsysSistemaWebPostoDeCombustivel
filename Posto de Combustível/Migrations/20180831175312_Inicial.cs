using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto_de_Combustivel.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rua = table.Column<string>(maxLength: 100, nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(maxLength: 50, nullable: true),
                    Complemento = table.Column<string>(maxLength: 50, nullable: true),
                    Estado = table.Column<string>(maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(maxLength: 50, nullable: true),
                    Cep = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Genero = table.Column<string>(nullable: false),
                    TipoPessoa = table.Column<string>(nullable: false),
                    Rg = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    TelefoneUm = table.Column<string>(nullable: true),
                    TelefoneDois = table.Column<string>(nullable: true),
                    CpfeCnpj = table.Column<string>(nullable: true),
                    NomeRazaoSocial = table.Column<string>(maxLength: 50, nullable: true),
                    NomeFantasia = table.Column<string>(maxLength: 50, nullable: true),
                    InscricaoEstadual = table.Column<string>(nullable: true),
                    Observacoes = table.Column<string>(maxLength: 200, nullable: true),
                    EnderecoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PessoaId = table.Column<int>(nullable: false),
                    Pontos = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estoques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    CategoriaId = table.Column<int>(nullable: false),
                    PrecoVenda = table.Column<double>(nullable: false),
                    PrecoCusto = table.Column<double>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    EstoqueAtual = table.Column<int>(nullable: false),
                    LimiteEstoque = table.Column<int>(nullable: true),
                    Validade = table.Column<DateTime>(nullable: true),
                    PessoaId = table.Column<int>(nullable: true),
                    TrocaPontosFidelidade = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estoques_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estoques_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PessoaId = table.Column<int>(nullable: false),
                    Cargo = table.Column<string>(nullable: true),
                    NomeUsuario = table.Column<string>(maxLength: 30, nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    NivelAcesso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PessoaId = table.Column<int>(nullable: false),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Ano = table.Column<int>(nullable: true),
                    Placa = table.Column<string>(nullable: true),
                    Cor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculos_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Unidades = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    PrecoTotal = table.Column<double>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    FormaDePagamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendaEstoque",
                columns: table => new
                {
                    VendaId = table.Column<int>(nullable: false),
                    EstoqueId = table.Column<int>(nullable: false),
                    Unidades = table.Column<int>(nullable: false),
                    PrecoTotalItem = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaEstoque", x => new { x.VendaId, x.EstoqueId });
                    table.ForeignKey(
                        name: "FK_VendaEstoque_Estoques_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "Estoques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendaEstoque_Vendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PessoaId",
                table: "Clientes",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_CategoriaId",
                table: "Estoques",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_PessoaId",
                table: "Estoques",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_PessoaId",
                table: "Funcionarios",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_PessoaId",
                table: "Veiculos",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VendaEstoque_EstoqueId",
                table: "VendaEstoque",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteId",
                table: "Vendas",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "VendaEstoque");

            migrationBuilder.DropTable(
                name: "Estoques");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}

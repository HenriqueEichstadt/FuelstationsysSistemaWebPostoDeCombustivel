﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Posto_de_Combustível.DAO;

namespace Posto_de_Combustivel.Migrations
{
    [DbContext(typeof(PostoContext))]
    partial class PostoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Posto_De_Combustivel.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PessoaId");

                    b.Property<int?>("Pontos");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Posto_De_Combustivel.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasMaxLength(50);

                    b.Property<int>("Cep");

                    b.Property<string>("Cidade")
                        .HasMaxLength(50);

                    b.Property<string>("Complemento")
                        .HasMaxLength(50);

                    b.Property<string>("Estado")
                        .HasMaxLength(50);

                    b.Property<string>("Numero");

                    b.Property<string>("Rua")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Posto_De_Combustivel.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cargo");

                    b.Property<int>("NivelAcesso");

                    b.Property<string>("NomeUsuario")
                        .HasMaxLength(30);

                    b.Property<int>("PessoaId");

                    b.Property<string>("Senha");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Posto_De_Combustivel.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CpfeCnpj");

                    b.Property<DateTime>("DataDeNascimento");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<int?>("EnderecoId");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("InscricaoEstadual");

                    b.Property<string>("Nome");

                    b.Property<string>("NomeFantasia")
                        .HasMaxLength(50);

                    b.Property<string>("NomeRazaoSocial")
                        .HasMaxLength(50);

                    b.Property<string>("Observacoes")
                        .HasMaxLength(200);

                    b.Property<string>("Rg")
                        .HasMaxLength(20);

                    b.Property<string>("Telefone");

                    b.Property<string>("TipoPessoa")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("Posto_De_Combustivel.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Ano");

                    b.Property<string>("Cor");

                    b.Property<string>("Marca");

                    b.Property<string>("Modelo");

                    b.Property<int>("PessoaId");

                    b.Property<string>("Placa");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("Posto_De_Combustivel.Models.Cliente", b =>
                {
                    b.HasOne("Posto_De_Combustivel.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Posto_De_Combustivel.Models.Funcionario", b =>
                {
                    b.HasOne("Posto_De_Combustivel.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Posto_De_Combustivel.Models.Pessoa", b =>
                {
                    b.HasOne("Posto_De_Combustivel.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");
                });

            modelBuilder.Entity("Posto_De_Combustivel.Models.Veiculo", b =>
                {
                    b.HasOne("Posto_De_Combustivel.Models.Pessoa", "pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

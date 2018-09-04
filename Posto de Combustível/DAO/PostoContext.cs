using Microsoft.EntityFrameworkCore;
using Posto_de_Combustivel.Models;
using Posto_De_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustível.DAO
{
    public class PostoContext : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<FabricanteVeiculo> FabricanteVeiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<VendaEstoque>()
                .HasKey(ve => new { ve.VendaId, ve.EstoqueId });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>().HasOne(c => c.CategoriaDaSubCategoria)
                .WithMany()
                .HasForeignKey(c => c.CategoriaId);

            modelBuilder.Entity<FabricanteVeiculo>().HasOne(f => f.TipoDoFabricante)
                .WithMany()
                .HasForeignKey(f => f.FabricanteVeiculoId);
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PostoDB;Trusted_Connection=true;");
        }
    }
}
using Posto_de_Combustível.DAO;
using Posto_De_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.DAO
{
    public class HomeDAO
    {
        // Métodos para somar valores para os índices do Menu Principal do sistema

        public double SomaPrecoTotalVendas()
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Vendas.Where(f => f.FormaDePagamento != 3).ToList().Sum(v => v.PrecoTotal);
            }
        }

        public int SomaTotalDeVendas()
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Vendas.Where(f => f.FormaDePagamento != 3).ToList().Count();

            }
        }

        public int SomaTotalDeClientes()
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Clientes.Where(c => c.Ativo == true).Count();

            }
        }

        public int QuantidadeDeProdutosCadastradosNoEstoque()
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Estoques.Where(p => p.Ativo == true).Count();

            }
        }

        public double BuscaEstoqueBomdaUm()
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Estoques.Where(b => b.Id == 6005).ToList().Sum(e =>e.EstoqueAtual);

            }
        }

        public double BuscaEstoqueBomdaDois()
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Estoques.Where(b => b.Id == 6006).ToList().Sum(e => e.EstoqueAtual);

            }
        }

        public double BuscaEstoqueBomdaTres()
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Estoques.Where(b => b.Id == 6007).ToList().Sum(e => e.EstoqueAtual);

            }
        }

        public double BuscaEstoqueBomdaQuatro()
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Estoques.Where(b => b.Id == 6008).ToList().Sum(e => e.EstoqueAtual);

            }
        }
    }
}
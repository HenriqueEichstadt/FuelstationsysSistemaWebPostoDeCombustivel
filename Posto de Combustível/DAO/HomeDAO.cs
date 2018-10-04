using Posto_de_Combustível.DAO;
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
    }
}
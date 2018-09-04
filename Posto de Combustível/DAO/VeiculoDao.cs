using Microsoft.EntityFrameworkCore;
using Posto_de_Combustível.DAO;
using Posto_De_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.DAO
{
    public class VeiculoDAO
    {
        public void Adiciona(Veiculo veiculo)
        {
            using (var context = new PostoContext())
            {
                context.Veiculos.Add(veiculo);
                context.SaveChanges();
            }
        }
        public IList<Veiculo> ListaVeiculos()
        {
            using (var contexto = new PostoContext())
            {
                return contexto.FabricanteVeiculos
                    .Include(p => p.Subcategoria).ThenInclude(c => c.CategoriaDaSubCategoria);
            }
        }
    }
}
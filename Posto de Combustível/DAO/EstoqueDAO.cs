using Microsoft.EntityFrameworkCore;
using Posto_de_Combustível.DAO;
using Posto_De_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.DAO
{
    public class EstoqueDAO
    {
        public IList<Estoque> ListaProdutos()
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Estoques
                    .Include(p => p.Marca)
                    .Include(p => p.Subcategoria).ThenInclude(c => c.CategoriaDaSubCategoria)
                    .Where(p => p.Subcategoria.CategoriaDaSubCategoria.Id == 1).ToList();
            }
        }

        public IList<Estoque> Lista()
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Estoques.Include(p => p.Marca).Include(p => p.Subcategoria).Include(p => p.CategoriaDaSubcategoria).ToList();
            }
        }
    }
}
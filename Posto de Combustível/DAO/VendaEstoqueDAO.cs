using Microsoft.EntityFrameworkCore;
using Posto_de_Combustível.DAO;
using Posto_de_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.DAO
{
	public class VendaEstoqueDAO
	{
        public IList<VendaEstoque> ListaVendasEstoque()
        {
            using (var contexto = new PostoContext())
            {
                return contexto.VendaEstoque.ToList();
            }
        }
    }
}
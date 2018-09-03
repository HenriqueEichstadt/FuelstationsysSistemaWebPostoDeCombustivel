using Posto_De_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.Models
{
    public class VendaEstoque
    {
        public int VendaId { get; set; }
        public Venda Venda { get; set; }
        public int EstoqueId { get; set; }
        public Estoque Estoque { get; set; }
        public int Unidades { get; set; }
        public double PrecoTotalItem { get; set; }
    }
}
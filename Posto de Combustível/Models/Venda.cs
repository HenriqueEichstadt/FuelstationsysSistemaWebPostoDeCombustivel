using Posto_De_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.Models
{
    public class Venda
    {
        public int Id { get; set; }
        [Required]
        public double Unidades { get; set; }
        public DateTime Data { get; set; }
        public double PrecoTotal { get; set; }
        public Cliente Cliente { get; set; }
        public int? ClienteId { get; set; }
        public IList<VendaEstoque> Estoques { get; set; }
        public int FormaDePagamento { get; set; }
        
        public Venda()
        {
            Estoques = new List<VendaEstoque>();
        }
    }
}
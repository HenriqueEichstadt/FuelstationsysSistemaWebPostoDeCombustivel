using Posto_de_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Posto_De_Combustivel.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        [Required]
        public Categoria Subcategoria { get; set; }
        public double PrecoVenda { get; set; }
        public double PrecoCusto { get; set; }
        public string Descricao { get; set; }
        public int EstoqueAtual { get; set; }
        public int? LimiteEstoque { get; set; }
        public DateTime? Validade { get; set; }
        public Pessoa Pessoa { get; set; }
        public IList<VendaEstoque> Vendas { get; set; }
        public int? TrocaPontosFidelidade { get; set; }

        //public Estoque()
        //{
        //    Vendas = new List<VendaEstoque>();
        //}
    }
}
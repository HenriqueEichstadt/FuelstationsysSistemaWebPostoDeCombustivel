using Posto_de_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Posto_De_Combustivel.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Nome { get; set; }
        public string Marca { get; set; }
        [Required]
        public char Categoria { get; set; }
        [Required]
        public double PrecoVenda { get; set; }
        [Required]
        public double PrecoCusto { get; set; }
        [MaxLength(200)]
        public string Descricao { get; set; }
        [Required]
        public double EstoqueAtual { get; set; }
        public double? LimiteEstoque { get; set; }
        public DateTime? Validade { get; set; }
        public IList<VendaEstoque> Vendas { get; set; }
        public int? TrocaPontosFidelidade { get; set; }
        [Required]
        public bool Ativo { get; set; }

    }
}
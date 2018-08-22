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
        [Required]
        public string Nome { get; set; }
        public string Marca { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        public double PrecoVenda { get; set; }
        public double PrecoCusto { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public DateTime Validade { get; set; }
        public Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
        public int TrocaPontosFidelidade { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Posto_De_Combustivel.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public Pessoa pessoa { get; set; }
        public int PessoaId { get; set; }
        [Required]
        public string TipoDeVeiculo { get; set; }
        [Required]
        public string Fabricante { get; set; }
        [Required]
        public string Modelo { get; set; }
        public int? Ano { get; set; }
        [Required]
        public string Placa { get; set; }
        public string Cor { get; set; }
        public Veiculo CategoriaDaSubCategoria { get; set; }
    }
}
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
        public Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
        public string TipoDeVeiculo { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public int? Ano { get; set; }
        [Required]
        public string Placa { get; set; }
        public string Cor { get; set; }
        public Veiculo CategoriaDaSubCategoria { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Posto_De_Combustivel.Models
{
    public class Cliente
    {
        [Required]
        public int Id { get; set; }
        public Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
        public int? Pontos { get; set; }
        public bool Ativo { get; set; }



    }
}
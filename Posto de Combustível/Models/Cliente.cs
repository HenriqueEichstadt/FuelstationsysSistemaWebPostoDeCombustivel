using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_De_Combustivel.Models
{
    public class Cliente
    {

        public int Id { get; set; }
        public Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
        public int? Pontos { get; set; }



    }
}
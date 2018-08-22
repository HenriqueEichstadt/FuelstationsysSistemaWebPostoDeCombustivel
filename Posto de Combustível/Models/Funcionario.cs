using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Posto_De_Combustivel.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        public int PessoaId { get; set; }

        public Pessoa Pessoa { get; set; }

        public string Cargo { get; set; }

        // Dados para LOGIN no sistema
        [MaxLength(30), MinLength(8)]
        public string NomeUsuario { get; set; }

        [MinLength(8)]
        public string Senha { get; set; }

        public int NivelAcesso { get; set; }



    }
}
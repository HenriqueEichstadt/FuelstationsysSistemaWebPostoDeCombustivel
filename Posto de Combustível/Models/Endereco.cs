using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Posto_De_Combustivel.Models
{
    public class Endereco
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Rua { get; set; }

        [Required, MaxLength(7)]
        public string Numero { get; set; }

        [Required, MaxLength(50)]
        public string Bairro { get; set; }

        [MaxLength(50)]
        public string Complemento { get; set; }

        [Required, MaxLength(50)]
        public string Estado { get; set; }

        [Required ,MaxLength(50)]
        public string Cidade { get; set; }

        [Required ,MaxLength(9)]
        public string Cep { get; set; }

    }
}
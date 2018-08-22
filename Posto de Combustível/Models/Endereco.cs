using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Posto_De_Combustivel.Models
{
    public class Endereco
    {
        // Dados de endereço
        public int Id { get; set; }

        [MaxLength(100)]
        public string Rua { get; set; }
        public string Numero { get; set; }

        [MaxLength(50)]
        public string Bairro { get; set; }

        [MaxLength(50)]
        public string Complemento { get; set; }

        [MaxLength(50)]
        public string Estado { get; set; }

        [MaxLength(50)]
        public string Cidade { get; set; }
        public int Cep { get; set; }

    }
}
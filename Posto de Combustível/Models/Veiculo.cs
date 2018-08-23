using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_De_Combustivel.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public Pessoa pessoa { get; set; }
        public int PessoaId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int? Ano { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
    }
}
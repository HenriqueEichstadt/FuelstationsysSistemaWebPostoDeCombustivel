using Posto_de_Combustivel.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public int Unidades { get; set; }
        public DateTime Data { get; set; }
        public double PrecoTotal { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set;}

        public char TipoVenda { get; set; }


        /*
         * Adicionar o Tipo Venda e o Tipo Troca
         * que poderia entrar na forma de pagamento que tambem poderia ser do tipo "Troca por pontos do programa de fidelidade"
         * 
         */
    }
}
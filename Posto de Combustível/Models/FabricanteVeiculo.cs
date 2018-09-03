using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.Models
{
    public class FabricanteVeiculo
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string TipoEFabricante { get; set; }
        public int? FabricanteVeiculoId { get; set; }
        public FabricanteVeiculo CategoriaDaSubCategoria { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Posto_De_Combustivel.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }
        public int? CategoriaId { get; set; }
        public Categoria CategoriaDaSubCategoria { get; set; }
    }
}
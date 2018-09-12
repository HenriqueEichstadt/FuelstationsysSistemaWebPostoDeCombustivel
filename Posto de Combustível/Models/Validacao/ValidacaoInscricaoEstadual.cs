using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.Models.Validacao
{
    public class ValidacaoInscricaoEstadual
    {
        public bool ValidarInscricaoEstadual(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length == 0 || inscricaoEstadual.Length < 8 || inscricaoEstadual.Length > 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
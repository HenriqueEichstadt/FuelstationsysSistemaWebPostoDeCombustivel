using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.Models.Validacao
{
    public class ValidacaoObservacoes
    {
        public bool ValidarObservacoes(string obs)
        {
            if ( obs.Length >= 0 || obs.Length < 200)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
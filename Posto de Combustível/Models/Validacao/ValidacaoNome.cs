using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.Models.Validacao
{
    public class ValidacaoNome
    {
        public bool ValidaNome(string nome)
        {
            if( nome.Length < 5 || nome.Length > 50)
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
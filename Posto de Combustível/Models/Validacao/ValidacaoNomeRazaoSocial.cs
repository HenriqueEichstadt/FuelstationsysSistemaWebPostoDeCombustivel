using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.Models.Validacao
{
    public class ValidacaoNomeRazaoSocial
    {
        public bool ValidarNomeRazaoSocial(string nomeRazaoSocial)
        {
            if (nomeRazaoSocial.Length == 0 || nomeRazaoSocial.Length < 5 || nomeRazaoSocial.Length > 50)
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
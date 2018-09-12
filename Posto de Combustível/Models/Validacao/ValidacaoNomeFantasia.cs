using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.Models.Validacao
{
    public class ValidacaoNomeFantasia
    {
        public bool ValidarNomeFantasia(string nomeFantasia)
        {
            if (nomeFantasia.Length == 0 || nomeFantasia.Length < 5 || nomeFantasia.Length > 50)
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
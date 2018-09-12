using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.Models.Validacao
{
    public class ValidacaoTelefone
    {
        public bool ValidarTelefoneUm(string telefone)
        {
            if (telefone == null || telefone.Length < 9 && telefone.Length > 11)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidarTelefoneDois(string telefone)
        {
            if (telefone == null || telefone.Length >= 9 && telefone.Length <= 11)
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
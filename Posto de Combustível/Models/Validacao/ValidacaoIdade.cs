using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.Models.Validacao
{
    public class ValidacaoIdade
    {
        private int IdadePessoa(DateTime dataNascimento)
        {
            TimeSpan ts = DateTime.Today - dataNascimento;
            DateTime idade = (new DateTime() + ts).AddYears(-1).AddDays(-1);
            return idade.Year;
        }
        public bool ValidarIdade(DateTime Nascimento)
        {
            var idade = IdadePessoa(Nascimento);
            if (idade < 18 || idade > 150)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.Models.Validacao
{
    public class Validacoes
    {
        public bool ValidaCpf(string cpf)
        {
            ValidacaoCpf validar = new ValidacaoCpf();
            var validado = validar.ValidarCpf(cpf);
            return validado;
        }

        public bool ValidaCnpj(string cnpj)
        {
            ValidacaoCnpj validar = new ValidacaoCnpj();
            var validado = validar.ValidarCnpj(cnpj);
            return validado;
        }

        public bool ValidaIdade(DateTime idade)
        {
            ValidacaoIdade validar = new ValidacaoIdade();
            var validado = validar.ValidarIdade(idade);
            return validado;
        }

        public bool ValidaNomeFantasia(string nomeFantasia)
        {
            ValidacaoNomeFantasia validar = new ValidacaoNomeFantasia();
            var validado = validar.ValidarNomeFantasia(nomeFantasia);
            return validado;
        }

        public bool ValidaInscricaoEstadual(string inscricaoEstadual)
        {
            ValidacaoInscricaoEstadual validar = new ValidacaoInscricaoEstadual();
            var validado = validar.ValidarInscricaoEstadual(inscricaoEstadual);
            return validado;
        }
        public bool ValidaNomeRazaoSocial(string nomeRazaoSocial)
        {
            ValidacaoNomeRazaoSocial validar = new ValidacaoNomeRazaoSocial();
            var validado = validar.ValidarNomeRazaoSocial(nomeRazaoSocial);
            return validado;
        }
        public bool ValidaTelefoneUm(string telefone)
        {
            ValidacaoTelefone validar = new ValidacaoTelefone();
            var validado = validar.ValidarTelefoneUm(telefone);
            return validado;
        }
        public bool ValidaTelefoneDois(string telefone)
        {
            ValidacaoTelefone validar = new ValidacaoTelefone();
            var validado = validar.ValidarTelefoneDois(telefone);
            return validado;
        }
        public bool ValidaEmail(string email)
        {
            ValidacaoEmail validar = new ValidacaoEmail();
            var validado = validar.ValidarEmail(email);
            return validado;
        }
    }
}
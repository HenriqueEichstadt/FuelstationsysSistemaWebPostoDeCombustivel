﻿using Posto_de_Combustivel.Models.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Posto_De_Combustivel.Models
{
    public class Pessoa
    {
        //Dados Pessoais

        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime? Data { get; set; }

        public char? Genero { get; set; }

        public char TipoPessoa { get; set; }

        [MaxLength(20)]
        public string Rg { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public string TelefoneUm { get; set; }

        public string TelefoneDois { get; set; }

        public string CpfeCnpj { get; set; }

        //Dados Adicionais Fornecedor

        [MaxLength(50)]
        public string NomeRazaoSocial { get; set; }

        [MaxLength(50)]
        public string NomeFantasia { get; set; }

        public string InscricaoEstadual { get; set; }

        [MaxLength(200)]
        public string Observacoes { get; set; }

        public Endereco Endereco { get; set; }

        public Veiculo Veiculo { get; set; }

        // Construtores
        //Pede para adicionar o nome do cliente
        public Pessoa(string nome)
        {
            this.Nome = nome;
        }
        //Tornando o parametro nome opcional
        public Pessoa() { }

       

    }
}
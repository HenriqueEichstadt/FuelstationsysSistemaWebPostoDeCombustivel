using Posto_de_Combustivel.Models.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Posto_De_Combustivel.Models
{
    public class Pessoa
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime Data { get; set; }
        
        public char? Genero { get; set; }

        [Required]
        public char TipoPessoa { get; set; }

        [MaxLength(15)]
        public string Rg { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required, MinLength(13), MaxLength(14)]
        public string TelefoneUm { get; set; }

        [MinLength(13), MaxLength(14)]
        public string TelefoneDois { get; set; }

        [Required, MinLength(14), MaxLength(18)]
        public string CpfeCnpj { get; set; }

        //Dados Adicionais Fornecedor

        [MinLength(5), MaxLength(50)]
        public string NomeRazaoSocial { get; set; }

        [MinLength(5), MaxLength(50)]
        public string NomeFantasia { get; set; }

        [MinLength(5), MaxLength(50)]
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

        public int IdadePessoa(DateTime dataNascimento)
        {
            TimeSpan ts = DateTime.Today - dataNascimento;
            DateTime idade = (new DateTime() + ts).AddYears(-1).AddDays(-1);
            return idade.Year;
        }

    }
}
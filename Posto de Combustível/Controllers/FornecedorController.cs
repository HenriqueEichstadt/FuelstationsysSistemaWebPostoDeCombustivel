using Posto_de_Combustivel.DAO;
using Posto_de_Combustivel.Models.Validacao;
using Posto_De_Combustivel.Filtros;
using Posto_De_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Posto_de_Combustivel.Controllers
{
    public class FornecedorController : Controller
    {

        // Tela que Exibe o cadastro de fornecedor
        [AutorizacaoFilter]
        public ActionResult Index()
        {
            ViewBag.Pessoa = new Pessoa();
            ViewBag.Pessoa.Endereco = new Endereco();
            
            return View();
        }

        // Action para Cadastrar Fornecedor
        [HttpPost]
        public ActionResult AdicionaFornecedor(Pessoa pessoa)
        {

            FornecedorDAO dao = new FornecedorDAO();
            pessoa.TipoPessoa = 'J';
            pessoa.Data = DateTime.Now;
            var cnpj = Validacoes.ValidaCnpj(pessoa.CpfeCnpj);
            var nomeF = Validacoes.ValidaNomeFantasia(pessoa.NomeFantasia);
            var razSoc = Validacoes.ValidaNomeRazaoSocial(pessoa.NomeRazaoSocial);
            var insEst = Validacoes.ValidaInscricaoEstadual(pessoa.InscricaoEstadual);
            var telUm = Validacoes.ValidaTelefoneUm(pessoa.TelefoneUm);
            var telDois = Validacoes.ValidaTelefoneDois(pessoa.TelefoneDois);
            var email = Validacoes.ValidaEmail(pessoa.Email);
            if (pessoa != null && cnpj == true && nomeF == true && razSoc == true && insEst == true && telUm == true && telDois == true && email == true)
            {
                dao.Adiciona(pessoa);
               // return Json(new { adicionou = true, msg = "nao adicionou" });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Pessoa = pessoa;
                return View("Index");
            }
        }
    }
}
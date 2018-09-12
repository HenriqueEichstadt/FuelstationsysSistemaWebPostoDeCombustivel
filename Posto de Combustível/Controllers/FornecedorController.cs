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
            Validacoes valida = new Validacoes();
            pessoa.TipoPessoa = 'J';
            var cnpj = valida.ValidaCnpj(pessoa.CpfeCnpj);
            var nomeF = valida.ValidaNomeFantasia(pessoa.NomeFantasia);
            var razSoc = valida.ValidaNomeRazaoSocial(pessoa.NomeRazaoSocial);
            var insEst = valida.ValidaInscricaoEstadual(pessoa.InscricaoEstadual);
            var telUm = valida.ValidaTelefoneUm(pessoa.TelefoneUm);
            var telDois = valida.ValidaTelefoneDois(pessoa.TelefoneDois);
            var email = valida.ValidaEmail(pessoa.Email);
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
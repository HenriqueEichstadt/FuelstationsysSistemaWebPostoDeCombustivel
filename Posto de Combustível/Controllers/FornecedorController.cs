using Posto_de_Combustivel.DAO;
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
        public ActionResult AdicionaFornecedor(Pessoa pessoa, Endereco endereco)
        {

            FornecedorDAO dao = new FornecedorDAO();
            pessoa.TipoPessoa = 'J';
            pessoa.Data = DateTime.Now;
            if (pessoa != null && endereco != null)
            {
                dao.Adiciona(pessoa, endereco);
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
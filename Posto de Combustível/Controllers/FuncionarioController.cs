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
    public class FuncionarioController : Controller
    {
        // Exibe a Tela de Login do Sistema
        public ActionResult Index()
        {
            return View();
        }

        // Exibe Tela Para Adicionar novo Usuário
        [AutorizacaoFilter]
        public ActionResult Form()
        {
            ViewBag.Funcionario = new Funcionario() { Pessoa = new Pessoa() { Endereco = new Endereco() } };

            return View();
        }

        [HttpPost]
        public ActionResult Autentica(String nomeusuario, String senha)
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            Funcionario funcionario = dao.Busca(nomeusuario, senha);
            if (funcionario != null)
            {
                Session["FuncionarioLogado"] = funcionario;
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult AdicionaUsuario(Funcionario funcionario, string repitasenha)
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            funcionario.Pessoa.TipoPessoa = 'F';
            if (funcionario.Senha == repitasenha)
            {
                dao.Adiciona(funcionario);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Funcionario = funcionario;
                return View("Form");
            }
        }
    }
}
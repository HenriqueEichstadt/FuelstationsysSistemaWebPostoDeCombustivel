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
        public ActionResult Funcionarios()
        {
           
            return View();
        }
        public ActionResult UpdateForm()
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
                Session.Timeout = 10;
                
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public JsonResult EncerrarSessao()
        {
            Session.Abandon();
            return Json(new { logOut = true });
        }

        public ActionResult AdicionaUsuario(Funcionario funcionario, string repitasenha)
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            funcionario.Pessoa.TipoPessoa = 'F';
            var nome = Validacoes.ValidaNomePessoa(funcionario.Pessoa.Nome);
            var gen = funcionario.Pessoa.Genero;
            var rg = Validacoes.ValidaRg(funcionario.Pessoa.Rg);
            var cpf = Validacoes.ValidaCpf(funcionario.Pessoa.CpfeCnpj);
            var idade = Validacoes.ValidaIdade(funcionario.Pessoa.Data);
            var email = Validacoes.ValidaEmail(funcionario.Pessoa.Email);
            var telUm = Validacoes.ValidaTelefoneUm(funcionario.Pessoa.TelefoneUm);
            var telDois = Validacoes.ValidaTelefoneDois(funcionario.Pessoa.TelefoneDois);

            if (funcionario.Senha == repitasenha && gen != null && nome == true && rg == true && cpf == true && idade == true && email == true && telUm == true && telDois == true)
            {
                dao.Adiciona(funcionario);
                return RedirectToAction("Funcionarios", "Funcionario");
            }
            else
            {
                ViewBag.Funcionario = funcionario;
                return View("Form");
            }
        }

        public JsonResult ListaFuncionarios(Funcionario funcionario)
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            return Json(new
            {
                data = new FuncionarioDAO().ListaFuncionarios(funcionario)
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ModificaFuncionarios(Funcionario funcionario, string repitasenha)
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            funcionario.Pessoa.TipoPessoa = 'F';
            var nome = Validacoes.ValidaNomePessoa(funcionario.Pessoa.Nome);
            var gen = funcionario.Pessoa.Genero;
            var rg = Validacoes.ValidaRg(funcionario.Pessoa.Rg);
            var cpf = Validacoes.ValidaCpf(funcionario.Pessoa.CpfeCnpj);
            var idade = Validacoes.ValidaIdade(funcionario.Pessoa.Data);
            var email = Validacoes.ValidaEmail(funcionario.Pessoa.Email);
            var telUm = Validacoes.ValidaTelefoneUm(funcionario.Pessoa.TelefoneUm);
            var telDois = Validacoes.ValidaTelefoneDois(funcionario.Pessoa.TelefoneDois);

            if (funcionario.Senha == repitasenha && gen != null && nome == true && rg == true && cpf == true && idade == true && email == true && telUm == true && telDois == true)
            {
                dao.Atualiza(funcionario);
                return Json(new
                {
                    data = true
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ViewBag.Funcionario = funcionario;
                return Json(new
                {
                    data = false
                }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult DeletaFuncionario(int id)
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.Deleta(id);
            return Json(new { deletou = true }, JsonRequestBehavior.AllowGet);
        }
    }
}
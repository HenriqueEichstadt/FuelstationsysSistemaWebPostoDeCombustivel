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
    public class ClienteController : Controller
    {
        // Exibe Tela para Cadastrar Cliente
        //[AutorizacaoFilter]
        public ActionResult Index()
        {
            ViewBag.Cliente = new Cliente()
            {
                Pessoa = new Pessoa()
                {
                    Endereco = new Endereco(),
                    Veiculo = new Veiculo(),

                }
            };
            return View();
        }

        public ActionResult Clientes()
        {
            return View();
        }

        public ActionResult AdicionaCliente(Cliente cliente)
        {
            ClienteDAO dao = new ClienteDAO();
            cliente.Pessoa.TipoPessoa = 'F';
            cliente.Pontos = 0;
            var nome = Validacoes.ValidaNomePessoa(cliente.Pessoa.Nome);
            var gen = cliente.Pessoa.Genero;
            var rg = Validacoes.ValidaRg(cliente.Pessoa.Rg);
            var cpf = Validacoes.ValidaCpf(cliente.Pessoa.CpfeCnpj);
            var idade = Validacoes.ValidaIdade(cliente.Pessoa.Data);
            var email = Validacoes.ValidaEmail(cliente.Pessoa.Email);
            var telUm = Validacoes.ValidaTelefoneUm(cliente.Pessoa.TelefoneUm);
            var telDois = Validacoes.ValidaTelefoneDois(cliente.Pessoa.TelefoneDois);

            if (cliente != null && gen != null && nome == true && rg == true && cpf == true && idade == true && email == true && telUm == true && telDois == true)
            {
                dao.AdicionaCliente(cliente);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Pessoa = cliente;
                return View("Index");
            }
        }
        public JsonResult ListaClientes(Cliente cliente)
        {
            return Json(new
            {
                data = new ClienteDAO().ListaClientes(cliente)
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
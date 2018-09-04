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

        public ActionResult AdicionaCliente(Cliente cliente, Veiculo veiculo)
        {
            ClienteDAO dao = new ClienteDAO();
            cliente.Pessoa.TipoPessoa = 'F';
            cliente.Pontos = 0;
            if (cliente != null)
            {
                dao.Adiciona(cliente);
                
             
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Pessoa = cliente;
                return View("Index");
            }
        }
        public JsonResult ListaFabricantesVeiculos()
        {
            return Json(new
            {
                data = new VeiculoDAO().ListaProdutos()
            }, JsonRequestBehavior.AllowGet);
        }
}
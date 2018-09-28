using Posto_de_Combustivel.DAO;
using Posto_de_Combustivel.Models;
using Posto_De_Combustivel.Filtros;
using Posto_De_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Posto_de_Combustivel.Controllers
{
    public class VendaController : Controller
    {
        [AutorizacaoFilter]
        public ActionResult Index()
        {
            ViewBag.Venda = new Venda();
            return View();
        }

        public ActionResult Venda()
        {
            ViewBag.Venda = new Venda();
            return View();
        }

        public ActionResult EmitirVenda(int unidades, double precoTotal, Cliente cliente, IList<VendaEstoque> vendaEstoque, int formaDePagamento)
        {
            EstoqueDAO dao = new EstoqueDAO();
            Venda venda = new Venda();
            venda.Data = DateTime.Now;
            venda.Unidades = unidades;
            venda.PrecoTotal = precoTotal;
            venda.Cliente = cliente;
            venda.Estoques = vendaEstoque;
            venda.FormaDePagamento = formaDePagamento;
            return View();
        }
    }
}
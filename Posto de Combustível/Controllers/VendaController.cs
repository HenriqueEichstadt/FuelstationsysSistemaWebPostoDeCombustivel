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
        public ActionResult Index()
        {

            ViewBag.Venda = new Venda();
            return View();
        }

        public ActionResult Venda()
        {
            return View();
        }

        public ActionResult Vendas()
        {
            return View();
        }

        public JsonResult EmitirVenda(Venda venda, List<VendaEstoque> arrayDeVendaEstoque)
        {
            venda.Estoques = arrayDeVendaEstoque;
            venda.Data = DateTime.Now;
            VendaDAO dao = new VendaDAO();
            dao.AdicionaVenda(venda);
            dao.DecrementaDoEstoque(arrayDeVendaEstoque);

            if (venda.FormaDePagamento == 0 || venda.FormaDePagamento == 1)
            {
                int QtdDePontos = Convert.ToInt32(venda.PrecoTotal * 0.8);
                dao.SomaPontos(venda.ClienteId, QtdDePontos);
            }

            return Json(new { adicionou = true });
        }

        public JsonResult ListaVendas()
        {
            return Json(new
            {
                data = new VendaDAO().ListaVendas()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
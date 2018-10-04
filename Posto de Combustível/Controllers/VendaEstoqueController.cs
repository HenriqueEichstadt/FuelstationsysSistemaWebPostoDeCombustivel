using Posto_de_Combustivel.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Posto_de_Combustivel.Controllers
{
    public class VendaEstoqueController : Controller
    {
        // GET: VendaEstoque
        public ActionResult VendasEstoque()
        {
            return View();
        }

        public JsonResult ListaVendasEstoque()
        {
            VendaEstoqueDAO dao = new VendaEstoqueDAO();
            var lista = dao.ListaVendasEstoque();


            JsonResult js = Json(new
            { data = lista }, JsonRequestBehavior.AllowGet);

            js.MaxJsonLength = int.MaxValue;
            return js;
        }
    }
}
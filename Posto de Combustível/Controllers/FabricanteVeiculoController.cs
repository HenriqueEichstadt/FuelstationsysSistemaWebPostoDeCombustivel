using Posto_de_Combustivel.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Posto_de_Combustivel.Controllers
{
    public class FabricanteVeiculoController : Controller
    {
        // GET: FabricanteVeiculo
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListaFabricantes(int id)
        {
            return Json(new
            {
                data = new VeiculoDAO().ListaFabricantes(id)
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListaTipoDeVeiculo()
        {
            return Json(new
            {
                data = new VeiculoDAO().ListaTipoDeVeiculo()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
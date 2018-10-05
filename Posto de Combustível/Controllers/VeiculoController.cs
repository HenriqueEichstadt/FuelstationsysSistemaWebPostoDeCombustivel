using Posto_de_Combustivel.DAO;
using Posto_De_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Posto_de_Combustivel.Controllers
{
    public class VeiculoController : Controller
    {
        // GET: Veiculo
        public ActionResult Veiculos()
        {
            return View();
        }

        public JsonResult ListaVeiculos()
        {
            return Json(new
            {
                data = new VeiculoDAO().ListaVeiculos()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
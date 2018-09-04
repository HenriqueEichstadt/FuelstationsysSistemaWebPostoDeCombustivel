using Posto_de_Combustivel.DAO;
using Posto_de_Combustível.DAO;
using Posto_De_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Posto_de_Combustivel.Controllers
{
    public class EstoqueController : Controller
    {
        // GET: Estoque
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListaProdutos()
        {
            return Json(new
            {
                data = new EstoqueDAO().ListaProdutos()
            }, JsonRequestBehavior.AllowGet);
                


            //using(PostoContext pc = new PostoContext())
            //{
            //    var data = pc.Estoques.OrderBy(a => a.Nome).ToList();
            //    return Json(new { data }, JsonRequestBehavior.AllowGet);
            //}
        }
    }
}
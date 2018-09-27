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
    public class VendaController : Controller
    {
        [AutorizacaoFilter]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmitirVenda(Estoque estoque)
        {
            EstoqueDAO dao = new EstoqueDAO();
            return View();
        }
    }
}
using Posto_De_Combustivel.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Posto_De_Combustivel.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [AutorizacaoFilter]
        public ActionResult Index()
        {
            return View();
        }

        }
    }

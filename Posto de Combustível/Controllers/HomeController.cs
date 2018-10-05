using Posto_de_Combustivel.DAO;
using Posto_De_Combustivel.Filtros;
using Posto_De_Combustivel.Models;
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

        // Exibe o Menu Principal com o Template Pronto
        [AutorizacaoFilter]
        public ActionResult MenuPrincipal()
        {
            ViewBag.Funcionario = new Funcionario() { Pessoa = new Pessoa() { Endereco = new Endereco() } };
            return View();
        }

		public JsonResult ListaPrecoTotalVendas()
		{
            return Json(new
            {
                data = new HomeDAO().SomaPrecoTotalVendas()
			}, JsonRequestBehavior.AllowGet);
		}
        public JsonResult SomaNumeroTotaDeVendas()
        {
            return Json(new
            {
                data = new HomeDAO().SomaTotalDeVendas()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SomaNumeroDeClientes()
        {
            return Json(new
            {
                data = new HomeDAO().SomaTotalDeClientes()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ProdutosCadastradosNoEstoque()
        {
            return Json(new
            {
                data = new HomeDAO().QuantidadeDeProdutosCadastradosNoEstoque()
            }, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult ExibeGanhosSemanais()
        //{
        //    return Json(new
        //    {
        //        data = new HomeDAO().BuscaGanhosSemanais()
        //    }, JsonRequestBehavior.AllowGet);
        //}

    }
}

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
        public ActionResult Produtos()
        {
            return View();
        }

        public ActionResult Form()
        {
            ViewBag.Estoque = new Estoque();
            return View();
        }

        public ActionResult UpdateForm(int id)
        {
            EstoqueDAO dao = new EstoqueDAO();

            ViewBag.Produto = dao.BuscaPorId(id);

            return View();
        }

        public JsonResult ListaProdutos()
        {
            return Json(new
            {
                data = new EstoqueDAO().ListaProdutos()
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaProdutosParaAVenda()
        {
            return Json(new
            {
                data = new EstoqueDAO().ListaProdutosParaAVenda()
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AdicionaProdutoEstoque(Estoque estoque)
        {
            EstoqueDAO dao = new EstoqueDAO();
            estoque.Ativo = true;
            if (estoque != null)
            {
                dao.Adiciona(estoque);
                return RedirectToAction("Produtos", "Estoque");
            }
            else
            {
                return View("Form");
            }
        }
        public ActionResult EditaProduto(Estoque estoque)
        {
            EstoqueDAO dao = new EstoqueDAO();

            if (estoque != null)
            {
                estoque.Ativo = true;
                dao.Atualiza(estoque);
                return View("Produtos");
            }
            else
            {
                return View("UpdateForm");
            }
        }
        public JsonResult InativaProduto(int id)
        {
            EstoqueDAO dao = new EstoqueDAO();
            dao.Inativa(id);
            return Json(new { inativou = true }, JsonRequestBehavior.AllowGet);
        }
    }
}
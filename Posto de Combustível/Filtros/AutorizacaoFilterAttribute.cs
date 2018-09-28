using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Posto_De_Combustivel.Filtros
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object usuario = filterContext.HttpContext.Session["FuncionarioLogado"];

            bool funcionario = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Funcionario";
            bool index = filterContext.ActionDescriptor.ActionName == "Index";
            bool autentica = filterContext.ActionDescriptor.ActionName == "Autentica";
            bool actionDeLogin = (funcionario && index) || (funcionario && autentica);
            if (usuario == null && !actionDeLogin)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Funcionario", action = "Index"}
                        )
                    );
            }
        }
    }
}
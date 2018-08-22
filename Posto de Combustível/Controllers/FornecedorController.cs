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
    public class FornecedorController : Controller
    {
        
        // Tela que Exibe o cadastro de fornecedor
        public ActionResult Index()
        {
            return View();
        }

        // Action para Cadastrar Fornecedor
        [AutorizacaoFilter]
        public ActionResult AdicionaFornecedor(Pessoa pessoa, Endereco endereco)
        {

            PessoaDAO dao = new PessoaDAO();
            return View();
        }
    }
}
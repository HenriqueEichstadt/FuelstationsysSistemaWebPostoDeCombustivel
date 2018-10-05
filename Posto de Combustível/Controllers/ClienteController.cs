using Posto_de_Combustivel.DAO;
using Posto_de_Combustivel.Models.Validacao;
using Posto_De_Combustivel.Filtros;
using Posto_De_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Posto_de_Combustivel.Controllers
{
	public class ClienteController : Controller
	{
		// Exibe Tela para Cadastrar Cliente
		//[AutorizacaoFilter]
		public ActionResult Index()
		{
			ViewBag.Cliente = new Cliente()
			{
				Pessoa = new Pessoa()
				{
					Endereco = new Endereco(),
					Veiculo = new Veiculo(),

				}
			};
			return View();
		}

		public ActionResult Clientes()
		{
			return View();
		}

		public ActionResult UpdateForm(int id)
		{
			ClienteDAO dao = new ClienteDAO();
			ViewBag.Cliente = dao.BuscaPorId(id);
			return View();
		}

		public ActionResult AdicionaCliente(Cliente cliente)
		{
			ClienteDAO dao = new ClienteDAO();
			cliente.Pessoa.TipoPessoa = 'F';
			cliente.Ativo = true;
			cliente.Pontos = 0;
			var nome = Validacoes.ValidaNomePessoa(cliente.Pessoa.Nome);
			var gen = cliente.Pessoa.Genero;
			var rg = Validacoes.ValidaRg(cliente.Pessoa.Rg);
			var cpf = Validacoes.ValidaCpf(cliente.Pessoa.CpfeCnpj);
			var idade = Validacoes.ValidaIdade(cliente.Pessoa.Data);
			var email = Validacoes.ValidaEmail(cliente.Pessoa.Email);
			var telUm = Validacoes.ValidaTelefoneUm(cliente.Pessoa.TelefoneUm);
			var telDois = Validacoes.ValidaTelefoneDois(cliente.Pessoa.TelefoneDois);
			var procuracpf = dao.BuscaCPfCnpj(cliente.Pessoa.CpfeCnpj);
            var veiculo = cliente.Pessoa.Veiculo;
            var fabricante = veiculo.Fabricante;

			if ( fabricante != null && veiculo != null && procuracpf == null && gen != null && nome == true && rg == true && cpf == true && idade == true && email == true && telUm == true && telDois == true)
			{
				if(procuracpf != null)
				{
					return Json(new { ExistePessoa = true }, JsonRequestBehavior.AllowGet);
				}

				dao.AdicionaCliente(cliente);
				return RedirectToAction("Clientes", "Cliente");
			}
			else
			{
                ViewBag.Cliente = cliente;
                return View("Index");
			}
		}
		public JsonResult ListaClientes()
		{
			return Json(new
			{
				data = new ClienteDAO().ListaClientes()
			}, JsonRequestBehavior.AllowGet);
		}

        public JsonResult ListaClientesVenda()
        {
            var dao = new VeiculoDAO();
            var data = new List<object>();

            foreach (var cliente in new ClienteDAO().ListaClientes())
            {
                data.Add(new
                {
                    cliente.Id,
                    cliente.Pessoa.Nome,
                    cliente.Pontos,
                    dao.BuscaPorPessoa(cliente.Pessoa.Id).Placa
                });
            }


            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateCliente(Cliente cliente)
		{
			ClienteDAO dao = new ClienteDAO();
			var nome = Validacoes.ValidaNomePessoa(cliente.Pessoa.Nome);
			var gen = cliente.Pessoa.Genero;
			var rg = Validacoes.ValidaRg(cliente.Pessoa.Rg);
			var cpf = Validacoes.ValidaCpf(cliente.Pessoa.CpfeCnpj);
			var idade = Validacoes.ValidaIdade(cliente.Pessoa.Data);
			var email = Validacoes.ValidaEmail(cliente.Pessoa.Email);
			var telUm = Validacoes.ValidaTelefoneUm(cliente.Pessoa.TelefoneUm);
			var telDois = Validacoes.ValidaTelefoneDois(cliente.Pessoa.TelefoneDois);

			if (gen != null && nome == true && rg == true && cpf == true && idade == true && email == true && telUm == true && telDois == true)
			{
				cliente.Ativo = true;
				cliente.Pessoa.TipoPessoa = 'F';
				dao.Atualiza(cliente);
				return RedirectToAction("Clientes", "Cliente");
			}
			else
			{
				ViewBag.Cliente = cliente;
				return View("UpdateForm");
			}
		}
		public JsonResult InativaCliente(int id)
		{
			ClienteDAO dao = new ClienteDAO();
			dao.Inativa(id);
			return Json(new { inativou = true }, JsonRequestBehavior.AllowGet);
		}
	}
}

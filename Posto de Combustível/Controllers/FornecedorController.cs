﻿using Posto_de_Combustivel.DAO;
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
    public class FornecedorController : Controller
    {

        // Tela que Exibe o cadastro de fornecedor
        [AutorizacaoFilter]
        public ActionResult Index()
        {
            ViewBag.Pessoa = new Pessoa();
            ViewBag.Pessoa.Endereco = new Endereco();

            return View();
        }

        public ActionResult Fornecedores()
        {
            return View();
        }

        public ActionResult UpdateForm(int id)
        {
            FornecedorDAO dao = new FornecedorDAO();
            ViewBag.Fornecedor = dao.BuscaPorId(id);
            return View();
        }

        // Action para Cadastrar Fornecedor
        [HttpPost]
        public ActionResult AdicionaFornecedor(Pessoa pessoa)
        {

            FornecedorDAO dao = new FornecedorDAO();
            pessoa.TipoPessoa = 'J';
            pessoa.Data = DateTime.Now;
            var cnpj = Validacoes.ValidaCnpj(pessoa.CpfeCnpj);
            var nomeF = Validacoes.ValidaNomeFantasia(pessoa.NomeFantasia);
            var razSoc = Validacoes.ValidaNomeRazaoSocial(pessoa.NomeRazaoSocial);
            var insEst = Validacoes.ValidaInscricaoEstadual(pessoa.InscricaoEstadual);
            var telUm = Validacoes.ValidaTelefoneUm(pessoa.TelefoneUm);
            var telDois = Validacoes.ValidaTelefoneDois(pessoa.TelefoneDois);
            var email = Validacoes.ValidaEmail(pessoa.Email);
            var procuracpf = dao.BuscaCPfCnpj(pessoa.CpfeCnpj);
            var rua = pessoa.Endereco.Rua;
            var num = pessoa.Endereco.Numero;
            var bairro = pessoa.Endereco.Bairro;
            var estado = pessoa.Endereco.Estado;
            var cidade = pessoa.Endereco.Cidade;
            var cep = pessoa.Endereco.Cep;

            if ( procuracpf == null && pessoa != null && cnpj == true && nomeF == true && razSoc == true &&
                insEst == true && telUm == true && telDois == true && email == true && rua != null && num != null &&
                bairro != null && estado != null && cidade != null && cep != null)
            {
                dao.Adiciona(pessoa);
                // return Json(new { adicionou = true, msg = "nao adicionou" });
                return RedirectToAction("Fornecedores", "Fornecedor");
            }
            else
            {
                ViewBag.Pessoa = pessoa;
                return View("Index");
            }
        }
        public JsonResult ListaFornecedores(Pessoa pessoa)
        {
            char fornecedor = pessoa.TipoPessoa;
            return Json(new
            {
                data = new FornecedorDAO().ListaFornecedores(pessoa)
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeletaFornecedor(int id)
        {
            FornecedorDAO dao = new FornecedorDAO();
            dao.Deleta(id);
            return Json(new { deletou = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditaFornecedor(Pessoa fornecedor)
        {
            FornecedorDAO dao = new FornecedorDAO();
            fornecedor.TipoPessoa = 'J';
            fornecedor.Data = DateTime.Now;
            var cnpj = Validacoes.ValidaCnpj(fornecedor.CpfeCnpj);
            var nomeF = Validacoes.ValidaNomeFantasia(fornecedor.NomeFantasia);
            var razSoc = Validacoes.ValidaNomeRazaoSocial(fornecedor.NomeRazaoSocial);
            var insEst = Validacoes.ValidaInscricaoEstadual(fornecedor.InscricaoEstadual);
            var telUm = Validacoes.ValidaTelefoneUm(fornecedor.TelefoneUm);
            var telDois = Validacoes.ValidaTelefoneDois(fornecedor.TelefoneDois);
            var email = Validacoes.ValidaEmail(fornecedor.Email);
            var rua = fornecedor.Endereco.Rua;
            var num = fornecedor.Endereco.Numero;
            var bairro = fornecedor.Endereco.Bairro;
            var estado = fornecedor.Endereco.Estado;
            var cidade = fornecedor.Endereco.Cidade;
            var cep = fornecedor.Endereco.Cep;
            if (fornecedor != null && cnpj == true && nomeF == true && razSoc == true && insEst == true && telUm == true && telDois == true && email == true 
                && fornecedor.Endereco.Cidade != null && rua != null && num != null && bairro != null && estado != null && cidade != null && cep != null)
            {
                dao.Atualiza(fornecedor);
                return RedirectToAction("Fornecedores", "Fornecedor");
            }
            else
            {
                ViewBag.Pessoa = fornecedor;
                return View("UpdateForm");
            }
        }
    }
}

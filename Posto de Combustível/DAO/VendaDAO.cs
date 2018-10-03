﻿using Microsoft.EntityFrameworkCore;
using Posto_de_Combustível.DAO;
using Posto_de_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.DAO
{
    public class VendaDAO
    {
        public void AdicionaVenda(Venda venda)
        {
            using (var context = new PostoContext())
            {
                context.Vendas.Add(venda);
                context.SaveChanges();
            }
        }

        public IList<Venda> ListaVendas()
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Vendas.Include(c => c.Cliente).ThenInclude(p => p.Pessoa).ToList();
            }
        }

        public void DecrementaDoEstoque(List<VendaEstoque> vendaEstoque)
        {
            using (var contexto = new PostoContext())
            {
                foreach (var estoques in vendaEstoque)
                {
                    DecrementaProdutoDoEstoque(estoques.EstoqueId, estoques.Unidades);
                }
            }
        }

        public void DecrementaProdutoDoEstoque(int id, double quantidade)
        {
            using (var contexto = new PostoContext())
            {
                var produto = contexto.Estoques.Find(id);
                produto.EstoqueAtual -= quantidade;
                contexto.Entry(produto).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

    }
}
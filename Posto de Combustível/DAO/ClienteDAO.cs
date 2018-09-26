﻿using Posto_de_Combustível.DAO;
using Posto_De_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace Posto_de_Combustivel.DAO
{
    public class ClienteDAO
    {
        public void AdicionaCliente(Cliente cliente)
        {
            using (var context = new PostoContext())
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
                // return cliente.Id;
            }
        }

        public void Inativa(int id)
        {
            using (var context = new PostoContext())
            {
                var cliente = new ClienteDAO().BuscaPorId(id);
                cliente.Ativo = false;
                context.Entry(cliente).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public IList<Cliente> ListaClientes()
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Clientes.Include(f => f.Pessoa).Where(c => c.Ativo == true).ToList();
            }
        }

        public Cliente BuscaPorId(int id)
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Clientes.Find(id);
            }
        }

        public void Atualiza(Cliente cliente)
        {
            using (var contexto = new PostoContext())
            {
                contexto.Entry(cliente).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Pessoa Busca(string login, string senha)
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Pessoas.FirstOrDefault();
            }
        }
    }
}
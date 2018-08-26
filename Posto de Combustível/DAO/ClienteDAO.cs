using Posto_de_Combustível.DAO;
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
        public void Adiciona(Cliente cliente)
        {
            using (var context = new PostoContext())
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
        }

        public IList<Pessoa> Lista()
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Pessoas.ToList();
            }
        }

        public Pessoa BuscaPorId(int id)
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Pessoas.Find(id);
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
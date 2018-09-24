using Microsoft.EntityFrameworkCore;
using Posto_de_Combustível.DAO;
using Posto_De_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.DAO
{
    public class FornecedorDAO
    {
        public void Adiciona(Pessoa pessoa)
        {
            using (var context = new PostoContext())
            {
                context.Pessoas.Add(pessoa);
                context.SaveChanges();
            }
        }

        public IList<Pessoa> ListaFornecedores(Pessoa pessoa)
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

        public void Atualiza(Pessoa pessoa)
        {
            using (var contexto = new PostoContext())
            {
                contexto.Entry(pessoa).State = EntityState.Modified;
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
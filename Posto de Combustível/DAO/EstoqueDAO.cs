using Microsoft.EntityFrameworkCore;
using Posto_de_Combustível.DAO;
using Posto_De_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.DAO
{
    public class EstoqueDAO
    {

        public void Adiciona(Estoque estoque)
        {
            using (var context = new PostoContext())
            {
                context.Estoques.Add(estoque);
                context.SaveChanges();
            }
        }

        public void Inativa(int id)
        {
            using (var context = new PostoContext())
            {
                var estoque = new EstoqueDAO().BuscaPorId(id);
               
                estoque.Ativo = false;
            }
        }

        public IList<Estoque> ListaProdutos()
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Estoques.Where(a => a.Ativo == true).ToList();
            }
        }
        
        public void Atualiza(Estoque estoque)
        {
            using (var contexto = new PostoContext())
            {
                contexto.Entry(estoque).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }


        public Estoque BuscaPorId(int id)
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Estoques.Find(id);
            }
        }

    }
}
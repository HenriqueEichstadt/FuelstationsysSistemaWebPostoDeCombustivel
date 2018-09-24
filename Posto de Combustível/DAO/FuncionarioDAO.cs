using Posto_de_Combustível.DAO;
using Posto_De_Combustivel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.DAO
{
    public class FuncionarioDAO
    {
        public void Adiciona(Funcionario funcionario)
        {
            using (var context = new PostoContext())
            {
                context.Funcionarios.Add(funcionario);
                context.SaveChanges();
            }
        }

        public IList<Funcionario> ListaFuncionarios(Funcionario funcionario)
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Funcionarios.ToList();
            }
        }

        public Funcionario BuscaPorId(int id)
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Funcionarios.Find(id);
            }
        }

        public void Atualiza(Funcionario funcionario)
        {
            using (var contexto = new PostoContext())
            {
                contexto.Entry(funcionario).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Funcionario Busca(string login, string senha)
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Funcionarios.Include(f => f.Pessoa).FirstOrDefault(f => f.NomeUsuario == login && f.Senha == senha);
            }
        }
        
    }
}
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

        public void Deleta(int id)
        {
            using (var context = new PostoContext())
            {
                var funcionario = new FuncionarioDAO().BuscaPorId(id);
                context.Funcionarios.Remove(funcionario);
                var pessoa = context.Pessoas.Find(funcionario.PessoaId);
                context.Pessoas.Remove(pessoa);
                var endereco = context.Enderecos.Find(pessoa.EnderecoId);
                context.Enderecos.Remove(endereco);
                context.SaveChanges();
            }
        }

        public IList<Funcionario> ListaFuncionarios(Funcionario funcionario)
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Funcionarios.Include(f => f.Pessoa).ToList();
            }
        }

        public Funcionario BuscaPorId(int id)
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Funcionarios.Include(f => f.Pessoa).ThenInclude(f => f.Endereco).Where(e => e.Id == id).FirstOrDefault();
            }
        }

        public void Atualiza(Funcionario funcionario)
        {
            using (var contexto = new PostoContext())
            {
                contexto.Funcionarios.Update(funcionario);
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
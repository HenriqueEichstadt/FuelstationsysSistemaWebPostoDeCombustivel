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

        public void Deleta(int id)
        {
            using (var context = new PostoContext())
            {
                var fornecedor = new FornecedorDAO().BuscaPorId(id);
                context.Pessoas.Remove(fornecedor);
                var endereco = context.Enderecos.Find(fornecedor.EnderecoId);
                context.Enderecos.Remove(endereco);
                context.SaveChanges();
            }
        }

        public IList<Pessoa> ListaFornecedores(Pessoa pessoa)
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Pessoas.Where(f => f.TipoPessoa == 'J').ToList();
            }

        }

        public Pessoa BuscaPorId(int id)
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Pessoas.Include(p => p.Endereco).Where(p => p.Id == id).FirstOrDefault();
            }
        }

        public void Atualiza(Pessoa pessoa)
        {
            using (var contexto = new PostoContext())
            {
                contexto.Pessoas.Update(pessoa);
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
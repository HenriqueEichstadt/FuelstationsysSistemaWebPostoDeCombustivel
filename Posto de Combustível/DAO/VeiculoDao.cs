using Microsoft.EntityFrameworkCore;
using Posto_de_Combustível.DAO;
using Posto_de_Combustivel.Models;
using Posto_De_Combustivel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posto_de_Combustivel.DAO
{
    public class VeiculoDAO
    {
        public void Adiciona(Veiculo veiculo)
        {
            using (var context = new PostoContext())
            {
                context.Veiculos.Add(veiculo);
                context.SaveChanges();
            }
        }
        public IList<FabricanteVeiculo> ListaFabricantes(int tipoId)
        {
            using (var contexto = new PostoContext())
            {
                return contexto.FabricanteVeiculos
                    .Where(p => p.FabricanteVeiculoId == tipoId)
                    .ToList();
            }
        }

        public IList<FabricanteVeiculo> ListaTipoDeVeiculo()
        {
            using (var contexto = new PostoContext())
            {
                return contexto.FabricanteVeiculos
                    .Where(f => f.FabricanteVeiculoId == null)
                    .ToList();
            }
        }
        public IList<Veiculo> ListaVeiculos()
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Veiculos.ToList();
            }
        }

        public Veiculo BuscaPorPessoa(int id)
        {
            using (var contexto = new PostoContext())
            {
                return contexto.Veiculos.Where(v => v.PessoaId == id).FirstOrDefault();
            }
        }
    }
}
using Senai.AutoPecas.Api.Domains;
using Senai.AutoPecas.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.Api.Repositories
{
    public class PecaRepository : IPecaRepository
    {
        public Pecas Atualizar(Pecas peca, int id)
        {
            throw new NotImplementedException();
        }

        public Pecas BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Pecas peca)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Pecas.Add(peca);
                ctx.SaveChanges();
            }
        }

        public List<Pecas> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.ToList();
            }
        }
    }
}

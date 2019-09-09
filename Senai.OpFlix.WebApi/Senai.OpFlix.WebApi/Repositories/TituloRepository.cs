using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class TituloRepository : ITituloRepository
    {
        public void Atualizar(int id, Titulos titulo)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Titulos TituloBuscado = ctx.Titulos.FirstOrDefault(x => x.IdTitulo == id);

                TituloBuscado.Nome = titulo.Nome;
                ctx.Titulos.Update(TituloBuscado);
                ctx.SaveChanges();
            }
        }

        public Titulos BuscarPorId(int id)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Titulos.FirstOrDefault(x => x.IdTitulo == id);
            }
        }

        public void Cadastrar(Titulos titulo)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Titulos.Add(titulo);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Titulos TituloBuscado = ctx.Titulos.Find(id);
                ctx.Titulos.Remove(TituloBuscado);
                ctx.SaveChanges();
            }
        }

        public List<Titulos> Listar()
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Titulos.ToList();
            }
        }
    }
}

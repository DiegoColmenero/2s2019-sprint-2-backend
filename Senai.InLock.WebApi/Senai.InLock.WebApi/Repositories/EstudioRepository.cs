using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository
    {
        /// <summary>
        /// Lista Estudios
        /// </summary>
        /// <returns>Lista de estúdios</returns>
        public List<Estudios> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.ToList();
            }
        }

        /// <summary>
        /// Cadastra novo estúdio
        /// </summary>
        /// <param name="estudio"></param>
        public void Cadastrar(Estudios estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca estúdio por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>estudio</returns>
        public Estudios BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.FirstOrDefault(x => x.EstudioId == id);
            }
        }

        /// <summary>
        /// Atualiza Estúdio
        /// </summary>
        /// <param name="estudio"></param>
        public void Atualizar(Estudios estudio, int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Estudios EstudioBuscado = ctx.Estudios.FirstOrDefault(x => x.EstudioId == id);

                EstudioBuscado.NomeEstudio = estudio.NomeEstudio;
                ctx.Estudios.Update(EstudioBuscado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Deleta estúdio
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Estudios EstudioBuscado = ctx.Estudios.Find(id);
                ctx.Estudios.Remove(EstudioBuscado);
                ctx.SaveChanges();
            }
        }
    }
}

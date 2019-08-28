using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class DepartamentoRepository
    {
        public List<Departamentos> Listar()
        {
            using (EkipsContext context = new EkipsContext())
            {
                return context.Departamentos.ToList();
            }
        }

        public Departamentos BuscarPorId(int id)
        {
            using (EkipsContext context = new EkipsContext())
            {
                return context.Departamentos.FirstOrDefault(x => x.IdDepartamento == id);
                
            }
        }

        public void Cadastrar (Departamentos departamento)
        {
            using (EkipsContext context = new EkipsContext())
            {
                context.Departamentos.Add(departamento);
                context.SaveChanges();
            }
        }
    }
}

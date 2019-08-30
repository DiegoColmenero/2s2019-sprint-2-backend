using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class CargoRepository
    {
        public List<Cargos> Listar()
        {
            using (EkipsContext context = new EkipsContext())
            {
                return context.Cargos.ToList();
            }
        }

        public Cargos BuscarPorId(int id)
        {
            using (EkipsContext context = new EkipsContext())
            {
                return context.Cargos.FirstOrDefault(x => x.IdCargo == id);
            }
        }

        public void Cadastrar(Cargos cargo)
        {
            using (EkipsContext context = new EkipsContext())
            {
                context.Cargos.Add(cargo);
                context.SaveChanges();
            }
        }

        public void Atualizar(Cargos cargo, int id)
        {
            using (EkipsContext context = new EkipsContext())
            {
                Cargos cargoBuscado = context.Cargos.FirstOrDefault(x => x.IdCargo == id);
                cargoBuscado.Cargo = cargo.Cargo;
                cargoBuscado.Ativo = cargo.Ativo;
                context.Cargos.Update(cargoBuscado);
                context.SaveChanges();
            }
        }

        
    }
}

using Microsoft.EntityFrameworkCore;
using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        public List<Funcionarios> Listar()
        {
            using(EkipsContext context = new EkipsContext())
            {
                return context.Funcionarios.Include(x => x.IdDepartamentoNavigation).Include(x => x.IdCargoNavigation).Include(x => x.IdUsuarioNavigation).ToList();   
            }
        }

        public void Cadastrar (Funcionarios funcionario)
        {
            using (EkipsContext context = new EkipsContext())
            {
                context.Funcionarios.Add(funcionario);
                context.SaveChanges();
            }
        }
    }
}

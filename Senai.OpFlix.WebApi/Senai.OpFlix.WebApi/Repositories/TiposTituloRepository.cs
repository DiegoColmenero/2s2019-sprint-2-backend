using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class TiposTituloRepository : ITiposTituloRepository
    {
        public List<TiposTitulo> Listar()
        {
            using(OpFlixContext context = new OpFlixContext())
            {
                return context.TiposTitulo.ToList();
            }
        }
    }
}

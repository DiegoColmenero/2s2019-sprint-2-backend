using Senai.AutoPecas.Api.Domains;
using Senai.AutoPecas.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.Api.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        public List<Fornecedores> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Fornecedores.ToList();
            }
        }
    }
}

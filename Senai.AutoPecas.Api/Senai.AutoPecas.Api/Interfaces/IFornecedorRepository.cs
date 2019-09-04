using Senai.AutoPecas.Api.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.Api.Interfaces
{
    public interface IFornecedorRepository
    {
        List<Fornecedores> Listar();
    }
}

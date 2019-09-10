using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IProdutoraRepository
    {
        /// <summary>
        /// Método que lista todas as produtoras
        /// </summary>
        /// <returns>Lista de produtoras</returns>
        List<Produtoras> Listar();
    }
}

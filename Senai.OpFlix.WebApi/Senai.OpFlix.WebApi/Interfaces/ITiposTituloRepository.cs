using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface ITiposTituloRepository
    {
        /// <summary>
        /// Método que lista todos os tipos de titulos
        /// </summary>
        /// <returns>Lista de tipos de titulos</returns>
        List<TiposTitulo> Listar();
    }
}

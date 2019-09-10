using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface ICategoriaRepository
    {
        /// <summary>
        /// Método que lista todas as categorias
        /// </summary>
        /// <returns>Lista de categorias</returns>
        List<Categorias> Listar();

        /// <summary>
        /// Método que cadastra uma nova categoria caso seja um administradir
        /// </summary>
        /// <returns>Nova categoria</returns>
        void Cadastrar(Categorias categoria);

        /// <summary>
        /// Método que atualiza uma categoria caso seja um administrador
        /// </summary>
        /// <returns>Nova categoria</returns>
        void Atualizar(int id, Categorias categoria);
    }
}

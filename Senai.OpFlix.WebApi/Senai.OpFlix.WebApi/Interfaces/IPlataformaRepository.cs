using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IPlataformaRepository
    {
        /// <summary>
        /// Método que lista todas as plataformas
        /// </summary>
        /// <returns>Lista de plataformas</returns>
        List<Plataformas> Listar();

        /// <summary>
        /// Método que cadastra uma nova plataforma caso seja um administrador
        /// </summary>
        /// <returns>Nova plataforma</returns>
        void Cadastrar(Plataformas plataforma);

        /// <summary>
        /// Método que atualiza uma plataforma caso seja administrador
        /// </summary>
        /// <returns>Nova plataforma</returns>
        void Atualizar(int id, Plataformas plataforma);
    }
}

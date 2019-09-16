using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface ITituloRepository
    {
        /// <summary>
        /// Método que lista todos os titulos
        /// </summary>
        /// <returns>Lista de titulos</returns>
        List<TituloViewModel> Listar();

        /// <summary>
        /// Método que cadastra um novo titulo caso seja um administrador
        /// </summary>
        /// <returns>Novo titulo</returns>
        void Cadastrar(Titulos titulo);

        /// <summary>
        /// Método que atualiza um titulo da lista caso seja um administrador
        /// </summary>
        /// <returns>Novo titulo</returns>
        void Atualizar(int id, Titulos titulo);

        /// <summary>
        /// Método que busca um titulo na lista através de um id caso seja administrador
        /// </summary>
        /// <returns>Um único titulo</returns>
        Titulos BuscarPorId(int id);

        /// <summary>
        /// Método que deleta um titulo atraves de um id caso seja um administrador
        /// </summary>
        /// <returns>Deleta um titulo</returns>
        void Deletar(int id);

        /// <summary>
        /// Método que busca os títulos relacionados a uma determinada plataforma
        /// </summary>
        /// <returns>Titulos relacionados a determinada plataforma</returns>
        List<TituloViewModel> BuscarTituloPorPlataforma(string plataforma);

        List<TitulosEDiasViewModel> MostrarQuantosDiasFaltam();
    }
}

using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IFavoritoRepository
    {
        /// <summary>
        /// Método que lista os filmes favoritados
        /// </summary>
        /// <returns>Lista de filmes favoritos</returns>
        List<FavoritosViewModel> Listar();
    }
}

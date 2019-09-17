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
        /// Método que lista os filmes favoritados por determinado usuario
        /// </summary>
        /// <returns>Lista de filmes favoritos</returns>
        List<FavoritosViewModel> Listar(int id);


        /// <summary>
        /// Método que possibilita o usuario favoritar um titulo
        /// </summary>
        /// <returns>Um titulo favoritado</returns>
        void Favoritar(FavoritosViewModel favorito);
    }
}

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;
using Senai.OpFlix.WebApi.ViewModels;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritosController : ControllerBase
    {
        private IFavoritoRepository FavoritoRepository { get; set; }


        public FavoritosController()
        {
            FavoritoRepository = new FavoritoRepository();
        }


        /// <summary>
        /// Método que lista os titulos favoritados pelo usuário
        /// </summary>
        /// <returns>Lista de favoritos</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            int id = Convert.ToInt32(User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Jti).Value);
            return Ok(FavoritoRepository.Listar(id));
        }


        /// <summary>
        /// Método que possibilita um usuário favoritar um titulo
        /// </summary>
        /// <returns>Titulo favoritado</returns>
        [Authorize]
        [HttpPost("{tituloId}")]
        public IActionResult Favoritar(int tituloId)
        {
            FavoritosViewModel favorito = new FavoritosViewModel();
            try
            {
                favorito.UsuarioId = Convert.ToInt32(User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Jti).Value);
                favorito.TituloId = tituloId;
                FavoritoRepository.Favoritar(favorito);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
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
        /// Método que lista os titulos favoritados
        /// </summary>
        /// <returns>Lista de favoritos</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(FavoritoRepository.Listar());
        }
    }
}
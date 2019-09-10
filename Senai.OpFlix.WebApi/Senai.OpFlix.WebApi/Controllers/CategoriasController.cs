using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private ICategoriaRepository CategoriaRepository { get; set; }


        public CategoriasController()
        {
            CategoriaRepository = new CategoriaRepository();
        }


        /// <summary>
        /// Método que lista todas as categorias
        /// </summary>
        /// <returns>Lista de categorias</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CategoriaRepository.Listar());
        }


        /// <summary>
        /// Método que cadastra uma nova categoria caso seja um administradir
        /// </summary>
        /// <returns>Nova categoria</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            CategoriaRepository.Cadastrar(categoria);
            return Ok();
        }


        /// <summary>
        /// Método que atualiza uma categoria caso seja um administrador
        /// </summary>
        /// <returns>Nova categoria</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar (int id, Categorias categoria)
        {
            try
            {
                CategoriaRepository.Atualizar(id, categoria);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
            
        }
    }
}
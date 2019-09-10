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
using Senai.OpFlix.WebApi.ViewModels;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TitulosController : ControllerBase
    {
        private ITituloRepository TituloRepository { get; set; }


        public TitulosController()
        {
            TituloRepository = new TituloRepository();
        }


        /// <summary>
        /// Método que lista todos os titulos
        /// </summary>
        /// <returns>Lista de titulos</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(TituloRepository.Listar());
        }


        /// <summary>
        /// Método que busca um titulo na lista através de um id caso seja administrador
        /// </summary>
        /// <returns>Um único titulo</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(TituloRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Método que cadastra um novo titulo caso seja um administrador
        /// </summary>
        /// <returns>Novo titulo</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Titulos titulo)
        {
            TituloRepository.Cadastrar(titulo);
            return Ok();
        }


        /// <summary>
        /// Método que atualiza um titulo da lista caso seja um administrador
        /// </summary>
        /// <returns>Novo titulo</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Titulos titulo)
        {
            TituloRepository.Atualizar(id, titulo);
            return Ok();
        }


        /// <summary>
        /// Método que deleta um titulo atraves de um id caso seja um administrador
        /// </summary>
        /// <returns>Deleta um titulo</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            TituloRepository.Deletar(id);
            return Ok();
        }

        [Authorize]
        [HttpGet("{plataforma}/b")]
        public IActionResult BuscarTituloPorPlataforma(string plataforma)
        {
            return Ok(TituloRepository.BuscarTituloPorPlataforma(plataforma));
        }

    }
}
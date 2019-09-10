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
    public class PlataformasController : ControllerBase
    {
        private IPlataformaRepository PlataformaRepository { get; set; }


        public PlataformasController()
        {
            PlataformaRepository = new PlataformaRepository();
        }

        /// <summary>
        /// Método que lista todas as plataformas
        /// </summary>
        /// <returns>Lista de plataformas</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PlataformaRepository.Listar());
        }


        /// <summary>
        /// Método que cadastra uma nova plataforma caso seja um administrador
        /// </summary>
        /// <returns>Nova plataforma</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Plataformas plataforma)
        {
            PlataformaRepository.Cadastrar(plataforma);
            return Ok();
        }


        /// <summary>
        /// Método que atualiza uma plataforma caso seja administrador
        /// </summary>
        /// <returns>Nova plataforma</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Plataformas plataforma)
        {
            PlataformaRepository.Atualizar(id, plataforma);
            return Ok();
        }
            
    }
}
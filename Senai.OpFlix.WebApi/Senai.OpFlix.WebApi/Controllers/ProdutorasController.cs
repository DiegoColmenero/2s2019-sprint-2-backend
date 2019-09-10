using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutorasController : ControllerBase
    {
        private IProdutoraRepository ProdutoraRepository { get; set; }


        public ProdutorasController()
        {
            ProdutoraRepository = new ProdutoraRepository();
        }

        /// <summary>
        /// Método que lista todas as produtoras
        /// </summary>
        /// <returns>Lista de produtoras</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(ProdutoraRepository.Listar());
        }
    }
}
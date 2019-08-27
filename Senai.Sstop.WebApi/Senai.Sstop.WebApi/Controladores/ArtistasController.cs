using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Domains;
using Senai.Sstop.WebApi.Repositories;

namespace Senai.Sstop.WebApi.Controladores
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistasController : ControllerBase
    {
        ArtistaRepository artistaRepository = new ArtistaRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(artistaRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(ArtistaDomain artista)
        {



            try
            {
                artistaRepository.Cadastrar(artista);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Ocorreu um erro." + ex.Message });
            }

        }
    }
}
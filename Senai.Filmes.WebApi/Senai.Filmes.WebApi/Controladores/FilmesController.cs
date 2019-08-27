using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;
using Senai.Filmes.WebApi.Repositories;

namespace Senai.Filmes.WebApi.Controladores
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        FilmeRepository filmeRepository = new FilmeRepository();

        [HttpGet]
        public IEnumerable<Filmess> Listar()
        {
            return filmeRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Filmess filmes = filmeRepository.BuscarPorId(id);
            if (filmes == null)
            {
                return NotFound();
            }
            return Ok(filmes);
        }

        [HttpPost]
        public IActionResult Cadastrar(Filmess filmess)
        {



            try
            {
                filmeRepository.Cadastrar(filmess);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Ocorreu um erro." + ex.Message });
            }

        }
    }
}
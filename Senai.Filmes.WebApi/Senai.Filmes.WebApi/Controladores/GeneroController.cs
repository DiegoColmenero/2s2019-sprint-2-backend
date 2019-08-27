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
    public class GeneroController : ControllerBase
    {
        List<Generos> generos = new List<Generos>();

        GeneroRepository generoRepository = new GeneroRepository();

        
        [HttpGet]
        public IEnumerable<Generos> Listar()
        {
            return generoRepository.Listar();
        }//LISTA OS GÊNEROS

        [HttpPost]
        public IActionResult Cadastrar(Generos genero)
        {
            generoRepository.Cadastrar(genero);


            return Ok();
        }//CADASTRA UM GÊNERO

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            generoRepository.Deletar(id);
            return Ok();
        }//DELETA UN GÊNERO

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Generos genero)
        {
            generoRepository.Alterar(id, genero);
            return Ok();
        } //ALTERA UM GÊNERO

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Generos generos = generoRepository.BuscarPorId(id);
            if (generos == null)
            {
                return NotFound();
            }
            return Ok(generos);
        }
    }
}
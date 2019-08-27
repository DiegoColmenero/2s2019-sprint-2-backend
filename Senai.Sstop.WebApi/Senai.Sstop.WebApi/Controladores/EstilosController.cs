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
    public class EstilosController : ControllerBase
    {

        List<EstiloDomain> estilos = new List<EstiloDomain>()
            {
                new EstiloDomain { IdEstilo = 1, Nome = "Rock"},
                new EstiloDomain { IdEstilo = 2, Nome = "Pop" },
                new EstiloDomain { IdEstilo = 3, Nome = "Samba" },
                new EstiloDomain { IdEstilo = 4, Nome = "Indie" }
            };

        EstiloRepository estiloRepository = new EstiloRepository();


        [Produces("application/json")]
        [HttpGet]
        public IEnumerable<EstiloDomain> Listar()
        {

            return estiloRepository.Listar();
        }


        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            EstiloDomain Estilo = estiloRepository.BuscarPorId(id);
            if (Estilo == null)
            {
                return NotFound();
            }
            return Ok(Estilo);
        }


        [HttpPost]
        public IActionResult Cadastrar(EstiloDomain estiloDomain)
        {
            estiloRepository.Cadastrar(estiloDomain);

            return Ok();


        }


        [HttpPut]
        public IActionResult Alterar(EstiloDomain estilo)
        {
            estiloRepository.Alterar(estilo);
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            estiloRepository.Deletar(id);
            return Ok();
        }
    }
}
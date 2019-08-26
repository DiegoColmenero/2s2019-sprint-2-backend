using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        EstiloRepository estiloRepository = new EstiloRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(estiloRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Estilos estilo)
        {
            try
            {
                estiloRepository.Cadastrar(estilo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro" + ex.Message });

            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            estiloRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]
        [HttpPut]
        public IActionResult Atualizar(Estilos estilo)
        {
            try
            {
                Estilos estiloBuscado = estiloRepository.BuscarPorId(estilo.IdEstilo);
                if (estiloBuscado == null)
                    return NotFound();

                estiloRepository.Atualizar(estilo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok();

        }
    }
}
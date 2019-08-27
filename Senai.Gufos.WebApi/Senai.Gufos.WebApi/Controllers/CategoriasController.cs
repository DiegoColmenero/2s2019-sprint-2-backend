using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebApi.Domains;
using Senai.Gufos.WebApi.Repositories;

namespace Senai.Gufos.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        CategoriaRepository categoriaRepository = new CategoriaRepository();

       [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {

            return Ok(categoriaRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            try
            {
                categoriaRepository.Cadastrar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro" + ex.Message });

            }
        }
        [Authorize(Roles = "Admnistrador")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Categorias categoria = categoriaRepository.BuscarPorId(id);

            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            categoriaRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar (Categorias categoria)
        {
            try
            {
                Categorias categoriaBuscada = categoriaRepository.BuscarPorId(categoria.IdCategoria);
                if (categoriaBuscada == null)
                    return NotFound();

                categoriaRepository.Atualizar(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok();

        }

    }
}
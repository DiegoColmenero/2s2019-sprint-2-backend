using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        JogoRepository jogoRepository = new JogoRepository();

        /// <summary>
        /// Lista os Jogos
        /// </summary>
        /// <returns>Lista de Jogos</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {

                return Ok(jogoRepository.Listar());
                
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Jogo inexistente" + ex.Message });
            }
        }

        /// <summary>
        /// Cadastra Novo Jogo
        /// </summary>
        /// <param name="jogo"></param>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar (Jogos jogo)
        {
            try
            {

                jogoRepository.Cadastrar(jogo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro na digitação, confere aí!" + ex.Message });
            }
            
        }

        /// <summary>
        /// Busca um Jogo por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Jogo</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {

                return Ok(jogoRepository.BuscarPorId(id));
                
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Jogo inexistente" + ex.Message });
            }
            
        }

        /// <summary>
        /// Atualiza Jogo na Lista
        /// </summary>
        /// <param name="jogo"></param>
        /// <param name="id"></param>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(Jogos jogo, int id)
        {
            try
            {

                jogoRepository.Atualizar(jogo, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro na digitação, ou o jogo é inexistente confere aí!" + ex.Message });
            }
            
        }

        /// <summary>
        /// Deleta Jogo na Lista
        /// </summary>
        /// <param name="id"></param>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {

                jogoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Jogo inexistente" + ex.Message });
            }
        }
<<<<<<< HEAD

        /// <summary>
        /// Lista os Jogos mais caros
        /// </summary>
        /// <returns>Lista de Jogos</returns>
        [Authorize]
        [HttpGet("listarJogosMaisCaros")]
        public IActionResult ListarJogosMaisCaros()
        {
            try
            {

                return Ok(jogoRepository.ListarJogosMaisCaros());

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Jogo inexistente" + ex.Message });
            }
        }


        /// <summary>
        /// Busca um Jogo por Nome
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Jogo</returns>
   
        [HttpGet("nome/{nomeJogo}")]
        public IActionResult BuscarPorNome(string nomeJogo)
        {
            try
            {

                return Ok(jogoRepository.BuscarPorNome(nomeJogo));

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Jogo inexistente" + ex.Message });
            }

        }
=======
            
            [HttpGet]
            public IActionResult ListarJogosEEstudios()
            {
                return Ok(jogoRepository.ListarJogosEEstudios());
            }
>>>>>>> 3a35aca82002ff730593ed11bda163bb31e74c3d
    }
}
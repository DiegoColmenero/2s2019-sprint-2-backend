using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        EstudioRepository EstudioRepository = new EstudioRepository();
        
        /// <summary>
        /// Lista Estúdios
        /// </summary>
        /// <returns>Lista de Estúdio</returns>
        [Authorize]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {

                return Ok(EstudioRepository.Listar());
                
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro" + ex.Message });
            }
            
        }

        /// <summary>
        /// Cadastra Estúdio
        /// </summary>
        /// <param name="estudio"></param>
        /// <returns>Estúdio</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Estudios estudio)
        {
            try
            {
                // pega o id do token
                
                // id que voce pega do token
                estudio.DataCriacao = DateTime.Now;
                estudio.UsuarioId = Convert.ToInt32(User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Jti).Value);
               
                EstudioRepository.Cadastrar(estudio);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = "Oops... Tem erro aqui..." + ex.Message });
            }
        }

        /// <summary>
        /// Busca Estúdio por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Estúdio</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {

                return Ok(EstudioRepository.BuscarPorId(id));
                
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Estúdio inexistente" + ex.Message });
            }
            
        }

        /// <summary>
        /// Atualiza Estúdio na Lista
        /// </summary>
        /// <param name="estudio"></param>
        /// <param name="id"></param>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(Estudios estudio, int id)
        {
            try
            {

                EstudioRepository.Atualizar(estudio, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro na digitação, confere aí!" + ex.Message });
            }
            
            
        }

        /// <summary>
        /// Deleta Estúdio na lista
        /// </summary>
        /// <param name="id"></param>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {

                EstudioRepository.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Estúdio inexistente" + ex.Message });
            }
            
        }

    }
}
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
    public class UsuariosController : ControllerBase
    {
        UsuarioRepository usuarioRepository = new UsuarioRepository();


        /// <summary>
        /// Lista Usuários
        /// </summary>
        /// <returns>Lista De Usuários</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(usuarioRepository.Listar());
        }

        /// <summary>
        /// Cadastra Usuário
        /// </summary>
        /// <param name="usuario"></param>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            usuarioRepository.Cadastrar(usuario);
            return Ok();
        }

        /// <summary>
        /// Atualiza Usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public IActionResult Atualizar (Usuarios usuario, int id)
        {
            usuarioRepository.Atualizar(usuario, id);
            return Ok();
        }

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id"></param>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            usuarioRepository.Deletar(id);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId (int id)
        {
            return Ok(usuarioRepository.BuscarPorId(id));
        }
    }
}
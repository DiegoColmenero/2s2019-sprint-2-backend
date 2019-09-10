using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;
using Senai.OpFlix.WebApi.ViewModels;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }


        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Método que realiza o login do usuário
        /// </summary>
        /// <returns>Login</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuarios usuarioBuscado = UsuarioRepository.BuscarPorEmailSenha(login);
                if (usuarioBuscado == null)
                    return NotFound(new { mensagem = "Algo deu errado" });

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoDeUsuario),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("opflix-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "OpFlix.WebApi",
                    audience: "OpFlix.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }


        /// <summary>
        /// Método que lista todos os usuários caso seja um administrador
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(UsuarioRepository.Listar());
        }

        /// <summary>
        /// Método que cadastra um novo usuário, se não tiver logado
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Usuarios usuario)
        {

            string permissao;

            var identity = HttpContext.User.Identity as ClaimsIdentity;

            try
            {

                permissao = identity.FindFirst(ClaimTypes.Role).Value;
            }
            catch (Exception)
            {

                permissao = "manda o zap kk";
            }

            if (!permissao.Equals("ADMINISTRADOR"))
            {
                
                permissao = "CLIENTE";
                usuario.TipoDeUsuario = permissao;
                UsuarioRepository.Cadastrar(usuario);
                return Ok();
            }
            try
            {
                UsuarioRepository.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
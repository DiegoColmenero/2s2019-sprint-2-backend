using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.Api.Domains;
using Senai.AutoPecas.Api.Interfaces;
using Senai.AutoPecas.Api.Repositories;

namespace Senai.AutoPecas.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PecasController : ControllerBase
    {
        private IPecaRepository PecaRepository { get; set; }

        public PecasController()
        {
            PecaRepository = new PecaRepository();
        }

        Pecas peca = new Pecas();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PecaRepository.Listar());
        }


        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar()
        {
            try
            {
                int FornecedorId = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                peca.IdFornecedor = FornecedorId;
                PecaRepository.Cadastrar(peca);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}
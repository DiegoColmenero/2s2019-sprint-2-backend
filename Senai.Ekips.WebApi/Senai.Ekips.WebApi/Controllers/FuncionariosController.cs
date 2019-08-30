using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;


namespace Senai.Ekips.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
        //var identity = HttpContext.User.Identity as ClaimsIdentity;



        Usuarios usuarios = new Usuarios();
        Funcionarios funcionarios = new Funcionarios();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            // PEGAR O DADO DE PERMISSAO DO TOKEN
            if (identity != null)
            {
                string p = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
                // se for usuario
                if(p == "USUARIO")
                {
                    using (EkipsContext context = new EkipsContext())
                    {

                        context.Funcionarios.Where(x => x.IdUsuario == usuarios.IdUsuario);
                        

                        
                    }
                    
                }
                
                    

                
                    // lista somente os dados dele
                    // lembrar de pegar o id do token = where
                // caso contrario
                    // lista todos

            }
            return Ok(funcionarioRepository.Listar());


        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Funcionarios funcionario)
        {
            funcionarioRepository.Cadastrar(funcionario);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(Funcionarios funcionario, int id)
        {
            funcionarioRepository.Atualizar(funcionario, id);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            funcionarioRepository.Deletar(id);
            return Ok();
        }


    }
}
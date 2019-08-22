using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Models;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    

    public class FuncionariosController : ControllerBase
    {

        List<Funcionario> funcionarios = new List<Funcionario>();

        FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();


        [HttpGet]
        public IEnumerable<Funcionario> Listar()
        {
            return funcionarioRepositorio.Listar();
            
        } //Método que lista os funcionários

        [HttpPost]
        public IActionResult Inserir(Funcionario funcionario)
        {
            funcionarioRepositorio.Inserir(funcionario);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Funcionario funcionario = funcionarioRepositorio.BuscarPorId(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);

        }

        [HttpPut("{id}")]
        public IActionResult AlterarFuncionario(int id, Funcionario funcionario)
        {
            funcionarioRepositorio.AlterarFuncionario(id, funcionario);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFuncionario(int id)
        {
            funcionarioRepositorio.DeletarFuncionario(id);
            return Ok();
        }

        [HttpGet("buscar/{nome}")]
        public IActionResult Buscar(string nome)
        {
            Funcionario funcionario = funcionarioRepositorio.BuscarPorNome(nome);
            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);

        }

        [HttpGet("nomecompleto")]
        public IEnumerable<Funcionario> ListarNomeCompleto()
        {
            return funcionarioRepositorio.ListarNomeCompleto();

        }

        

        [HttpGet("ordenacao/{ordem}")]
        public IActionResult LitarPorOrdem(string ordem)
        {
            if(!ordem.Equals("asc") && !ordem.Equals("desc")) {
                return NotFound();
            }
            else
            {

            return Ok(funcionarioRepositorio.ListarPorOrdem(ordem));
            }

           

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CargosController : ControllerBase
    {
        CargoRepository cargoRepository = new CargoRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(cargoRepository.Listar());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(cargoRepository.BuscarPorId(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Cargos cargo)
        {
            cargoRepository.Cadastrar(cargo);
            return Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Atualizar (Cargos cargo, int id)
        {
            cargoRepository.Atualizar(cargo, id);
            return Ok();
        }
    }
}
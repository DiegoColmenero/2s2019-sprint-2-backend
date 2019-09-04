using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.Api.Interfaces;
using Senai.AutoPecas.Api.Repositories;

namespace Senai.AutoPecas.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private IFornecedorRepository FornecedorRepository { get; set; }


        public FornecedoresController()
        {
            FornecedorRepository = new FornecedorRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(FornecedorRepository.Listar());
        }

        
    }
}
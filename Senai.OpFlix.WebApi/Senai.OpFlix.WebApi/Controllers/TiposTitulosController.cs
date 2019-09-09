using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposTitulosController : ControllerBase
    {
        private ITiposTituloRepository TiposTituloRepository { get; set; }


        public TiposTitulosController()
        {
            TiposTituloRepository = new TiposTituloRepository();
        }
        


        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(TiposTituloRepository.Listar());
        }
    }
}
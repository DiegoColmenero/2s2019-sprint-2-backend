using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistasController : ControllerBase
    {
        ArtistaRepository artistaRepositoy = new ArtistaRepository();



        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(artistaRepositoy.Listar());
           

        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Artistas artista)
        {
            artistaRepositoy.Cadastrar(artista);
            return Ok();
        }
    }
}
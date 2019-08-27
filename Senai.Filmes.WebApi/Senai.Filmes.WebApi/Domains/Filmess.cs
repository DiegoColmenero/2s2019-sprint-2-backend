using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Domains
{
    public class Filmess
    {
        public int IdFilme { get; set; }
        public string Filme { get; set; }
        public int GeneroId { get; set; }
        public Generos Genero { get; set; }
    }
}

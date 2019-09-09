using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Categorias
    {
        public Categorias()
        {
            Titulos = new HashSet<Titulos>();
        }

        public int IdCategoria { get; set; }
        public string Categoria { get; set; }

        public ICollection<Titulos> Titulos { get; set; }
    }
}

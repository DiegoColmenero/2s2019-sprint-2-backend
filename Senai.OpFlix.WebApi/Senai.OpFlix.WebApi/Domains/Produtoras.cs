using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Produtoras
    {
        public Produtoras()
        {
            Titulos = new HashSet<Titulos>();
        }

        public int IdProdutora { get; set; }
        public string Produtora { get; set; }

        public ICollection<Titulos> Titulos { get; set; }
    }
}

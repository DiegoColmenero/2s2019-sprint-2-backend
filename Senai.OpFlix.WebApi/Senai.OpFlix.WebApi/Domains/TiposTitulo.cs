using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class TiposTitulo
    {
        public TiposTitulo()
        {
            Titulos = new HashSet<Titulos>();
        }

        public int IdTipoTitulo { get; set; }
        public string TipoTitulo { get; set; }

        public ICollection<Titulos> Titulos { get; set; }
    }
}

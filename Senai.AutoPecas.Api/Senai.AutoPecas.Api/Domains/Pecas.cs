using System;
using System.Collections.Generic;

namespace Senai.AutoPecas.Api.Domains
{
    public partial class Pecas
    {
        public int IdPeça { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public double? Peso { get; set; }
        public double? Preço { get; set; }
        public int? IdFornecedor { get; set; }

        public Fornecedores IdFornecedorNavigation { get; set; }
    }
}

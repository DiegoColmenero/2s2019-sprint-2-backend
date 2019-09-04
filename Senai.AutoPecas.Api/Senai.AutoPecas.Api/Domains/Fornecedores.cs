using System;
using System.Collections.Generic;

namespace Senai.AutoPecas.Api.Domains
{
    public partial class Fornecedores
    {
        public Fornecedores()
        {
            Pecas = new HashSet<Pecas>();
        }

        public int IdFornecedor { get; set; }
        public int Cnpj { get; set; }
        public string RazãoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereço { get; set; }
        public int? IdUsuario { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Pecas> Pecas { get; set; }
    }
}

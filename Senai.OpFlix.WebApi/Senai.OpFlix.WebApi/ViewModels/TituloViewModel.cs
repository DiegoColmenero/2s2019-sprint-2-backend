using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.ViewModels
{
    public class TituloViewModel
    {
        public int IdTitulo { get; set; }
        public string Nome { get; set; }
        public string Sinopse { get; set; }
        public int Duracao { get; set; }
        [Required (ErrorMessage = "Bota a data do filme doidao")]
        public DateTime DataLancamento { get; set; }
        public string Classificacao { get; set; }

        public string NomeCategoria { get; set; }
        public string NomePlataforma { get; set; }
        public string NomeProdutora { get; set; }
        public string NomeTipoTitulo { get; set; }

    }
}

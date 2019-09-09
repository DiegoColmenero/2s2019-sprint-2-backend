using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface ICategoriaRepository
    {
        List<Categorias> Listar();
        void Cadastrar(Categorias categoria);
        void Atualizar(int id, Categorias categoria);
    }
}

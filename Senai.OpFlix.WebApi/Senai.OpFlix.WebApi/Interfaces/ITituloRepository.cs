using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface ITituloRepository
    {
        List<Titulos> Listar();
        void Cadastrar(Titulos titulo);
        void Atualizar(int id, Titulos titulo);
        Titulos BuscarPorId(int id);
        void Deletar(int id);
    }
}

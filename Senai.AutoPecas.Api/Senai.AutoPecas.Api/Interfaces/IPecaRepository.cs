using Senai.AutoPecas.Api.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.Api.Interfaces
{
    public interface IPecaRepository
    {
        List<Pecas> Listar();
        void Cadastrar(Pecas peca);
        Pecas Atualizar(Pecas peca, int id);
        Pecas BuscarPorId(int id);
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    

    public class FuncionarioRepository
    {
        Funcionarios funcionarios = new Funcionarios();

        Usuarios usuarios = new Usuarios();

        public List<Funcionarios> Listar()
        {
            using(EkipsContext context = new EkipsContext())
            {               
                
                    return context.Funcionarios.Include(x => x.IdDepartamentoNavigation).Include(x => x.IdCargoNavigation).Include(x => x.IdUsuarioNavigation).ToList();
                                  
            }
        }

        public void Cadastrar (Funcionarios funcionario)
        {
            using (EkipsContext context = new EkipsContext())
            {
                context.Funcionarios.Add(funcionario);
                context.SaveChanges();
            }
        }

        public void Atualizar(Funcionarios funcionario, int id)
        {
            using (EkipsContext context = new EkipsContext())
            {
                Funcionarios funcionarioBuscado = context.Funcionarios.FirstOrDefault(x => x.IdFuncionario == id);
                funcionarioBuscado.Nome = funcionario.Nome;
                funcionarioBuscado.Cpf = funcionario.Cpf;
                funcionarioBuscado.Salario = funcionario.Salario;
                funcionarioBuscado.DataNascimento = funcionario.DataNascimento;
                funcionarioBuscado.IdCargo = funcionario.IdCargo;
                funcionarioBuscado.IdDepartamento = funcionario.IdDepartamento;
                funcionarioBuscado.IdUsuario = funcionario.IdUsuario;
                context.Funcionarios.Update(funcionarioBuscado);
                context.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionarios funcionarioBuscado = ctx.Funcionarios.Find(id);
                ctx.Funcionarios.Remove(funcionarioBuscado);
                ctx.SaveChanges();
            }
        }

        public Funcionarios BuscarPorUsuario(int idUsuario)
        {
            
                using (EkipsContext context = new EkipsContext())
                {
                    return context.Funcionarios.FirstOrDefault(x => x.IdUsuario == idUsuario);
                }
            
        }
    }
}

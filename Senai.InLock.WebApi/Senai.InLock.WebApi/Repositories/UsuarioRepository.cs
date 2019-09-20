using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Senai.InLock.WebApi.Repositories
{
    /// <summary>
    /// Busca Usuário por e-mail e senha - A ser chamado no login do Usuário
    /// </summary>
    public class UsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Usuarios UsuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (UsuarioBuscado == null)
                {
                    return null;
                }
                return UsuarioBuscado;
            }
        }


        /// <summary>
        /// Lista Usuários
        /// </summary>
        /// <returns>Listar</returns>
        public List<Usuarios> Listar()
        {
            using (InLockContext context = new InLockContext())
            {
                return context.Usuarios.ToList();

            }
        }

        /// <summary>
        /// Cadastra Novo Usuário
        /// </summary>
        /// <param name="usuario"></param>
        public void Cadastrar(Usuarios usuario)
        {
            using (InLockContext context = new InLockContext())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
        } 

        public void Atualizar (Usuarios usuario, int id)
        {
            using (InLockContext context = new InLockContext())
            {
                Usuarios usuarioBuscado = context.Usuarios.FirstOrDefault(x => x.UsuarioId == id);
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;
                usuarioBuscado.Permissao = usuario.Permissao;
                context.Usuarios.Update(usuarioBuscado);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deleta Usuário
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (InLockContext context = new InLockContext())
            {
                Usuarios usuarioBuscado = context.Usuarios.Find(id);
                context.Usuarios.Remove(usuarioBuscado);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Busca Usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Usuarios BuscarPorId(int id)
        {
            using (InLockContext context = new InLockContext())
            {
                return context.Usuarios.FirstOrDefault(x => x.UsuarioId == id);
            }
        } // Encontra um usuário por busca por id

    }
}

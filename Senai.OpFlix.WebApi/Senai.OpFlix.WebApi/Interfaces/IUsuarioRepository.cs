using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {

        /// <summary>
        /// Método que busca o email e a senha do usuario, verificando para realizar o login
        /// </summary>
        /// <returns>Login</returns>
        Usuarios BuscarPorEmailSenha(LoginViewModel login);

        /// <summary>
        /// Método que lista todos os usuários caso seja um administrador
        /// </summary>
        /// <returns>Lista de usuários</returns>
        List<Usuarios> Listar();


        void Cadastrar(Usuarios usuario);
    }
}

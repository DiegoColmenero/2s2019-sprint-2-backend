using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class LoginRepository
    {
        
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
            {
                using (EkipsContext context = new EkipsContext())
                {
                    Usuarios usuarioBuscado = context.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);

                    if (usuarioBuscado == null)
                    {
                        return null;
                    }
                    else
                    {
                        return usuarioBuscado;
                    }
                }
            }

        public List<Usuarios> Listar()
        {
            using (EkipsContext context = new EkipsContext())
            {
                return context.Usuarios.ToList();
                
            }
        }




    }
    
}

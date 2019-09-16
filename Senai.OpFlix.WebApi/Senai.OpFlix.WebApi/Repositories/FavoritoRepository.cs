using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class FavoritoRepository : IFavoritoRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_OpFlix; User Id=sa; Pwd=132";
        List<FavoritosViewModel> favoritos = new List<FavoritosViewModel>();


        public List<FavoritosViewModel> Listar()
        {
            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                string Query = "SELECT * FROM Favoritos";
                connection.Open();
                SqlDataReader sdr;


                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    sdr = command.ExecuteReader();

                    while (sdr.Read())
                    {
                         FavoritosViewModel favorito = new FavoritosViewModel
                        {
                            UsuarioId = Convert.ToInt32(sdr["IdUsuario"]),
                            TituloId = Convert.ToInt32(sdr["IdTitulo"])
                        };
                        favoritos.Add(favorito);
                    }
                }
                return favoritos;
            }
        }

    }
}

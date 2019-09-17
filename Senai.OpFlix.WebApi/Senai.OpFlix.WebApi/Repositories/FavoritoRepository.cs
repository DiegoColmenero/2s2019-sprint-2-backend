using Senai.OpFlix.WebApi.Domains;
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


        

        public void Favoritar(FavoritosViewModel favorito)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "insert into Favoritos (IdTitulo, IdUsuario) values(@IdTitulo,@IdUsuario);";

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdTitulo", favorito.TituloId);
                cmd.Parameters.AddWithValue("@IdUsuario", favorito.UsuarioId);
                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<FavoritosViewModel> Listar(int id)
        {
            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                string Query = "SELECT * FROM Favoritos where IdUsuario = @IdUsuario";
                connection.Open();
                SqlDataReader sdr;


                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario", id);
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

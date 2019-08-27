using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositories
{
    public class GeneroRepository
    {
        List<Generos> generos = new List<Generos>();
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_Filmes; User Id=sa; Pwd=132";

        public List<Generos> Listar()
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT  IdGenero, Genero FROM Generos ORDER BY IdGenero ASC";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Generos genero = new Generos
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Genero = rdr["Genero"].ToString()
                        };
                        generos.Add(genero);
                    }
                }
            }
            return generos;
        }//LISTA OS GÊNEROS

        public void Cadastrar(Generos genero)
        {
            string Query = "INSERT INTO Generos(Genero) VALUES(@Genero)";
            using (SqlConnection conection = new SqlConnection(StringConexao))
            {
                SqlCommand command = new SqlCommand(Query, conection);
                command.Parameters.AddWithValue("@Genero", genero.Genero);
                conection.Open();
                command.ExecuteNonQuery();


            }
        }//CADASTRA UM GÊNERO

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Generos WHERE IdGenero = @IdGenero";
            using (SqlConnection conection = new SqlConnection(StringConexao))
            {
                SqlCommand command = new SqlCommand(Query, conection);
                command.Parameters.AddWithValue("@IdGenero", id);
                conection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Alterar(int id, Generos genero)
        {
            string Query = "UPDATE Generos SET Genero = @Genero WHERE IdGenero = @IdGenero";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdGenero", id);
                cmd.Parameters.AddWithValue("@Genero", genero.Genero);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Generos BuscarPorId(int id)
        {
            string Query = "select Generos.IdGenero , Generos.Genero, Filmes.IdFilme, Filmes.Filme from Generos join Filmes on Generos.IdGenero = Filmes.IdGenero where Generos.IdGenero = @IdGenero";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Generos generos = new Generos
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Genero = sdr["Genero"].ToString(),
                                Filmes = new Filmess()
                                {
                                    IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                                    Filme = sdr["Filme"].ToString()
                                }

                            };
                            return generos;
                        }

                    }
                    return null;
                }
            }

        }
    }
}

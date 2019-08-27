using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositories
{
    public class FilmeRepository
    {
        

        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_Filmes; User Id=sa; Pwd=132";

        public List<Filmess> Listar()
        {
            List<Filmess> filmes = new List<Filmess>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "select Filmes.IdFilme, Filmes.Filme, Generos.IdGenero, Generos.Genero from Filmes join Generos on Filmes.IdGenero = Generos.IdGenero ";

                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Filmess filme = new Filmess
                        {
                            IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                            Filme = sdr["Filme"].ToString(),
                            Genero = new Generos()
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Genero = sdr["Genero"].ToString()
                            }

                        };
                        filmes.Add(filme);
                    }
                }
                return filmes;

            }



        }

        public Filmess  BuscarPorId(int id)
        {
            List<Filmess> filmes = new List<Filmess>();



            string Query = "select Filmes.IdFilme, Filmes.Filme, Generos.IdGenero, Generos.Genero from Filmes join Generos on Filmes.IdGenero = Generos.IdGenero where IdFilme = @IdFilme";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Filmess filme = new Filmess
                            {
                                IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                                Filme = sdr["Filme"].ToString(),
                                Genero = new Generos()
                                {
                                    IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                    Genero = sdr["Genero"].ToString()
                                }

                            };
                            return filme;
                        }

                    }
                    return null;
                }
            }
        }

        public void Cadastrar(Filmess filmess)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "insert into Filmes (Filme, IdGenero) values(@Filme, @IdGenero);";

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Filme", filmess.Filme);

                cmd.Parameters.AddWithValue("@IdGenero", filmess.GeneroId);
                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}

using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repositories
{
    public class ArtistaRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_SStop; User Id=sa; Pwd=132";

        public List<ArtistaDomain> Listar()
        {
            List<ArtistaDomain> artistas = new List<ArtistaDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "select Artistas.IdArtistas, Artistas.Nome, EstilosMusicais.Nome as Estilo, EstilosMusicais.IdEstilosMusicais from Artistas join EstilosMusicais on Artistas.IdEstilosMusicais = EstilosMusicais.IdEstilosMusicais ";

                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        ArtistaDomain artista = new ArtistaDomain
                        {
                            IdArtista = Convert.ToInt32(sdr["IdArtistas"]),
                            Nome = sdr["Nome"].ToString(),
                            Estilo = new EstiloDomain()
                            {
                                IdEstilo = Convert.ToInt32(sdr["IdEstilosMusicais"]),
                                Nome = sdr["Estilo"].ToString()
                            }

                        };
                        artistas.Add(artista);
                    }
                } return artistas;

            }
           


            }
        public void Cadastrar(ArtistaDomain artista)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "INSERT INTO Artistas (Nome, IdEstilosMusicais) VALUES (@Nome, @IdEstilosMusicais);";

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", artista.Nome);

                cmd.Parameters.AddWithValue("@IdEstilosMusicais", artista.EstiloId);
                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}

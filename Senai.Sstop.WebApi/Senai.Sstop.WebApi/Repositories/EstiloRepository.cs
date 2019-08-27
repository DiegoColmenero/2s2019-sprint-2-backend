using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repositories
{
    public class EstiloRepository
    {
        List<EstiloDomain> estilos = new List<EstiloDomain>()
            {
                new EstiloDomain { IdEstilo = 1, Nome = "Rock"},
                new EstiloDomain { IdEstilo = 2, Nome = "Pop" },
                new EstiloDomain { IdEstilo = 3, Nome = "Samba" },
                new EstiloDomain { IdEstilo = 4, Nome = "Indie" },
                new EstiloDomain { IdEstilo = 5, Nome = "Alternativo" }
            };

        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_SStop; User Id=sa; Pwd=132";

        public List<EstiloDomain> Listar()
        {
            List<EstiloDomain> estilos = new List<EstiloDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
                {
                string Query = "SELECT  IdEstilosMusicais, Nome  FROM EstilosMusicais ORDER BY IdEstilosMusicais ASC";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstiloDomain estilo = new EstiloDomain
                        {
                            IdEstilo = Convert.ToInt32(rdr["IdEstilosMusicais"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        estilos.Add(estilo);
                    }
                }
            }
                return estilos;
        }
        
        public EstiloDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdEstilosMusicais, Nome FROM EstilosMusicais WHERE IdEstilosMusicais = @IdEstilosMusicais";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstilosMusicais", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            EstiloDomain estilo = new EstiloDomain
                            {
                                IdEstilo = Convert.ToInt32(sdr["IdEstilosMusicais"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return estilo;
                        }
                           
                    }
                    return null;
                }
            }
           
        }
        
        public void Cadastrar(EstiloDomain estilo)
        {
            string Query = "INSERT INTO EstilosMusicais(Nome) VALUES(@Nome)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", estilo.Nome); 
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Alterar(EstiloDomain estilo)
        {
            string Query = "UPDATE EstilosMusicais SET Nome = @Nome WHERE IdEstilosMusicais = @IdEstilosMusicais";
             using(SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", estilo.Nome);
                cmd.Parameters.AddWithValue("@IdEstilosMusicais", estilo.IdEstilo);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM EstilosMusicais WHERE IdEstilosMusicais = @IdEstilosMusicais";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdEstilosMusicais", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

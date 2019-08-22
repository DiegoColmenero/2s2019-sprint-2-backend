using Senai.Peoples.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepositorio
    {
        List<Funcionario> funcionarios = new List<Funcionario>();

        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_Peoples; User Id=sa; Pwd=132";

        public List<Funcionario> Listar()
        {
            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                string Query = "SELECT * FROM Funcionarios ORDER BY IdFuncionario ASC";

                connection.Open();
                SqlDataReader rdr;

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        Funcionario funcionario = new Funcionario
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                           // DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        funcionarios.Add(funcionario);
                    }
                }

            }
            return funcionarios;
        }//Método que lista os funcionários

        public void Inserir(Funcionario funcionario)
        {
            string Query = "INSERT INTO Funcionarios (Nome, Sobrenome) VALUES (@Nome, @Sobrenome)";

            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@Nome", funcionario.Nome);
                command.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                connection.Open();
                command.ExecuteNonQuery();
            }

        } //Método que cadastra novos funcionários

        public Funcionario BuscarPorId(int id)
        {
            string Query = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE IdFuncionario = @IdFuncionario";

            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                connection.Open();
                SqlDataReader sdr;

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@IdFuncionario", id);
                    sdr = command.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Funcionario funcionario = new Funcionario
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                Nome = sdr["Nome"].ToString(),
                                Sobrenome = sdr["Sobrenome"].ToString()
                            };
                            return funcionario;
                        }

                    }
                    return null;

                }
            }
        } //Método que busca funcionário por Id

        public void AlterarFuncionario(int id, Funcionario funcionario)
        {
            string Query = "UPDATE Funcionarios SET Sobrenome = @Sobrenome WHERE IdFuncionario = @IdFuncionario";

            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@IdFuncionario", id);
                command.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                connection.Open();
                command.ExecuteNonQuery();
            }

        } //Método que altera funcionário por Id

        public void DeletarFuncionario(int id)
        {
            string Query = "DELETE FROM Funcionarios WHERE IdFuncionario = @IdFuncionario";

            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@IdFuncionario", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        } // Método que deleta funcionários (DEMITIDO)

        public Funcionario BuscarPorNome(string nome)
        {
            string Query = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE Nome = @Nome";

            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                connection.Open();
                SqlDataReader sdr;

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nome);
                    sdr = command.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Funcionario funcionario = new Funcionario
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                Nome = sdr["Nome"].ToString(),
                                Sobrenome = sdr["Sobrenome"].ToString()
                            };
                            return funcionario;
                        }

                    }
                    return null;

                }
            }
        } // Método que busca funcionário por Nome

        public List<Funcionario> ListarNomeCompleto()
        {
            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios ORDER BY IdFuncionario ASC";

                connection.Open();
                SqlDataReader rdr;

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        Funcionario funcionario = new Funcionario
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            NomeCompleto = rdr["Nome"].ToString() + " " + rdr["Sobrenome"].ToString(),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                            // DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        funcionarios.Add(funcionario);
                    }
                }

            }
            return funcionarios;
        } // Método que lista os funcionários com o Nome completo

        public List<Funcionario> ListarPorOrdem(string ordem)
        {
             using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios";
                

                if(ordem.Equals("asc"))
                {
                    Query = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios ORDER BY IdFuncionario ASC";

                  
                }
                    else if (ordem.Equals("desc"))
                    {
                        Query = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios ORDER BY IdFuncionario DESC";
                    }

                connection.Open();
                SqlDataReader rdr;

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        Funcionario funcionario = new Funcionario
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            NomeCompleto = rdr["Nome"].ToString() + " " + rdr["Sobrenome"].ToString(),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                            // DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        funcionarios.Add(funcionario);
                    }
                }

            }
            return funcionarios;
        }

    }
}

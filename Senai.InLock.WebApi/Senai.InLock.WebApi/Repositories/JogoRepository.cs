using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {

        private string StringConexao = "Data Source=localhost; initial catalog=M_InLock; Integrated Security=true";

        /// <summary>
        /// Lista os jogos
        /// </summary>
        /// <returns>Lista de Jogos</returns>
        public List<Jogos> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.ToList();
            }
        }

        /// <summary>
        /// Cadastra novo Jogo
        /// </summary>
        /// <param name="jogo"></param>
        public void Cadastrar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca Jogo por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>jogo</returns>
        public Jogos BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.FirstOrDefault(x => x.JogoId == id);
            }
        }

        /// <summary>
        /// Artualiza jogo
        /// </summary>
        /// <param name="jogo"></param>
        public void Atualizar(Jogos jogo, int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos JogoBuscado = ctx.Jogos.FirstOrDefault(x => x.JogoId == id);
                JogoBuscado.NomeJogo = jogo.NomeJogo;
                ctx.Update(JogoBuscado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Deleta Jogo
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos JogoBuscado = ctx.Jogos.Find(id);
                ctx.Jogos.Remove(JogoBuscado);
                ctx.SaveChanges();
            }
        }

<<<<<<< HEAD
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_InLock; User Id=sa; Pwd=132";

        List<Jogos> jogos = new List<Jogos>();

        /// <summary>
        /// Lista os Jogos mais caros
        /// </summary>
        /// <returns>Lista de Jogos</returns>
        /// 

            
        public List<Jogos> ListarJogosMaisCaros()
        {
            string Query = "select Jogos.JogoId, Jogos.NomeJogo, Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor, Estudios.NomeEstudio  from Estudios join Jogos on Jogos.EstudioId = Estudios.EstudioId order by Jogos.Valor desc";

           



                using (SqlConnection connection = new SqlConnection(StringConexao))
                {
                    connection.Open();
                    SqlDataReader sdr;

                    using (SqlCommand cmd = new SqlCommand(Query, connection))
                    {
                        sdr = cmd.ExecuteReader();

                        while (sdr.Read())
                        {
                            Jogos jogo = new Jogos
                            {
                                JogoId = Convert.ToInt32(sdr["JogoId"]),
                                NomeJogo = sdr["NomeJogo"].ToString(),
                                Descricao = sdr["Descricao"].ToString(),
                                DataLancamento = Convert.ToDateTime(sdr["DataLancamento"]),
                                Valor = Convert.ToInt32(sdr["Valor"]),

                                Estudio = new Estudios()
                                {
                                    NomeEstudio = sdr["NomeEstudio"].ToString()

                                }

                            };
                        
                            jogos.Add(jogo);
                        }
                    
                    return jogos;


                }
            }
        }



        public Jogos BuscarPorNome(string nomeJogo)
        {
            string Query = "select Jogos.JogoId, Jogos.NomeJogo, Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor, Estudio.EstudioId from Jogos where NomeJogo = @nomeJogo";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@nomeJogo", nomeJogo);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Jogos jogo = new Jogos
                            {
                                JogoId = Convert.ToInt32(sdr["JogoId"]),
                                NomeJogo = sdr["NomeJogo"].ToString(),
                                Descricao = sdr["Descricao"].ToString(),
                                DataLancamento = Convert.ToDateTime(sdr["NomeJogo"]),
                                Valor = Convert.ToInt32(sdr["NomeJogo"]),

                                Estudio = new Estudios()
                                {
                                   EstudioId = Convert.ToInt32(sdr["EstudioId"])

                                }
                            };
                            return jogo;
                        }

                    }
                    return null;
                }
            }
=======
        /// <summary>
        /// Lista os jogos com os respectivos Estudios
        /// </summary>
        /// <returns>Lista de Jogos</returns>
        public List<Jogos> ListarJogosEEstudios()
        {
            List<Jogos> jogos = new List<Jogos>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "select Jogos.JogoId, Jogos.NomeJogo, Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor, Estudios.NomeEstudio from Jogos join Estudios on Jogos.EstudioId = Estudios.EstudioId";

                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // executa a query
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Jogos jogo = new Jogos
                        {
                            JogoId = Convert.ToInt32(sdr["JogoId"]),
                            NomeJogo = sdr["Nome"].ToString(),
                            Estudio = new Estudios
                            {
                                EstudioId = Convert.ToInt32(sdr["EstudioId"]),
                                NomeEstudio = sdr["NomeEstudio"].ToString(),
                                DataCriacao = Convert.ToDateTime(sdr["DataCriacao"]),
                                PaisOrigem = sdr["PaisOrigem"].ToString()
                            }
                        };
                        jogos.Add(jogo);
                    }

                }
            }
            return jogos;
>>>>>>> 3a35aca82002ff730593ed11bda163bb31e74c3d

        }
    }
}

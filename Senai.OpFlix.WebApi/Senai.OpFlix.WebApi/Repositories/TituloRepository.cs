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
    public class TituloRepository : ITituloRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_OpFlix; User Id=sa; Pwd=132";
        public void Atualizar(int id, Titulos titulo)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Titulos TituloBuscado = ctx.Titulos.FirstOrDefault(x => x.IdTitulo == id);

                TituloBuscado.Nome = titulo.Nome;
                ctx.Titulos.Update(TituloBuscado);
                ctx.SaveChanges();
            }
        }

        public Titulos BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Titulos.FirstOrDefault(x => x.IdTitulo == id);
            }
        }

        public void Cadastrar(Titulos titulo)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Titulos.Add(titulo);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Titulos TituloBuscado = ctx.Titulos.Find(id);
                ctx.Titulos.Remove(TituloBuscado);
                ctx.SaveChanges();
            }
        }

        List<TituloViewModel> titulos = new List<TituloViewModel>();

        public List<TituloViewModel> Listar()
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = " select Titulos.IdTitulo, Titulos.Nome, Titulos.Sinopse, Titulos.Duracao," +
                               " Titulos.DataLancamento, TiposTitulo.TipoTitulo, Categorias.Categoria," +
                               " Plataformas.Plataforma, Produtoras.Produtora, Titulos.Classificacao" +
                               " from Titulos" +
                               " join TiposTitulo on Titulos.IdTipoTitulo = TiposTitulo.IdTipoTitulo" +
                               " join Categorias on Categorias.IdCategoria = Titulos.IdCategoria" +
                               " join Plataformas on Plataformas.IdPlataforma = Titulos.IdPlataforma" +
                               " join Produtoras ON Produtoras.IdProdutora = Titulos.IdProdutora ";


                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        TituloViewModel titulo = new TituloViewModel
                        {
                            IdTitulo = Convert.ToInt32(sdr["IdTitulo"]),
                            Nome = sdr["Nome"].ToString(),
                            Sinopse = sdr["Sinopse"].ToString(),
                            Duracao = Convert.ToInt32(sdr["Duracao"]),
                            DataLancamento = Convert.ToDateTime(sdr["DataLancamento"]),
                            Classificacao = sdr["Classificacao"].ToString(),


                            NomeCategoria = sdr["Categoria"].ToString(),

                            NomePlataforma = sdr["Plataforma"].ToString(),

                            NomeTipoTitulo = sdr["TipoTitulo"].ToString(),

                            NomeProdutora = sdr["Produtora"].ToString(),







                        };
                        titulos.Add(titulo);
                    }
                }
                return titulos;


            }
        }

        public List<TituloViewModel> BuscarTituloPorPlataforma(string plataforma)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "select Plataformas.Plataforma, Titulos.Nome from Plataformas join Titulos on Plataformas.IdPlataforma = Titulos.IdPlataforma where Plataformas.Plataforma = @Plataforma";

                List<TituloViewModel> plataformas = new List<TituloViewModel>();

                using (SqlConnection connection = new SqlConnection(StringConexao))
                {
                    connection.Open();
                    SqlDataReader sdr;

                    using (SqlCommand cmd = new SqlCommand(Query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Plataforma", plataforma);
                        sdr = cmd.ExecuteReader();

                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {
                                TituloViewModel titulo = new TituloViewModel
                                {

                                    Nome = sdr["Nome"].ToString(),

                                    NomePlataforma = sdr["Plataforma"].ToString(),

                                };
                                plataformas.Add(titulo);
                            }

                        }
                        return plataformas;




                    }
                }
            }
        }

        public List<TitulosEDiasViewModel> MostrarQuantosDiasFaltam()
        {
            List<TitulosEDiasViewModel> titulosEDiasLista = new List<TitulosEDiasViewModel>();
                using (SqlConnection connection = new SqlConnection(StringConexao))
                {
                    string Query = "EXEC  MostrarQuantosDiasFaltam";
                    connection.Open();
                    SqlDataReader sdr;


                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        sdr = command.ExecuteReader();

                        while (sdr.Read())
                        {
                        TitulosEDiasViewModel titulosEDias = new TitulosEDiasViewModel
                        {
                            Nome = sdr["Nome"].ToString(),
                            DiasRestantes = sdr["DiasRestantes"].ToString() + " dias"
                            
                            };

                        if (titulosEDias.DiasRestantes.Equals("0 dias"))
                        {
                            titulosEDias.DiasRestantes = "Este título ja foi lançado";
                        }
                            titulosEDiasLista.Add(titulosEDias);
                        }
                    }
                    return titulosEDiasLista;
                }

            }
        }
}


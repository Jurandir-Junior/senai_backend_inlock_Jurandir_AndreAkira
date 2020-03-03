using Senai.Inlock.WebApi.Domains;
using Senai.Inlock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source=localhost\\SQLEXPRESS; initial catalog=InLock_Games_Manha; integrated security=true;";
        //public string stringConexao = "Data Source=DEV701\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user Id=sa; pwd=sa@132";

        public void Atualizar(int id, JogoDomain jogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Jogos" +
                                     " SET NomeJogo = @NJ, Descricao = @D, Datalancamento = @DL, Valor = @V, IdEstudio = @IdE" +
                                     " WHERE IdJogos = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@NJ", jogoAtualizado.NomeJogo);
                    cmd.Parameters.AddWithValue("@D", jogoAtualizado.Descricao);
                    cmd.Parameters.AddWithValue("@DL", jogoAtualizado.DataLancamento);
                    cmd.Parameters.AddWithValue("@V", jogoAtualizado.Valor);
                    cmd.Parameters.AddWithValue("@IdE", jogoAtualizado.IdEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdJogos, NomeJogo, Descricao, DataLancamento, Valor, Jogos.IdEstudio, NomeEstudio FROM Jogos INNER JOIN Estudios ON Estudios.IdEstudio = Jogos.IdEstudio WHERE IdJogos = @ID ";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain
                        {
                            IdJogos = Convert.ToInt32(rdr["IdJogos"]),

                            NomeJogo = rdr["NomeJogo"].ToString(),

                            Descricao = rdr["Descricao"].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),

                            Valor = Convert.ToDouble(rdr["Valor"]),

                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                            Estudio = new EstudioDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                                NomeEstudio = rdr["NomeEstudio"].ToString()
                            }
                        };
                        return jogo;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Jogos(NomeJogo, Descricao, DataLancamento, Valor, IdEstudio) " +
                    " VALUES(@NJ, @D, @DL, @V,@IdE)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NJ", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@D", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DL", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@V", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@IdE", novoJogo.IdEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Jogos WHERE IdJogos = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> Listar()
        {
            List<JogoDomain> jogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdJogos, NomeJogo, Descricao, DataLancamento, Valor, Jogos.IdEstudio, NomeEstudio FROM Jogos " +
                    " INNER JOIN Estudios ON Estudios.IdEstudio = Jogos.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain
                        {
                            IdJogos = Convert.ToInt32(rdr["IdJogos"]),

                            NomeJogo = rdr["NomeJogo"].ToString(),

                            Descricao = rdr["Descricao"].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),

                            Valor = Convert.ToDouble(rdr["Valor"]),

                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                            Estudio = new EstudioDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                                NomeEstudio = rdr["NomeEstudio"].ToString()
                            }
                        };
                        jogos.Add(jogo);
                    }
                }
            }
            return jogos;
        }
    }
}

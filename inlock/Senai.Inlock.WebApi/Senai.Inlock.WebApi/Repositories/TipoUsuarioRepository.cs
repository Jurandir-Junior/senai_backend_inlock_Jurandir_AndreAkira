using Senai.Inlock.WebApi.Domains;
using Senai.Inlock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {

        //private string stringConexao = "Data Source=localhost\\SQLEXPRESS; initial catalog=InLock_Games_Manha; integrated security=true;";
        public string stringConexao = "Data Source=DEV701\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user Id=sa; pwd=sa@132";

        public void Atualizar(int id, TipoUsuarioDomain tipoUsuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE TipoUsuario SET Titulo = @Titulo WHERE IdTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Titulo", tipoUsuarioAtualizado.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public TipoUsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdTipoUsuario, Titulo FROM TipoUsuario WHERE IdTipoUsuario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                            Titulo = rdr["Titulo"].ToString()
                        };
                        return tipoUsuario;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(TipoUsuarioDomain novoTipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO TipoUsuario(Titulo) VALUES(@Titulo)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", novoTipoUsuario.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM TipoUsuario WHERE IdTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> tiposUsuario = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdTipoUsuario, Titulo FROM TipoUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                            Titulo = rdr["Titulo"].ToString()
                        };
                        tiposUsuario.Add(tipoUsuario);
                    }
                }
            }

            return tiposUsuario;
        }
    }
}

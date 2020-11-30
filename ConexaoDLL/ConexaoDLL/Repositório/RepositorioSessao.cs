using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace ConexaoDLL
{
    internal class RepositorioSessao
    {
        private Conexao _Conexao;
        public RepositorioSessao(Conexao conexao)
        {
            this._Conexao = conexao;
        }

        public string Cadastrar(Sessao sessao)
        {
            try
            {
                using (SqlConnection conexao = _Conexao.AbrirConexao())
                {
                    string cmd = $@"INSERT INTO Sessao(Id_Usuario,Chave) VALUES(@Id_Usuario,@Chave)";

                    using (SqlCommand comando = new SqlCommand(cmd, conexao))
                    {
                        comando.Parameters.Add(new SqlParameter("@Id_Usuario", sessao.Id_Usuario));
                        comando.Parameters.Add(new SqlParameter("@Chave", sessao.Chave));

                        comando.ExecuteNonQuery();
                        return sessao.Chave;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool Atualizar(Sessao sessao)
        {
            try
            {
                using (SqlConnection conexao = _Conexao.AbrirConexao())
                {
                    string cmd = $@"UPDATE Sessao SET DataConexao = GETDATE() WHERE Id = @Id";

                    using (SqlCommand comando = new SqlCommand(cmd, conexao))
                    {
                        comando.Parameters.Add(new SqlParameter("@Id", sessao.Id));

                        comando.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool Remover(Sessao sessao)
        {
            try
            {
                using (SqlConnection conexao = _Conexao.AbrirConexao())
                {
                    string cmd = $@"DELETE FROM Sessao WHERE Id = @Id";

                    using (SqlCommand comando = new SqlCommand(cmd, conexao))
                    {
                        comando.Parameters.Add(new SqlParameter("@Id", sessao.Id));

                        comando.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Sessao Consultar(Sessao sessao)
        {
            try
            {
                using (SqlConnection conexao = _Conexao.AbrirConexao())
                {
                    string cmd = $@"SELECT * FROM Sessao WHERE Chave = @Chave";

                    using (SqlCommand comando = new SqlCommand(cmd, conexao))
                    {
                        comando.Parameters.Add(new SqlParameter("@Chave", sessao.Chave));

                        using (SqlDataReader Data = comando.ExecuteReader())
                        {
                            while (Data.Read())
                            {
                                return new Sessao()
                                {
                                    Id = int.Parse(Data["Id"].ToString()),
                                    Id_Usuario = int.Parse(Data["Id_Usuario"].ToString()),
                                    Chave = Data["Chave"].ToString(),
                                    DataConexao = (DateTime) Data["DataConexao"]
                                };
                            }
                        }
                        throw new Exception("Nenhuma sessão encontrada com a chave informada");
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

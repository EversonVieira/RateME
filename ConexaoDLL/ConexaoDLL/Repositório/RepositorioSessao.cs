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

        public int Cadastrar(Sessao sessao)
        {
            try
            {
                using (SqlConnection conexao = _Conexao.AbrirConexao())
                {
                    string cmd = $@"INSERT INTO Sessao(Id_Usuario,Chave,DataConexao) VALUES(@Id_Usuario,@Chave,GETDATA()) SELECT SCOPE_IDENTITY()";

                    using (SqlCommand comando = new SqlCommand(cmd, conexao))
                    {
                        comando.Parameters.Add(new SqlParameter("@Id_Usuario", sessao.Id_Usuario));
                        comando.Parameters.Add(new SqlParameter("@Chave", sessao.Chave));
                        return (int)comando.ExecuteScalar();
                    }
                }
            }
            catch(Exception ex)
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
                                    Id = (int)Data["Id"],
                                    Id_Usuario = (int)Data["Id_Usuario"],
                                    Chave = Data["String"].ToString(),
                                    DataConexao = (DateTime)Data["DataConexao"]
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

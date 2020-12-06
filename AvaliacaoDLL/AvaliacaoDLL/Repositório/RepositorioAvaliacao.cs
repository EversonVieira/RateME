using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ConexaoDLL;
namespace AvaliacaoDLL
{
    internal class RepositorioAvaliacao
    {
        private Conexao _Conexao;

        public RepositorioAvaliacao(Conexao conexao)
        {
            this._Conexao = conexao;
        }

        public int Cadastrar(Avaliacao avaliacao)
        {
            try
            {
                using (SqlConnection conexao = _Conexao.AbrirConexao())
                {
                    string cmd = @"INSERT INTO AvaliacaoCatalogo(Id_Usuario,Id_Catalogo,Pontuacao) VALUES(@Id_Usuario,@Id_Catalogo,@Pontuacao) SELECT SCOPE_IDENTITY()";

                    using (SqlCommand comando = new SqlCommand(cmd, conexao))
                    {
                        comando.Parameters.Add(new SqlParameter("@Id_Usuario", avaliacao.Id_Usuario));
                        comando.Parameters.Add(new SqlParameter("@Id_Catalogo", avaliacao.Id_Catalogo));
                        comando.Parameters.Add(new SqlParameter("@Pontuacao", avaliacao.Pontuacao));

                        return int.Parse(comando.ExecuteScalar().ToString());
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

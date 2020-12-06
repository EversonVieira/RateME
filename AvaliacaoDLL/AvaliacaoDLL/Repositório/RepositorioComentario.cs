using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ConexaoDLL;

namespace AvaliacaoDLL
{
    internal class RepositorioComentario
    {
        private Conexao _Conexao;

        public RepositorioComentario(Conexao conexao)
        {
            this._Conexao = conexao;
        }

        public int Cadastrar(Comentario comentario)
        {
            try
            {
                using (SqlConnection conexao = _Conexao.AbrirConexao())
                {
                    string cmd = @"INSERT INTO Comentario(Id_Usuario,Id_Catalogo,Id_ComentarioRaiz,Texto) VALUES(@Id_Usuario,@Id_Catalogo,@Id_ComentarioRaiz,@Texto) SELECT SCOPE_IDENTITY()";

                    using (SqlCommand comando = new SqlCommand(cmd, conexao))
                    {
                        comando.Parameters.Add(new SqlParameter("@Id_Usuario", comentario.Id_Usuario));
                        comando.Parameters.Add(new SqlParameter("@Id_Catalogo", comentario.Id_Catalogo));
                        comando.Parameters.Add(new SqlParameter("@Id_ComentarioRaiz", comentario.Id_ComentarioRaiz > 0 ? comentario.Id_ComentarioRaiz.ToString() : DBNull.Value.ToString()));
                        comando.Parameters.Add(new SqlParameter("@Texto", comentario.Texto));


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

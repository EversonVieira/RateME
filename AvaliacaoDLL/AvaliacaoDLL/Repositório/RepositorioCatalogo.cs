using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ConexaoDLL;
namespace AvaliacaoDLL
{
    internal class RepositorioCatalogo
    {
        private Conexao _Conexao;

        public RepositorioCatalogo(Conexao conexao)
        {
            this._Conexao = conexao;
        }

        public List<Catalogo> Consultar()
        {
            try
            {
                List<Catalogo> ListaRetorno = new List<Catalogo>();
                using (SqlConnection conexao = _Conexao.AbrirConexao())
                {
                    string cmd = @"SELECT C.Id,c.Descricao,c.Titulo, ISNULL(AVG(AC.Pontuacao),0) as PontuacaoMedia, ISNULL(SUM(AC.Id),0) as TotalAvaliacoes FROM Catalogo C
LEFT JOIN AvaliacaoCatalogo AC on AC.Id_Catalogo = C.Id
GROUP BY C.Id,C.Descricao,C.Titulo";
                    
                    using (SqlCommand comando = new SqlCommand(cmd, conexao))
                    {
                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ListaRetorno.Add(new Catalogo()
                                {
                                    Id = int.Parse(dr["Id"].ToString()),
                                    Descricao = dr["Descricao"].ToString(),
                                    Titulo = dr["Titulo"].ToString(),
                                    PontuacaoMedia = int.Parse(dr["PontuacaoMedia"].ToString()),
                                    QntAvaliacoes = int.Parse(dr["TotalAvaliacoes"].ToString())
                                });
                            }
                        }
                    }

                    return ListaRetorno;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

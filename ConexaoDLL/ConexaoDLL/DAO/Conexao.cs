using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConexaoDLL
{
    public class Conexao
    {
        SqlConnection ConexaoSql = null;

        internal Conexao()
        {
            this.ConexaoSql = new SqlConnection();
            this.ConexaoSql.ConnectionString = ObterStringDeConexao();
        }
        public Conexao(string chave)
        {
            this.ConexaoSql = new SqlConnection();
            this.ConexaoSql.ConnectionString = ObterStringDeConexao();
        }
        private string ObterStringDeConexao()
        {
            SqlConnectionStringBuilder sqb = new SqlConnectionStringBuilder();
            sqb.InitialCatalog = "RateMe";
            sqb.DataSource = @"EVERSON\EVERSON";
            sqb.UserID = "RateMe";
            sqb.Password = "Admin";
            sqb.IntegratedSecurity = false;
            return sqb.ConnectionString;
        }

        public SqlConnection AbrirConexao()
        {
            try
            {
                if (this.ConexaoSql.State != System.Data.ConnectionState.Closed)
                {
                    throw new Exception("Conexão já está ativa de alguma forma.");
                }

                this.ConexaoSql.Open();
                return this.ConexaoSql;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConexaoDLL
{
    internal class RepositorioUsuario
    {
        private Conexao _Conexao;

        public RepositorioUsuario(Conexao conexao)
        {
            this._Conexao = conexao;
        }

        public int Cadastrar(Usuario usuario)
        {
            try
            {
                using (SqlConnection conexao = _Conexao.AbrirConexao())
                {
                    string cmd = $@"INSERT INTO Usuarios(Apelido,Email,Senha) VALUES(@Apelido,@Email,@Senha) SELECT SCOPE_IDENTITY()";
                   
                    using (SqlCommand comando = new SqlCommand(cmd, conexao))
                    {
                        comando.Parameters.Add(new SqlParameter("@Apelido",usuario.Apelido));
                        comando.Parameters.Add(new SqlParameter("@Email",usuario.Email));
                        comando.Parameters.Add(new SqlParameter("@Senha", usuario.Senha));

                        return int.Parse(comando.ExecuteScalar().ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public DTO_Usuario Consultar(Usuario usuario)
        {
            try
            {
                using (SqlConnection conexao = _Conexao.AbrirConexao())
                {
                    string cmd = $@"SELECT Id,Apelido,Email FROM Usuarios U WHERE U.Id = @Id";

                    using (SqlCommand comando = new SqlCommand(cmd, conexao))
                    {
                        comando.Parameters.Add(new SqlParameter("@Id", usuario.Id));

                        SqlDataReader Data = comando.ExecuteReader();
                        
                        while (Data.Read())
                        {
                            return new DTO_Usuario()
                            {
                                Id = int.Parse(Data["Id"].ToString()),
                                Apelido = Data["Apelido"].ToString(),
                                Email = Data["Email"].ToString()
                            };
                        }
                        throw new Exception("Nenhum usuário encontrado com o Id Fornecido");
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public Usuario Logar(Usuario usuario)
        {
            try
            {
                using (SqlConnection conexao = _Conexao.AbrirConexao())
                {
                    string cmd = $@"SELECT * FROM Usuarios U WHERE U.Email = @Email AND U.Senha = @Senha";

                    using (SqlCommand comando = new SqlCommand(cmd, conexao))
                    {
                        comando.Parameters.Add(new SqlParameter("@Email", usuario.Email));
                        comando.Parameters.Add(new SqlParameter("@Senha", usuario.Senha));

                        SqlDataReader Data = comando.ExecuteReader();

                        while (Data.Read())
                        {
                            return new Usuario()
                            {
                                Id = int.Parse(Data["Id"].ToString()),
                                Apelido = Data["Apelido"].ToString(),
                                Email = Data["Email"].ToString(),
                                Senha = Data["Senha"].ToString()
                            };
                        }
                        throw new Exception("Nenhum usuário encontrado com os dados fornecidos");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

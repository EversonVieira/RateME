using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ConexaoDLL
{
    public class RegraSessao
    {
        private Conexao _Conexao;
        private RegraUsuario _RegraUsuario;
        private RepositorioSessao _RepositorioSessao;

        public RegraSessao()
        {
            this._Conexao = new Conexao();
            this._RepositorioSessao = new RepositorioSessao(_Conexao);
            this._RegraUsuario = new RegraUsuario();
        }

        public string Cadastrar(int IdUsuario)
        {
            try
            {
                Sessao sessao = new Sessao()
                {
                    Id_Usuario = IdUsuario,
                    Chave = GerarChave(IdUsuario)
                };
                return _RepositorioSessao.Cadastrar(sessao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Consultar(string Chave)
        {
            try
            {
                Sessao sessao = new Sessao()
                {
                    Chave = Chave
                };
                sessao = _RepositorioSessao.Consultar(sessao);

                if (sessao.DataConexao.AddMinutes(15) < DateTime.Now)
                {
                    _RepositorioSessao.Remover(sessao);
                    throw new Exception("Sessão inválida, faça login novamente para continuar");
                }


                return sessao.Chave;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private string GerarChave(int IdUsuario)
        {
            try
            {
                using (SHA512 hash = SHA512.Create())
                {

                    StringBuilder sb = new StringBuilder();

                    sb.Append("LZXCv2123>(__|~");
                    sb.Append($"{IdUsuario}");
                    sb.Append($"{DateTime.Now}");
                    sb.Append("LZXCv2123>(__|~");

                    byte[] SessaoEmBytes = UTF8Encoding.UTF8.GetBytes(sb.ToString());

                    sb.Clear();

                    byte[] hashedString = hash.ComputeHash(SessaoEmBytes);

                    for(int i = 0; i < hashedString.Length; i++)
                    {
                        sb.Append(hashedString[i].ToString("X2"));
                    }
                    return sb.ToString();
                }


            }
            catch
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
namespace ConexaoDLL
{
    public class RegraUsuario
    {
        private Conexao _Conexao;
        private ValidadorUsuario _Validador;
        private readonly RepositorioUsuario _RepositorioUsuario;

        public RegraUsuario()
        {
            this._Conexao = new Conexao();
            this._RepositorioUsuario = new RepositorioUsuario(_Conexao);
            this._Validador = new ValidadorUsuario();
        }

        public int Cadastrar(Usuario usuario)
        {
            _Validador.ValidarUsuario(usuario);

            usuario.Senha = EncriptarSenha(usuario.Senha);
            return this._RepositorioUsuario.Cadastrar(usuario);
        }
        public DTO_Usuario Consultar(Usuario usuario)
        {
            return this._RepositorioUsuario.Consultar(usuario);
        }
        public Usuario Logar(Usuario usuario)
        {
            usuario.Senha = EncriptarSenha(usuario.Senha);

            return this._RepositorioUsuario.Logar(usuario);
        }
        private string EncriptarSenha(string senha)
        {
            byte[] senhaEmBytes = Encoding.UTF8.GetBytes(senha);

            using (SHA512 hash = SHA512.Create())
            {
                byte[] retornoEmBytes = hash.ComputeHash(senhaEmBytes);

                StringBuilder sb = new StringBuilder(128);
                for(int i = 0; i <retornoEmBytes.Length; i++)
                {
                    sb.Append(retornoEmBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }


    }
}

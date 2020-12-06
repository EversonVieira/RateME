using System;
using System.Collections.Generic;
using System.Text;
using ConexaoDLL;

namespace AvaliacaoDLL
{
    public class RegraComentario
    {
        private Conexao _Conexao;
        private RepositorioComentario _Repositorio;

        public RegraComentario(Conexao conexao)
        {
            this._Conexao = conexao;
            this._Repositorio = new RepositorioComentario(_Conexao);
        }

        public int Cadastrar(Comentario comentario)
        {
          return this._Repositorio.Cadastrar(comentario);
        }
    }
}

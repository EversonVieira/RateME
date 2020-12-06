using System;
using System.Collections.Generic;
using System.Text;
using ConexaoDLL;

namespace AvaliacaoDLL
{
    public class RegraAvaliacao
    {
        private Conexao _Conexao;
        private RepositorioAvaliacao _RepositorioAvaliacao;

        public RegraAvaliacao(Conexao conexao)
        {
            this._Conexao = conexao;
            this._RepositorioAvaliacao = new RepositorioAvaliacao(_Conexao);
        }

        public int Cadastrar(Avaliacao avaliacao)
        {
           return this._RepositorioAvaliacao.Cadastrar(avaliacao);
        }
    }
}

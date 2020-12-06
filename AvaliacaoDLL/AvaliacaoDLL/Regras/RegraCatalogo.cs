using System;
using System.Collections.Generic;
using System.Text;
using ConexaoDLL;

namespace AvaliacaoDLL
{
    public class RegraCatalogo
    {
        private Conexao _Conexao;
        private RepositorioCatalogo _Repositorio;

        public RegraCatalogo(Conexao conexao)
        {
            this._Conexao = conexao;
            this._Repositorio = new RepositorioCatalogo(_Conexao);
        }

        public List<Catalogo> Consultar()
        {
            return this._Repositorio.Consultar();
        }
    }
}

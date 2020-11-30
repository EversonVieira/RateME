using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConexaoDLL;
using System.Data.SqlClient;

namespace RateME.Controllers
{
    [Route("api")]
    [ApiController]
    public class ConexaoController : ControllerBase
    {
        private RegraUsuario _RegraUsuario;
        private RegraSessao _RegraSessao;
        public ConexaoController()
        {
            this._RegraUsuario = new RegraUsuario();
            this._RegraSessao = new RegraSessao();
        }
        [HttpPost]
        [Route("usuario/cadastrar")]
        public ActionResult<string> Cadastrar(Usuario usuario)
        {
            int idUsuario = this._RegraUsuario.Cadastrar(usuario);

            return _RegraSessao.Cadastrar(idUsuario);
        }
        [HttpPost]
        [Route("usuario/logar")]
        public ActionResult<string> Logar(Usuario usuario)
        {
            usuario = _RegraUsuario.Logar(usuario);

            return _RegraSessao.Cadastrar(usuario.Id);
        }
        [HttpGet]
        [Route("teste/sessao/{chave}")]
        public ActionResult<string> ValidarSessao(string chave)
        {
            return _RegraSessao.Consultar(chave);
        }
    }
}

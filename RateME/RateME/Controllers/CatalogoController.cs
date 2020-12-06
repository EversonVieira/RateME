using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConexaoDLL;
using AvaliacaoDLL;
namespace RateME.Controllers
{
    [Route("api/catalogo")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private Conexao _Conexao;
        private  RegraAvaliacao _RegraAvaliacao;
        private  RegraComentario _RegraComentario;
        private  RegraCatalogo _RegraCatalogo;

        [HttpGet]
        [Route("consultar")]
        public ActionResult<List<Catalogo>> ConsultarCatalogo()
        {
            try
            {
                string Chave = HttpContext.Request?.Headers["Session"];
                _Conexao = new Conexao(Chave);
                this._RegraAvaliacao = new RegraAvaliacao(_Conexao);
                this._RegraCatalogo = new RegraCatalogo(_Conexao);
                this._RegraComentario = new RegraComentario(_Conexao);
                return Ok(this._RegraCatalogo.Consultar());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("comentario/cadastrar")]
        public ActionResult<int> CadastrarComentario(Comentario comentario)
        {
            try
            {
                string Chave = HttpContext.Request?.Headers["Session"];
                _Conexao = new Conexao(Chave);
                this._RegraComentario = new RegraComentario(_Conexao);

                return Ok(this._RegraComentario.Cadastrar(comentario));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("avaliacao/cadastrar")]
        public ActionResult<int> CadastrarAvaliacao(Avaliacao avaliacao)
        {
            try
            {
                string Chave = HttpContext.Request?.Headers["Session"];
                _Conexao = new Conexao(Chave);
                this._RegraAvaliacao = new RegraAvaliacao(_Conexao);

                return Ok(this._RegraAvaliacao.Cadastrar(avaliacao));
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}

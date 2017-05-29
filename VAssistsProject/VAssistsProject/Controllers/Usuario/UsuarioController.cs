using System.Web.Http;
using System.Web.Http.Description;
using VAssists.AppService.Usuarios.Interfaces;
using VAssists.DataTransfer.Usuarios.requests;
using VAssists.DataTransfer.Usuarios.responses;

namespace VAssistsProject.Controllers.Usuario
{
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioAppServico usuarioAppServico;

        public UsuarioController(IUsuarioAppServico usuarioAppServico)
        {
            this.usuarioAppServico = usuarioAppServico;
        }

        [HttpGet]
        [Route("api/usuario/{codigoUsuario:int}")]
        [ResponseType(typeof(UsuarioResponse))]
        public IHttpActionResult RetornaUsuario([FromUri] int codigoUsuario)
        {
            return Ok(usuarioAppServico.RetornaUsuario(codigoUsuario));
        }

        [HttpPut]
        [Route("api/usuario/{codigoUsuario:int}")]
        [ResponseType(typeof(UsuarioResponse))]
        public IHttpActionResult AlterarUsuario([FromUri] int codigoUsuario, [FromBody] AlterarUsuarioRequest request)
        {
            usuarioAppServico.AlterarUsuario(codigoUsuario, request);
            return Ok();
        }

        [HttpPatch]
        [Route("api/usuario/{codigoUsuario:int}/senha")]
        public IHttpActionResult ResetarSenha([FromUri] int codigoUsuario)
        {
            usuarioAppServico.ResetarSenha(codigoUsuario);
            return Ok();
        }

        [HttpGet]
        [Route("api/usuario")]
        [ResponseType(typeof(UsuarioComPaginacaoResponse))]
        public IHttpActionResult ListarUsuarios([FromUri] ListarUsuariosRequest request)
        {
            return Ok(usuarioAppServico.ListarUsuarios(request));
        }

        [HttpDelete]
        [Route("api/usuario/{codigoUsuario:int}")]
        public IHttpActionResult ExcluirUsuario([FromUri] int codigoUsuario)
        {
            usuarioAppServico.ExcluirUsuario(codigoUsuario);
            return Ok();
        }

        [HttpPut]
        [Route("api/usuario/{codigoUsuario:int}/senha")]
        public IHttpActionResult AlterarSenha([FromUri] int codigoUsuario, [FromBody] AlterarSenhaRequest request)
        {
            usuarioAppServico.AlterarSenha(codigoUsuario, request);
            return Ok();
        }

        [HttpPost]
        [Route("api/usuario")]
        [ResponseType(typeof(UsuarioResponse))]
        public IHttpActionResult CadastrarUsuario([FromBody] CadastrarUsuariosRequest request)
        {
            usuarioAppServico.CadastrarUsuario(request);
            return Ok();
        }
    }
}
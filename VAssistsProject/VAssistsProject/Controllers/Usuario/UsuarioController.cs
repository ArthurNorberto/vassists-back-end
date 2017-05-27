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

        [HttpGet]
        [Route("api/usuario")]
        [ResponseType(typeof(UsuarioComPaginacaoResponse))]
        public IHttpActionResult ListarUsuarios([FromUri] ListarUsuariosRequest request)
        {
            return Ok(usuarioAppServico.ListarUsuarios(request));
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
using System.Web.Http;
using System.Web.Http.Description;
using VAssists.AppService.Seguranca.Interfaces;
using VAssists.DataTransfer.Seguranca.requests;
using VAssists.DataTransfer.Seguranca.responses;

namespace VAssistsProject.Controllers
{
    public class LoginController : ApiController
    {
        private readonly ISegurancaAppServico segurancaAppServico;

        public LoginController() : base()
        {
            
        }

        public LoginController(ISegurancaAppServico segurancaAppServico)
        {
            this.segurancaAppServico = segurancaAppServico;
        }

        [HttpPost]
        [Route("api/seguranca/login")]
        [ResponseType(typeof(UsuarioLogadoResponse))]
        public IHttpActionResult LogarNoSistema([FromUri] LoginSistemaRequest request)
        {
            return Ok(segurancaAppServico.LogarNoSistema(request));
        }
    }
}
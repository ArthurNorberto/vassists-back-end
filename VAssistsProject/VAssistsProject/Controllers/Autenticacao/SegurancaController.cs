using System.Web.Http;
using VAssists.AppService.Seguranca.Interfaces;
using VAssists.DataTransfer.Seguranca.requests;

namespace VAssistsProject.Controllers.Autenticacao
{
    public class SegurancaController : ApiController
    {
        private readonly ISegurancaAppServico segurancaAppServico;

        /// <summary>
        ///
        /// </summary>
        /// <param name="segurancaAppServico"></param>
        public SegurancaController(ISegurancaAppServico segurancaAppServico)
        {
            this.segurancaAppServico = segurancaAppServico;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/seguranca/cadastro")]
        public IHttpActionResult CadastroSistema([FromBody] CadastroUsuarioRequest request)
        {
            segurancaAppServico.CadastroSistema(request);
            return Ok();
        }
    }
}
using System.Web.Http;
using System.Web.Http.Description;
using VAssists.AppService.Estatisticas.interfaces;
using VAssists.AppService.Mensagens.interfaces;
using VAssists.AppService.Pontos.Interfaces;
using VAssists.DataTransfer.Mensagens.requests;
using VAssists.DataTransfer.Mensagens.responses;
using VAssists.DataTransfer.Pontos.requests;
using VAssists.DataTransfer.Pontos.responses;

namespace VAssistsProject.Controllers.Mensagens
{
    public class MensagensController : ApiController
    {
        private readonly IMensagensAppServico mensagensAppServico;

        public MensagensController(IMensagensAppServico mensagensAppServico)
        {
            this.mensagensAppServico = mensagensAppServico;
        }

        [HttpGet]
        [Route("api/mensagem")]
        [ResponseType(typeof(MensagensPaginacaoResponse))]
        public IHttpActionResult ListarMensagens([FromUri] ListarMensagensRequest request)
        {
            return Ok(mensagensAppServico.ListarMensagens(request));
        }

        [HttpPost]
        [Route("api/mensagem")]
        [ResponseType(typeof(MensagensPaginacaoResponse))]
        public IHttpActionResult InserirMensagem([FromBody] InserirMensagemRequest request)
        {
            mensagensAppServico.InserirMensagem(request);
            return Ok();
        }

        [HttpDelete]
        [Route("api/mensagem/{codigoMensagem:int}")]
        [ResponseType(typeof(MensagensPaginacaoResponse))]
        public IHttpActionResult DeletarMensagem([FromUri] int codigoMensagem)
        {
            mensagensAppServico.DeletarMensagem(codigoMensagem);
            return Ok();
        }


    }
}
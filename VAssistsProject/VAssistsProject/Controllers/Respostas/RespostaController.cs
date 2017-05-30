using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using VAssists.AppService.Respostas.Interfaces;
using VAssists.DataTransfer.Respostas.requests;
using VAssists.DataTransfer.Respostas.responses;

namespace VAssistsProject.Controllers.Respostas
{
    public class RespostaController : ApiController
    {
        private readonly IRespostaAppServico respostaAppServico;

        public RespostaController(IRespostaAppServico respostaAppServico)
        {
            this.respostaAppServico = respostaAppServico;
        }

        [HttpGet]
        [Route("api/ponto/{codigoPonto:int}/resposta")]
        [ResponseType(typeof(IEnumerable<RespostaResponse>))]
        public IHttpActionResult ListarRespostas([FromUri] int codigoPonto)
        {
            return Ok(respostaAppServico.ListarRespostas(codigoPonto));
        }

        [HttpPost]
        [Route("api/ponto/{codigoPonto:int}/resposta")]
        public IHttpActionResult InserirResposta([FromUri] int codigoPonto, [FromBody] InserirRespostaRequest request)
        {
            respostaAppServico.InserirResposta(codigoPonto, request);
            return Ok();
        }
    }
}
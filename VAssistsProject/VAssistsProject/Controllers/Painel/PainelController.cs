using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using VAssists.AppService.Painel.Interfaces;
using VAssists.DataTransfer.Painel.requests;
using VAssists.DataTransfer.Painel.responses;

namespace VAssistsProject.Controllers.Painel
{

    public class PainelController : ApiController
    {
        private readonly IPainelAppServico painelAppServico;


        public PainelController(IPainelAppServico painelAppServico)
        {
            this.painelAppServico = painelAppServico;
        }


        [HttpGet]
        [Route("api/perfil")]
        [ResponseType(typeof(IEnumerable<PerfilResponse>))]
        public IHttpActionResult ListarPerfil()
        {
            return Ok(painelAppServico.ListarPerfil());
        }

        [HttpGet]
        [Route("api/perfil/{codigoPerfil:int}")]
        [ResponseType(typeof(PerfilResponse))]
        public IHttpActionResult RetornarPerfil([FromUri]int codigoPerfil)
        {
            return Ok(painelAppServico.RetornarPerfil(codigoPerfil));
        }


        [HttpPost]
        [Route("api/perfil")]
        public IHttpActionResult InserirPerfil([FromBody] InserirPerfilRequest request)
        {
            painelAppServico.InserirPerfil(request);
            return Ok();
        }

        [HttpPut]
        [Route("api/perfil/{codigoPerfil:int}")]
        public IHttpActionResult AlterarPerfil([FromUri]int codigoPerfil, [FromBody] AlterarPerfilRequest request)
        {
            painelAppServico.AlterarPerfil(codigoPerfil, request);
            return Ok();
        }

        [HttpDelete]
        [Route("api/perfil/{codigoPerfil:int}")]
        public IHttpActionResult DeletarPerfil([FromUri]int codigoPerfil)
        {
            painelAppServico.DeletarPerfil(codigoPerfil);
            return Ok();
        }


        [HttpGet]
        [Route("api/tipo")]
        [ResponseType(typeof(IEnumerable<TipoResponse>))]
        public IHttpActionResult ListarTipo()
        {
            return Ok(painelAppServico.ListarTipo());
        }


        [HttpGet]
        [Route("api/perfil/{codigoTipo:int}")]
        [ResponseType(typeof(PerfilResponse))]
        public IHttpActionResult RetornarTipo([FromUri]int codigoTipo)
        {
            return Ok(painelAppServico.RetornarTipo(codigoTipo));
        }


        [HttpPost]
        [Route("api/tipo")]
        public IHttpActionResult InserirTipo([FromBody] InserirTipoRequest request)
        {
            painelAppServico.InserirTipo(request);
            return Ok();
        }

        [HttpPut]
        [Route("api/perfil/{codigoTipo:int}")]
        public IHttpActionResult AlterarTipo([FromUri]int codigoTipo, [FromBody] AlterarTipoRequest request)
        {
            painelAppServico.AlterarTipo(codigoTipo, request);
            return Ok();
        }

        [HttpDelete]
        [Route("api/perfil/{codigoTipo:int}")]
        public IHttpActionResult DeletarTipo([FromUri]int codigoTipo)
        {
            painelAppServico.DeletarTipo(codigoTipo);
            return Ok();
        }

    }
}
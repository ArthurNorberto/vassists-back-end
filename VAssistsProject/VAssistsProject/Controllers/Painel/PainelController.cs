using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VAssists.AppService.Painel.Interfaces;
using VAssists.DataTransfer.Painel.requests;
using VAssists.DataTransfer.Painel.responses;

namespace VAssistsProject.Controllers.Painel
{
    /// <summary>
    /// 
    /// </summary>
    public class PainelController : ApiController
    {
        private readonly IPainelAppServico painelAppServico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="painelAppServico"></param>
        public PainelController(IPainelAppServico painelAppServico)
        {
            this.painelAppServico = painelAppServico;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/perfil")]
        [ResponseType(typeof(IEnumerable<PerfilResponse>))]
        public IHttpActionResult ListarPerfil()
        {
            return Ok(painelAppServico.ListarPerfil());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/perfil")]
        public IHttpActionResult InserirPerfil([FromBody] InserirPainelRequest request)
        {
            painelAppServico.InserirPerfil(request);
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/tipo")]
        [ResponseType(typeof(IEnumerable<TipoResponse>))]
        public IHttpActionResult ListarTipo()
        {
            return Ok(painelAppServico.ListarTipo());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/tipo")]
        public IHttpActionResult InserirTipo([FromBody] InserirTipoRequest request)
        {
            painelAppServico.InserirTipo(request);
            return Ok();
        }



    }
}

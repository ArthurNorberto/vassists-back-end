using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VAssists.AppService.Painel.Interfaces;
using VAssists.DataTransfer.Painel.responses;

namespace VAssistsProject.Controllers.Painel
{
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


        [HttpGet]
        [Route("api/perfil")]
        [ResponseType(typeof(IEnumerable<PerfilResponse>))]
        public IHttpActionResult ListarPerfil()
        {
            return Ok(painelAppServico.ListarPerfil());
        }
    }
}

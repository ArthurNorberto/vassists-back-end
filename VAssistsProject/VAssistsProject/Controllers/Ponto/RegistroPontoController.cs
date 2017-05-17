using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VAssists.AppService.Pontos.Interfaces;
using VAssists.DataTransfer.Pontos.requests;
using VAssists.DataTransfer.Pontos.responses;

namespace VAssistsProject.Controllers.Ponto
{
    public class RegistroPontoController : ApiController
    {
        private readonly IRegistroPontoAppServico registroPontoAppServico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registroPontoAppServico"></param>
        public RegistroPontoController(IRegistroPontoAppServico registroPontoAppServico)
        {
            this.registroPontoAppServico = registroPontoAppServico;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoPonto"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ponto/{codigoPonto:int}")]
        [ResponseType(typeof(PontoResponse))]
        public IHttpActionResult RetornarPonto([FromUri] int codigoPonto)
        {
            return Ok(registroPontoAppServico.RetornarPonto(codigoPonto));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/ponto")]
        public IHttpActionResult RegistrarPonto([FromBody] RegistrarPontoRequest request)
        {
            registroPontoAppServico.RegistrarPonto(request);
            return Ok();
        }
    }
}

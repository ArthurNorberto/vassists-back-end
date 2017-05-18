﻿using System.Web.Http;
using System.Web.Http.Description;
using VAssists.AppService.Seguranca.Interfaces;
using VAssists.DataTransfer.Seguranca.requests;
using VAssists.DataTransfer.Seguranca.responses;

namespace VAssistsProject.Controllers
{
    /// <summary>
    ///
    /// </summary>
    public class LoginController : ApiController
    {
        private readonly ISegurancaAppServico segurancaAppServico;

        /// <summary>
        ///
        /// </summary>
        /// <param name="segurancaAppServico"></param>
        public LoginController(ISegurancaAppServico segurancaAppServico)
        {
            this.segurancaAppServico = segurancaAppServico;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/seguranca/login")]
        [ResponseType(typeof(UsuarioLogadoResponse))]
        public IHttpActionResult LogarNoSistema([FromBody] LoginSistemaRequest request)
        {
            return Ok(segurancaAppServico.LogarNoSistema(request));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="codigoUsuario"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/seguranca/login")]
        public IHttpActionResult DeslogarNoSistema([FromBody] int codigoUsuario)
        {
            segurancaAppServico.DeslogarNoSistema(codigoUsuario);
            return Ok();
        }
    }
}
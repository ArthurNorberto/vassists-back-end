﻿using System.Collections.Generic;
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

        public RegistroPontoController(IRegistroPontoAppServico registroPontoAppServico)
        {
            this.registroPontoAppServico = registroPontoAppServico;
        }

        [HttpGet]
        [Route("api/ponto/{codigoPonto:int}")]
        [ResponseType(typeof(PontoResponse))]
        public IHttpActionResult RetornarPonto([FromUri] int codigoPonto)
        {
            return Ok(registroPontoAppServico.RetornarPonto(codigoPonto));
        }

        [HttpPost]
        [Route("api/ponto")]
        public IHttpActionResult RegistrarPonto([FromBody] RegistrarPontoRequest request)
        {
            registroPontoAppServico.RegistrarPonto(request);
            return Ok();
        }

        [HttpGet]
        [Route("api/ponto")]
        [ResponseType(typeof(PontosComPaginacaoResponse))]
        public IHttpActionResult ListarPontos([FromUri] ListarPontosRequest request)
        {
            return Ok(registroPontoAppServico.ListarPontos(request));
        }

        [HttpGet]
        [Route("api/meu-ponto")]
        [ResponseType(typeof(PontosComPaginacaoResponse))]
        public IHttpActionResult ListarMeusPontos([FromUri] ListarMeusPontosRequest request)
        {
            return Ok(registroPontoAppServico.ListarMeusPontos(request));
        }

        [HttpGet]
        [Route("api/todos-ponto")]
        [ResponseType(typeof(IEnumerable<PontoResponse>))]
        public IHttpActionResult ListarTodosPontos()
        {
            return Ok(registroPontoAppServico.ListarTodosPontos());
        }

        [HttpDelete]
        [Route("api/ponto/{codigoPonto:int}")]
        public IHttpActionResult DeletarPonto([FromUri] int codigoPonto)
        {
            registroPontoAppServico.DeletarPonto(codigoPonto);
            return Ok();
        }
    }
}
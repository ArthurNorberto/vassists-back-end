﻿using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using VAssists.AppService.Estatisticas.interfaces;
using VAssists.AppService.Pontos.Interfaces;
using VAssists.DataTransfer.Estatisticas.responses;
using VAssists.DataTransfer.Pontos.requests;
using VAssists.DataTransfer.Pontos.responses;

namespace VAssistsProject.Controllers.Estatisicas
{
    public class EstatisticasController : ApiController
    {
        private readonly IEstatisticasAppServico estatisticasAppServico;

        public EstatisticasController(IEstatisticasAppServico estatisticasAppServico)
        {
            this.estatisticasAppServico = estatisticasAppServico;
        }

        [HttpGet]
        [Route("api/estatistica/usuario")]
        [ResponseType(typeof(IEnumerable<EstatisticaUsuarioResponse>))]
        public IHttpActionResult EstatisticasUsuarios()
        {
            return Ok(estatisticasAppServico.EstatisticasUsuarios());
        }


        [HttpGet]
        [Route("api/estatistica/ponto")]
        [ResponseType(typeof(IEnumerable<EstatisticaPontosResponse>))]
        public IHttpActionResult EstatisticasPontos()
        {
            return Ok(estatisticasAppServico.EstatisticasPontos());
        }

        [HttpGet]
        [Route("api/estatistica/ponto-estado")]
        [ResponseType(typeof(IEnumerable<EstatisticaPontoEstadoResponse>))]
        public IHttpActionResult EstatisticasPontosEstado()
        {
            return Ok(estatisticasAppServico.EstatisticasPontosEstado());
        }


    }
}
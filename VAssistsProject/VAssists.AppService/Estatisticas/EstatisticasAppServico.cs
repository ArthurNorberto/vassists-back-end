using Dominio.Estatisticas.repositorios;
using System.Collections.Generic;
using System.Linq;
using VAssists.AppService.Auxiliares;
using VAssists.AppService.Auxiliares.Interfaces;
using VAssists.AppService.Estatisticas.interfaces;
using VAssists.DataTransfer.Estatisticas.responses;
using VAssistsInfra.Estatisticas.repositorios;
using System;

namespace VAssists.AppService.Estatisticas
{
    public class EstatisticasAppServico : GenericoAppServico, IEstatisticasAppServico
    {
        private readonly IEstatisticasRepositorio estatisticasRepositorio;

        public EstatisticasAppServico(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.estatisticasRepositorio = new EstatisticasRepositorio(unitOfWork.Session);
        }

        public IEnumerable<EstatisticaPontosResponse> EstatisticasPontos()
        {
            var resultado = estatisticasRepositorio.EstatisticasPontos();

            IEnumerable<EstatisticaPontosResponse> response = resultado.Select(x => new EstatisticaPontosResponse
            {
                Tipo = x.Tipo,
                Quantidade = x.Quantidade
            });

            return response;
        }

        public IEnumerable<EstatisticaUsuarioResponse> EstatisticasUsuarios()
        {
            var resultado = estatisticasRepositorio.EstatisticasUsuarios();

            IEnumerable<EstatisticaUsuarioResponse> response = resultado.Select(x => new EstatisticaUsuarioResponse
            {
                Perfil = x.Perfil,
                Quantidade = x.Quantidade
            });
        
            return response;
        }
    }
}
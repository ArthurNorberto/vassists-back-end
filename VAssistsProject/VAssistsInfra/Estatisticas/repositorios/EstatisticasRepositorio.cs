using Dominio.Estatisticas.entidades;
using Dominio.Estatisticas.repositorios;
using NHibernate;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
using VAssistsInfra.Auxiliares;
using VDominio.Modelo;
using System;

namespace VAssistsInfra.Estatisticas.repositorios
{
    public class EstatisticasRepositorio : GenericoRepositorio, IEstatisticasRepositorio
    {
        public EstatisticasRepositorio(ISession session) : base(session)
        {
        }

        public IEnumerable<EstatisticasPonto> EstatisticasPontos()
        {
            var consulta = session.Query<Ponto>().GroupBy(x => x.Tipo.NomeTipo).Select(x => new { Tipo = x.Key, Quantidade = x.Count() }).ToList();

            IEnumerable<EstatisticasPonto> response = consulta.Select(x => new EstatisticasPonto
            {
                Tipo = x.Tipo,
                Quantidade = x.Quantidade
            });

            return response;
        }

        public IEnumerable<EstatisticasUsuario> EstatisticasUsuarios()
        {
            var consulta = session.Query<Usuario>().GroupBy(x => x.Perfil.NomePerfil).Select(x => new { Perfil = x.Key, Quantidade = x.Count() }).ToList();

            IEnumerable<EstatisticasUsuario> response = consulta.Select(x => new EstatisticasUsuario
            {
                Perfil = x.Perfil,
                Quantidade = x.Quantidade
            });

            return response;
        }
    }
}
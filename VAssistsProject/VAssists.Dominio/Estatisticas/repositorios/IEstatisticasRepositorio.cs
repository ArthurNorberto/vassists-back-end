using Dominio.Estatisticas.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Estatisticas.repositorios
{
    public interface IEstatisticasRepositorio
    {
        IEnumerable<EstatisticasUsuario> EstatisticasUsuarios();
        IEnumerable<EstatisticasPonto> EstatisticasPontos();
    }
}

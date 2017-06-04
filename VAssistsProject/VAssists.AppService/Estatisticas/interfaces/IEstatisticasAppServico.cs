using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAssists.DataTransfer.Estatisticas.responses;

namespace VAssists.AppService.Estatisticas.interfaces
{
    public interface IEstatisticasAppServico
    {
        IEnumerable<EstatisticaUsuarioResponse> EstatisticasUsuarios();
        IEnumerable<EstatisticaPontosResponse> EstatisticasPontos();
        IEnumerable<EstatisticaPontoEstadoResponse> EstatisticasPontosEstado();
    }
}

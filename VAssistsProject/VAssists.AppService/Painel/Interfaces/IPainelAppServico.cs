using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAssists.DataTransfer.Painel.responses;

namespace VAssists.AppService.Painel.Interfaces
{
    public interface IPainelAppServico
    {
        IEnumerable<PerfilResponse> ListarPerfil();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAssists.DataTransfer.Seguranca.requests;
using VAssists.DataTransfer.Seguranca.responses;

namespace VAssists.AppService.Seguranca.Interfaces
{
    public interface ISegurancaAppServico
    {
        UsuarioLogadoResponse LogarNoSistema(LoginSistemaRequest request);
    }
}

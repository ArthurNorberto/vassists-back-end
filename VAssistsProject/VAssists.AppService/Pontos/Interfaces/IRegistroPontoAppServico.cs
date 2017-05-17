using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAssists.DataTransfer.Pontos.requests;
using VAssists.DataTransfer.Pontos.responses;

namespace VAssists.AppService.Pontos.Interfaces
{
    public interface IRegistroPontoAppServico
    {
        PontoResponse RetornarPonto(int codigo);
        void RegistrarPonto(RegistrarPontoRequest request);
    }
}

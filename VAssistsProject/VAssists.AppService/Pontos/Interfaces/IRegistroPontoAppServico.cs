using VAssists.DataTransfer.Pontos.requests;
using VAssists.DataTransfer.Pontos.responses;

namespace VAssists.AppService.Pontos.Interfaces
{
    public interface IRegistroPontoAppServico
    {
        PontoResponse RetornarPonto(int codigo);

        void RegistrarPonto(RegistrarPontoRequest request);
        void DeletarPonto(int codigoPonto);
        PontosComPaginacaoResponse ListarPontos(ListarPontosRequest request);
    }
}
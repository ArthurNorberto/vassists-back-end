using VAssists.DataTransfer.Mensagens.requests;
using VAssists.DataTransfer.Mensagens.responses;

namespace VAssists.AppService.Mensagens.interfaces
{
    public interface IMensagensAppServico
    {
        MensagensPaginacaoResponse ListarMensagens(ListarMensagensRequest request);

        void InserirMensagem(InserirMensagemRequest request);
        void DeletarMensagem(int codigoMensagem);
    }
}
using VAssists.DataTransfer.Seguranca.requests;
using VAssists.DataTransfer.Seguranca.responses;

namespace VAssists.AppService.Seguranca.Interfaces
{
    public interface ISegurancaAppServico
    {
        UsuarioLogadoResponse LogarNoSistema(LoginSistemaRequest request);

        void DeslogarNoSistema(int codigoUsuario);

        void CadastroSistema(CadastroUsuarioRequest request);
    }
}
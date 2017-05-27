using VAssists.DataTransfer.Usuarios.requests;
using VAssists.DataTransfer.Usuarios.responses;

namespace VAssists.AppService.Usuarios.Interfaces
{
    public interface IUsuarioAppServico
    {
        UsuarioResponse RetornaUsuario(int codigoUsuario);

        void CadastrarUsuario(CadastrarUsuariosRequest request);
        UsuarioComPaginacaoResponse ListarUsuarios(ListarUsuariosRequest request);
    }
}
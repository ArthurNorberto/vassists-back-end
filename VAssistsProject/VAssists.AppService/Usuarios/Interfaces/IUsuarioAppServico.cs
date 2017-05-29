using VAssists.DataTransfer.Usuarios.requests;
using VAssists.DataTransfer.Usuarios.responses;

namespace VAssists.AppService.Usuarios.Interfaces
{
    public interface IUsuarioAppServico
    {
        UsuarioResponse RetornaUsuario(int codigoUsuario);

        void CadastrarUsuario(CadastrarUsuariosRequest request);

        UsuarioComPaginacaoResponse ListarUsuarios(ListarUsuariosRequest request);

        void AlterarUsuario(int codigoUsuario, AlterarUsuarioRequest request);

        void ExcluirUsuario(int codigoUsuario);

        void ResetarSenha(int codigoUsuario);

        void AlterarSenha(int codigoUsuario, AlterarSenhaRequest request);
    }
}
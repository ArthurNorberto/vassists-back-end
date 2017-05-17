using Domínio.Seguranca.repositorios;
using VAssists.AppService.Seguranca.Interfaces;
using VAssists.DataTransfer.Seguranca.requests;
using VAssists.DataTransfer.Seguranca.responses;

namespace VAssists.AppService.Seguranca
{
    public class SegurancaAppServico : ISegurancaAppServico
    {
        private readonly ISegurancaRepositorio segurancaRepositorio;

        public SegurancaAppServico(ISegurancaRepositorio segurancaRepositorio)
        {
            this.segurancaRepositorio = segurancaRepositorio;
        }

        public void CadastroSistema(CadastroUsuarioRequest request)
        {
            segurancaRepositorio.CadastroSistema(request.Nome, request.Email);
        }

        public void DeslogarNoSistema(int codigoUsuario)
        {
        }

        public UsuarioLogadoResponse LogarNoSistema(LoginSistemaRequest request)
        {
            var usuario = segurancaRepositorio.LogarNoSistema(request.Login, request.Senha);

            UsuarioLogadoResponse response = new UsuarioLogadoResponse()
            {
                idUsuario = usuario.idUsuario,
                nomeUsuario = usuario.nomeUsuario,
                perfil = usuario.perfil.idtPerfil
            };

            return response;
        }
    }
}
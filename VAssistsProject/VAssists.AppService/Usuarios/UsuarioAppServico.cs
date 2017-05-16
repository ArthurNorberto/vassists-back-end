using Domínio.Usuarios.repositorios;
using VAssists.AppService.Usuarios.Interfaces;
using VAssists.DataTransfer.Usuarios.responses;

namespace VAssists.AppService.Usuarios
{
    public class UsuarioAppServico : IUsuarioAppServico
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;

        public UsuarioAppServico(IUsuarioRepositorio usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }

        public UsuarioResponse RetornaUsuario(int codigoUsuario)
        {
            var result = usuarioRepositorio.RetornaUsuario(codigoUsuario);

            UsuarioResponse usuario = new UsuarioResponse()
            {
                CodigoUsuario = result.idUsuario,
                Nome = result.nomeUsuario
            };

            return usuario;
        }
    }
}
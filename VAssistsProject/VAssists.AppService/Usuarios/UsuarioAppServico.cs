using Domínio.Usuarios.repositorios;
using System;
using VAssists.AppService.Usuarios.Interfaces;
using VAssists.DataTransfer.Usuarios.requests;
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

        public void CadastrarUsuario(CadastrarUsuariosRequest request)
        {
            throw new NotImplementedException();
        }

        public UsuarioResponse RetornaUsuario(int codigoUsuario)
        {
            var result = usuarioRepositorio.RetornaUsuario(codigoUsuario);

            UsuarioResponse usuario = new UsuarioResponse()
            {
                CodigoUsuario = result.IdUsuario,
                Nome = result.NomeUsuario
            };

            return usuario;
        }
    }
}
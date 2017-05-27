using System.Linq;
using VAssists.AppService.Usuarios.Interfaces;
using VAssists.DataTransfer.Usuarios.requests;
using VAssists.DataTransfer.Usuarios.responses;
using VDominio.Painel.repositorios;
using VDominio.Usuarios.repositorios;

namespace VAssists.AppService.Usuarios
{
    public class UsuarioAppServico : IUsuarioAppServico
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;
        private readonly IPainelRepositorio painelRepositorio;

        public UsuarioAppServico(IUsuarioRepositorio usuarioRepositorio, IPainelRepositorio painelRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.painelRepositorio = painelRepositorio;
        }

        public void CadastrarUsuario(CadastrarUsuariosRequest request)
        {
            var perfil = painelRepositorio.RetornarPerfil(request.CodigoPerfil);

            usuarioRepositorio.CadastrarUsuario(perfil, request.Email, request.Nome);
        }

        public UsuarioComPaginacaoResponse ListarUsuarios(ListarUsuariosRequest request)
        {
            var resultado = usuarioRepositorio.ListarUsuarios(request.Nome, request.Email, request.Perfil, request.pg, request.qt);

            UsuarioComPaginacaoResponse response = new UsuarioComPaginacaoResponse()
            {
                quantidade = resultado.quantidade,
                pagina = resultado.pagina,
                usuarios = resultado.usuarios.Select(t => new UsuarioResponse
                {
                    CodigoUsuario = t.IdUsuario,
                    DataUltimoLogin = t.Dataultimologin,
                    Email = t.Email,
                    Nome = t.NomeUsuario,
                    Perfil = t.Perfil.NomePerfil
                })
            };

            return response;
        }

        public UsuarioResponse RetornaUsuario(int codigoUsuario)
        {
            var result = usuarioRepositorio.RetornaUsuario(codigoUsuario);

            UsuarioResponse usuario = new UsuarioResponse()
            {
                CodigoUsuario = result.IdUsuario,
                Nome = result.NomeUsuario,
                DataUltimoLogin = result.Dataultimologin,
                Email = result.Email,
                Perfil = result.Perfil.NomePerfil,
                Identificacao = result.Perfil.IdtPerfil,
                CodigoPerfil = result.Perfil.IdPerfil
            };

            return usuario;
        }
    }
}
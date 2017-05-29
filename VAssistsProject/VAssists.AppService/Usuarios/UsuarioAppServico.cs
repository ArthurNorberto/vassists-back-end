using System;
using System.Linq;
using VAssists.AppService.Usuarios.Interfaces;
using VAssists.DataTransfer.Usuarios.requests;
using VAssists.DataTransfer.Usuarios.responses;
using VAssistsInfra.Conexao;
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

        public void AlterarSenha(int codigoUsuario, AlterarSenhaRequest request)
        {
            if (request.SenhaAntiga == request.SenhaNova)
            {
                throw new Exception("A senha antiga é a mesma que a nova");
            }

            if (request.SenhaNova != request.SenhaNovaConfirme)
            {
                throw new Exception("As senhas não são parecidas!");
            }

            try
            {
                SessionSingleton.BeginTransaction();

                usuarioRepositorio.AlterarSenha(codigoUsuario, request.SenhaNova);

                SessionSingleton.Commit();
            }
            catch
            {
                SessionSingleton.Rollback();
                throw;
            }
        }

        public void AlterarUsuario(int codigoUsuario, AlterarUsuarioRequest request)
        {
            try
            {
                SessionSingleton.BeginTransaction();

                var perfil = painelRepositorio.RetornarPerfil(request.CodigoPerfil);

                usuarioRepositorio.AlterarUsuario(perfil, codigoUsuario, request.Email, request.Nome);

                SessionSingleton.Commit();
            }
            catch
            {
                SessionSingleton.Rollback();
                throw;
            }
        }

        public void CadastrarUsuario(CadastrarUsuariosRequest request)
        {
            try
            {
                SessionSingleton.BeginTransaction();
                var perfil = painelRepositorio.RetornarPerfil(request.CodigoPerfil);

                usuarioRepositorio.CadastrarUsuario(perfil, request.Email, request.Nome);

                SessionSingleton.Commit();
            }
            catch
            {
                SessionSingleton.Rollback();
                throw;
            }
        }

        public void ExcluirUsuario(int codigoUsuario)
        {
            try
            {
                SessionSingleton.BeginTransaction();

                usuarioRepositorio.ExcluirUsuario(codigoUsuario);

                SessionSingleton.Commit();
            }
            catch
            {
                SessionSingleton.Rollback();
                throw;
            }
        }

        public UsuarioComPaginacaoResponse ListarUsuarios(ListarUsuariosRequest request)
        {
            var resultado = usuarioRepositorio.ListarUsuarios(request.Nome, request.Email, request.CodigoPerfil, request.pg, request.qt);

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

        public void ResetarSenha(int codigoUsuario)
        {
            try
            {
                SessionSingleton.BeginTransaction();

                usuarioRepositorio.ResetarSenha(codigoUsuario);

                SessionSingleton.Commit();
            }
            catch
            {
                SessionSingleton.Rollback();
                throw;
            }
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
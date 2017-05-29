using System;
using VAssists.AppService.Seguranca.Interfaces;
using VAssists.DataTransfer.Seguranca.requests;
using VAssists.DataTransfer.Seguranca.responses;
using VAssistsInfra.Conexao;
using VDominio.Seguranca.repositorios;

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
            try
            {
                SessionSingleton.BeginTransaction();
                segurancaRepositorio.CadastroSistema(request.Nome, request.Email, request.CodigoPerfil);
                SessionSingleton.Commit();
            }
            catch
            {
                SessionSingleton.Rollback();
                throw;
            }
        }

        public void DeslogarNoSistema(int codigoUsuario)
        {
        }

        public UsuarioLogadoResponse LogarNoSistema(LoginSistemaRequest request)
        {
            try
            {
                SessionSingleton.BeginTransaction();
                var usuario = segurancaRepositorio.LogarNoSistema(request.Login, request.Senha);

                if (usuario == null)
                {
                    throw new Exception("Usuário não encontrado");
                }
                UsuarioLogadoResponse response = new UsuarioLogadoResponse()
                {
                    Codigo = usuario.IdUsuario,
                    Nome = usuario.NomeUsuario,
                    Perfil = usuario.Perfil.IdtPerfil
                };

                segurancaRepositorio.InserirDataLogin(usuario.IdUsuario);

                SessionSingleton.Commit();

                return response;
            }
            catch
            {
                SessionSingleton.Rollback();
                throw;
            }
        }
    }
}
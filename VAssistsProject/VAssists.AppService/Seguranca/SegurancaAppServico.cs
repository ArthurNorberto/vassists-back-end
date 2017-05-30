using System;
using VAssists.AppService.Auxiliares;
using VAssists.AppService.Auxiliares.Interfaces;
using VAssists.AppService.Seguranca.Interfaces;
using VAssists.DataTransfer.Seguranca.requests;
using VAssists.DataTransfer.Seguranca.responses;
using VAssistsInfra.Conexao;
using VAssistsInfra.Seguranca.repositorios;
using VDominio.Seguranca.repositorios;

namespace VAssists.AppService.Seguranca
{
    public class SegurancaAppServico : GenericoAppServico, ISegurancaAppServico
    {
        private readonly ISegurancaRepositorio segurancaRepositorio;

        public SegurancaAppServico(IUnitOfWork unitOfWork/*, ISegurancaRepositorio segurancaRepositorio*/) : base(unitOfWork)
        {
            //this.segurancaRepositorio = segurancaRepositorio;
            this.segurancaRepositorio = new SegurancaRepositorio(unitOfWork.Session);
        }

        public void CadastroSistema(CadastroUsuarioRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();
                segurancaRepositorio.CadastroSistema(request.Nome, request.Email, request.CodigoPerfil);
                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
            finally
            {
                unitOfWork.Dispose();
            }
        }

        public void DeslogarNoSistema(int codigoUsuario)
        {
        }

        public UsuarioLogadoResponse LogarNoSistema(LoginSistemaRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();
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

                unitOfWork.Commit();

                return response;
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
            finally
            {
                unitOfWork.Dispose();
            }
        }
    }
}
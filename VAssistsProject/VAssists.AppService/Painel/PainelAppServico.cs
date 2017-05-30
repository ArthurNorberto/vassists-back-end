using System.Collections.Generic;
using System.Linq;
using VAssists.AppService.Auxiliares;
using VAssists.AppService.Auxiliares.Interfaces;
using VAssists.AppService.Painel.Interfaces;
using VAssists.DataTransfer.Painel.requests;
using VAssists.DataTransfer.Painel.responses;
using VAssistsInfra.Conexao;
using VAssistsInfra.Painel.repositorios;
using VDominio.Painel.repositorios;

namespace VAssists.AppService.Painel
{
    public class PainelAppServico : GenericoAppServico, IPainelAppServico
    {
        private readonly IPainelRepositorio painelRepositorio;

        public PainelAppServico(IUnitOfWork unitOfWork/*, IPainelRepositorio painelRepositorio*/) : base(unitOfWork)
        {
            // this.painelRepositorio = painelRepositorio;
            this.painelRepositorio = new PainelRepositorio(unitOfWork.Session);
        }

        public void AlterarPerfil(int codigoPerfil, AlterarPerfilRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();
                painelRepositorio.AlterarPerfil(codigoPerfil, request.Descricao, request.Identificacao);
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

        public void AlterarTipo(int codigoTipo, AlterarTipoRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();
                painelRepositorio.AlterarTipo(codigoTipo, request.Descricao, request.Identificacao);
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

        public void DeletarPerfil(int codigoPerfil)
        {
            try
            {
                unitOfWork.BeginTransaction();
                painelRepositorio.DeletarPerfil(codigoPerfil);
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

        public void DeletarTipo(int codigoTipo)
        {
            try
            {
                unitOfWork.BeginTransaction();
                painelRepositorio.DeletarTipo(codigoTipo);

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

        public void InserirPerfil(InserirPerfilRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();
                painelRepositorio.InserirPerfil(request.Descricao, request.Identificacao);
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

        public void InserirTipo(InserirTipoRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();
                painelRepositorio.InserirTipo(request.Descricao, request.Identificacao);
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

        public IEnumerable<PerfilResponse> ListarPerfil()
        {
            try
            {
                var response = painelRepositorio.ListarPerfil().Select(x => new PerfilResponse
                {
                    Codigo = x.IdPerfil,
                    Descricao = x.NomePerfil,
                    Identificacao = x.IdtPerfil
                });

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

        public IEnumerable<PerfilResponse> ListarPerfilSemAdmin()
        {
            try
            {
                var response = painelRepositorio.ListarPerfilSemAdmin().Select(x => new PerfilResponse
                {
                    Codigo = x.IdPerfil,
                    Descricao = x.NomePerfil,
                    Identificacao = x.IdtPerfil
                });

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

        public IEnumerable<TipoResponse> ListarTipo()
        {
            try
            {
                var response = painelRepositorio.ListarTipo().Select(x => new TipoResponse
                {
                    Codigo = x.IdTipo,
                    Descricao = x.NomeTipo,
                    Identificacao = x.IdtTipo
                });

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

        public PerfilResponse RetornarPerfil(int codigoPerfil)
        {
            try
            {
                var perfil = painelRepositorio.RetornarPerfil(codigoPerfil);

                PerfilResponse response = new PerfilResponse()
                {
                    Codigo = perfil.IdPerfil,
                    Descricao = perfil.NomePerfil,
                    Identificacao = perfil.IdtPerfil
                };

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

        public TipoResponse RetornarTipo(int codigoTipo)
        {
            try
            {
                var perfil = painelRepositorio.RetornarTipo(codigoTipo);

                TipoResponse response = new TipoResponse()
                {
                    Codigo = perfil.IdTipo,
                    Descricao = perfil.NomeTipo,
                    Identificacao = perfil.IdtTipo
                };

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
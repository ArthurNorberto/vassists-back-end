using System.Collections.Generic;
using System.Linq;
using VAssists.AppService.Painel.Interfaces;
using VAssists.DataTransfer.Painel.requests;
using VAssists.DataTransfer.Painel.responses;
using VAssistsInfra.Conexao;
using VDominio.Painel.repositorios;

namespace VAssists.AppService.Painel
{
    public class PainelAppServico : IPainelAppServico
    {
        private readonly IPainelRepositorio painelRepositorio;

        public PainelAppServico(IPainelRepositorio painelRepositorio)
        {
            this.painelRepositorio = painelRepositorio;
        }

        public void AlterarPerfil(int codigoPerfil, AlterarPerfilRequest request)
        {
            try
            {
                SessionSingleton.BeginTransaction();
                painelRepositorio.AlterarPerfil(codigoPerfil, request.Descricao, request.Identificacao);
                SessionSingleton.Commit();
            }
            catch
            {
                SessionSingleton.Rollback();
                throw;
            }
        }

        public void AlterarTipo(int codigoTipo, AlterarTipoRequest request)
        {
            try
            {
                SessionSingleton.BeginTransaction();
                painelRepositorio.AlterarTipo(codigoTipo, request.Descricao, request.Identificacao);
                SessionSingleton.Commit();
            }
            catch
            {
                SessionSingleton.Rollback();
                throw;
            }
        }

        public void DeletarPerfil(int codigoPerfil)
        {
            try
            {
                SessionSingleton.BeginTransaction();
                painelRepositorio.DeletarPerfil(codigoPerfil);
                SessionSingleton.Commit();
            }
            catch
            {
                SessionSingleton.Rollback();
                throw;
            }
        }

        public void DeletarTipo(int codigoTipo)
        {
            try
            {
                SessionSingleton.BeginTransaction();
                painelRepositorio.DeletarTipo(codigoTipo);

                SessionSingleton.Commit();
            }
            catch
            {
                SessionSingleton.Rollback();
                throw;
            }
        }

        public void InserirPerfil(InserirPerfilRequest request)
        {
            try
            {
                SessionSingleton.BeginTransaction();
                painelRepositorio.InserirPerfil(request.Descricao, request.Identificacao);
                SessionSingleton.Commit();
            }
            catch
            {
                SessionSingleton.Rollback();
                throw;
            }
        }

        public void InserirTipo(InserirTipoRequest request)
        {
            try
            {
                SessionSingleton.BeginTransaction();
                painelRepositorio.InserirTipo(request.Descricao, request.Identificacao);
                SessionSingleton.Commit();
            }
            catch
            {
                SessionSingleton.Rollback();
                throw;
            }
        }

        public IEnumerable<PerfilResponse> ListarPerfil()
        {
            return painelRepositorio.ListarPerfil().Select(x => new PerfilResponse
            {
                Codigo = x.IdPerfil,
                Descricao = x.NomePerfil,
                Identificacao = x.IdtPerfil
            });
        }

        public IEnumerable<PerfilResponse> ListarPerfilSemAdmin()
        {
            return painelRepositorio.ListarPerfilSemAdmin().Select(x => new PerfilResponse
            {
                Codigo = x.IdPerfil,
                Descricao = x.NomePerfil,
                Identificacao = x.IdtPerfil
            });
        }

        public IEnumerable<TipoResponse> ListarTipo()
        {
            return painelRepositorio.ListarTipo().Select(x => new TipoResponse
            {
                Codigo = x.IdTipo,
                Descricao = x.NomeTipo,
                Identificacao = x.IdtTipo
            });
        }

        public PerfilResponse RetornarPerfil(int codigoPerfil)
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

        public TipoResponse RetornarTipo(int codigoTipo)
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
    }
}
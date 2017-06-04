using System.Collections.Generic;
using System.Linq;
using VAssists.AppService.Auxiliares;
using VAssists.AppService.Auxiliares.Interfaces;
using VAssists.AppService.Pontos.Interfaces;
using VAssists.DataTransfer.Pontos.requests;
using VAssists.DataTransfer.Pontos.responses;
using VAssistsInfra.Painel.repositorios;
using VAssistsInfra.Pontos.repositorios;
using VAssistsInfra.Usuarios.repositorios;
using VDominio.Painel.repositorios;
using VDominio.Pontos.repositorios;
using VDominio.Usuarios.repositorios;

namespace VAssists.AppService.Pontos
{
    public class RegistroPontoAppServico : GenericoAppServico, IRegistroPontoAppServico
    {
        private readonly IRegistroPontoRepositorio registroPontoRepositorio;
        private readonly IPainelRepositorio painelRepositorio;
        private readonly IUsuarioRepositorio usuarioRepositorio;

        public RegistroPontoAppServico(IUnitOfWork unitOfWork/*, IRegistroPontoRepositorio registroPontoRepositorio, IPainelRepositorio painelRepositorio, IUsuarioRepositorio usuarioRepositorio*/) : base(unitOfWork)
        {
            this.painelRepositorio = new PainelRepositorio(unitOfWork.Session);

            this.registroPontoRepositorio = new RegistroPontoRepositorio(unitOfWork.Session);
            this.usuarioRepositorio = new UsuarioRepositorio(unitOfWork.Session);
        }

        public void DeletarPonto(int codigoPonto)
        {
            try
            {
                unitOfWork.BeginTransaction();
                registroPontoRepositorio.DeletarPonto(codigoPonto);

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

        public PontosComPaginacaoResponse ListarMeusPontos(ListarMeusPontosRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var retorno = registroPontoRepositorio.ListarMeusPontos(request.CodigoUsuario, request.DataInicial, request.DataFinal, request.Endereco, request.CodigoTipo, request.pg, request.qt);

                PontosComPaginacaoResponse response = new PontosComPaginacaoResponse()
                {
                    quantidade = retorno.quantidade,
                    pagina = retorno.pagina,
                    pontos = retorno.pontos.Select(resultado => new PontoResponse
                    {
                        Codigo = resultado.IdPonto,
                        DataCadastrado = resultado.DataCadastrado,
                        DataRespondido = resultado.DataRespondido,
                        NomeUsuario = resultado.Usuario.NomeUsuario,
                        Email = resultado.Usuario.Email,
                        Latitude = resultado.Latitude,
                        Longitude = resultado.Longitude,
                        Tipo = resultado.Tipo.NomeTipo,
                        EnderecoCompleto = resultado.EnderecoCompleto,
                        Cidade = resultado.Cidade,
                        Pais = resultado.Pais,
                        Estado = resultado.Estado,
                        Observacao = resultado.Observacao
                    })
                };

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

        public PontosComPaginacaoResponse ListarPontos(ListarPontosRequest request)
        {
            try
            {
                var retorno = registroPontoRepositorio.ListarPontos(request.NomeUsuario, request.DataInicial, request.DataFinal, request.Endereco, request.CodigoTipo, request.pg, request.qt);

                PontosComPaginacaoResponse response = new PontosComPaginacaoResponse()
                {
                    quantidade = retorno.quantidade,
                    pagina = retorno.pagina,
                    pontos = retorno.pontos.Select(resultado => new PontoResponse
                    {
                        Codigo = resultado.IdPonto,
                        DataCadastrado = resultado.DataCadastrado,
                        DataRespondido = resultado.DataRespondido,
                        NomeUsuario = resultado.Usuario.NomeUsuario,
                        Email = resultado.Usuario.Email,
                        Latitude = resultado.Latitude,
                        Longitude = resultado.Longitude,
                        Tipo = resultado.Tipo.NomeTipo,
                        EnderecoCompleto = resultado.EnderecoCompleto,
                        Cidade = resultado.Cidade,
                        Pais = resultado.Pais,
                        Estado = resultado.Estado,
                        Observacao = resultado.Observacao
                    })
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

        public IEnumerable<PontoResponse> ListarTodosPontos()
        {
            var pontos = registroPontoRepositorio.ListarTodosPontos();

            var response = pontos.Select(x => new PontoResponse
            {
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                NomeUsuario = x.Usuario.NomeUsuario,
                Observacao = x.Observacao,
                EnderecoCompleto = x.EnderecoCompleto
            });

            return response;
        }

        public void RegistrarPonto(RegistrarPontoRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var usuario = usuarioRepositorio.RetornaUsuario(request.CodigoUsuario);
                var tipo = painelRepositorio.RetornarTipo(request.CodigoTipo);

                registroPontoRepositorio.RegistrarPonto(usuario, request.Latitude, request.Longitude, tipo, request.Observacao, request.Endereco, request.Cidade, request.Estado, request.Pais);

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

        public PontoResponse RetornarPonto(int codigo)
        {
            try
            {
                var resultado = registroPontoRepositorio.RetornarPonto(codigo);

                PontoResponse response = new PontoResponse
                {
                    Codigo = resultado.IdPonto,
                    DataCadastrado = resultado.DataCadastrado,
                    DataRespondido = resultado.DataRespondido,
                    NomeUsuario = resultado.Usuario.NomeUsuario,
                    Email = resultado.Usuario.Email,
                    Latitude = resultado.Latitude,
                    Longitude = resultado.Longitude,
                    Tipo = resultado.Tipo.NomeTipo,
                    EnderecoCompleto = resultado.EnderecoCompleto,
                    Cidade = resultado.Cidade,
                    Pais = resultado.Pais,
                    Estado = resultado.Estado,
                    Observacao = resultado.Observacao
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
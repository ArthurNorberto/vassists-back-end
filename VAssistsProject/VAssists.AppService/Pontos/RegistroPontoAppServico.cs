using System.Linq;
using VAssists.AppService.Pontos.Interfaces;
using VAssists.DataTransfer.Pontos.requests;
using VAssists.DataTransfer.Pontos.responses;
using VAssistsInfra.Conexao;
using VDominio.Painel.repositorios;
using VDominio.Pontos;
using VDominio.Usuarios.repositorios;
using System.Text.RegularExpressions;
using System;
using VAssists.AppService.Auxiliares;
using VAssists.AppService.Auxiliares.Interfaces;
using VAssistsInfra.Pontos.repositorios;
using VAssistsInfra.Usuarios.repositorios;
using VAssistsInfra.Painel.repositorios;

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
                var resultado = registroPontoRepositorio.ListarMeusPontos(request.CodigoUsuario, request.DataInicial, request.DataFinal, request.Endereco, request.CodigoTipo, request.pg, request.qt);

                PontosComPaginacaoResponse response = new PontosComPaginacaoResponse()
                {
                    quantidade = resultado.quantidade,
                    pagina = resultado.pagina,
                    pontos = resultado.pontos.Select(t => new PontoResponse
                    {
                        Codigo = t.IdPonto,
                        DataCadastrado = t.DataCadastrado,
                        DataRespondido = t.DataRespondido,
                        NomeUsuario = t.Usuario.NomeUsuario,
                        Latitude = t.Latitude,
                        Longitude = t.Longitude,
                        Tipo = t.Tipo.NomeTipo,
                        EnderecoCompleto = t.EnderecoCompleto,
                        Endereco = t.Endereco,
                        Bairro = t.Bairro,
                        Cidade = t.Cidade
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
       
                var resultado = registroPontoRepositorio.ListarPontos(request.NomeUsuario, request.DataInicial, request.DataFinal, request.Endereco, request.CodigoTipo, request.pg, request.qt);

                PontosComPaginacaoResponse response = new PontosComPaginacaoResponse()
                {
                    quantidade = resultado.quantidade,
                    pagina = resultado.pagina,
                    pontos = resultado.pontos.Select(t => new PontoResponse
                    {
                        Codigo = t.IdPonto,
                        DataCadastrado = t.DataCadastrado,
                        DataRespondido = t.DataRespondido,
                        NomeUsuario = t.Usuario.NomeUsuario,
                        Latitude = t.Latitude,
                        Longitude = t.Longitude,
                        Tipo = t.Tipo.NomeTipo,
                        EnderecoCompleto = t.EnderecoCompleto,
                        Endereco = t.Endereco,
                        Bairro = t.Bairro,
                        Cidade = t.Cidade

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

        public void RegistrarPonto(RegistrarPontoRequest request)
        {
            string pattern = "(.+?)(?:,|(?:- )|$)";
            string[] enderecos = Regex.Split(request.Endereco, pattern);


            try
            {
                unitOfWork.BeginTransaction();

                var usuario = usuarioRepositorio.RetornaUsuario(request.CodigoUsuario);
                var tipo = painelRepositorio.RetornarTipo(request.CodigoTipo);



                registroPontoRepositorio.RegistrarPonto(usuario, request.Latitude, request.Longitude, tipo, request.Observacao, request.Endereco, enderecos);

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
                    Latitude = resultado.Latitude,
                    Longitude = resultado.Longitude,
                    Tipo = resultado.Tipo.NomeTipo,
                    EnderecoCompleto = resultado.EnderecoCompleto,
                    Endereco = resultado.Endereco,
                    Bairro = resultado.Bairro,
                    Cidade = resultado.Cidade,
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
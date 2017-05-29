using System.Linq;
using VAssists.AppService.Pontos.Interfaces;
using VAssists.DataTransfer.Pontos.requests;
using VAssists.DataTransfer.Pontos.responses;
using VAssistsInfra.Conexao;
using VDominio.Painel.repositorios;
using VDominio.Pontos;
using VDominio.Usuarios.repositorios;

namespace VAssists.AppService.Pontos
{
    public class RegistroPontoAppServico : IRegistroPontoAppServico
    {
        private readonly IRegistroPontoRepositorio registroPontoRepositorio;
        private readonly IPainelRepositorio painelRepositorio;
        private readonly IUsuarioRepositorio usuarioRepositorio;

        public RegistroPontoAppServico(IRegistroPontoRepositorio registroPontoRepositorio, IPainelRepositorio painelRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            this.registroPontoRepositorio = registroPontoRepositorio;
            this.painelRepositorio = painelRepositorio;
            this.usuarioRepositorio = usuarioRepositorio;
        }

        public void DeletarPonto(int codigoPonto)
        {
            try
            {
                SessionSingleton.BeginTransaction();
                registroPontoRepositorio.DeletarPonto(codigoPonto);

                SessionSingleton.Commit();
            }
            catch
            {
                SessionSingleton.Rollback();
                throw;
            }
        }

        public PontosComPaginacaoResponse ListarMeusPontos(ListarMeusPontosRequest request)
        {
            try
            {
                SessionSingleton.BeginTransaction();
                var resultado = registroPontoRepositorio.ListarMeusPontos(request.CodigoUsuario, request.DataInicial, request.DataFinal, request.Endereco, request.CodigoTipo, request.pg, request.qt);

                PontosComPaginacaoResponse response = new PontosComPaginacaoResponse()
                {
                    quantidade = resultado.quantidade,
                    pagina = resultado.pagina,
                    pontos = resultado.pontos.Select(t => new PontoResponse
                    {
                        DataCadastrado = t.DataCadastrado,
                        DataRespondido = t.DataRespondido,
                        NomeUsuario = t.Usuario.NomeUsuario,
                        Latitude = t.Latitude,
                        Longitude = t.Longitude,
                        Tipo = t.Tipo.NomeTipo,
                        Endereco = t.Endereco
                    })
                };

                SessionSingleton.Commit();
                return response;
            }
            catch
            {
                SessionSingleton.Rollback();
                throw;
            }
        }

        public PontosComPaginacaoResponse ListarPontos(ListarPontosRequest request)
        {
            var resultado = registroPontoRepositorio.ListarPontos(request.NomeUsuario, request.DataInicial, request.DataFinal, request.Endereco, request.CodigoTipo, request.pg, request.qt);

            PontosComPaginacaoResponse response = new PontosComPaginacaoResponse()
            {
                quantidade = resultado.quantidade,
                pagina = resultado.pagina,
                pontos = resultado.pontos.Select(t => new PontoResponse
                {
                    DataCadastrado = t.DataCadastrado,
                    DataRespondido = t.DataRespondido,
                    NomeUsuario = t.Usuario.NomeUsuario,
                    Latitude = t.Latitude,
                    Longitude = t.Longitude,
                    Tipo = t.Tipo.NomeTipo,
                    Endereco = t.Endereco
                })
            };

            return response;
        }

        public void RegistrarPonto(RegistrarPontoRequest request)
        {
            try
            {
                SessionSingleton.BeginTransaction();

                var usuario = usuarioRepositorio.RetornaUsuario(request.CodigoUsuario);
                var tipo = painelRepositorio.RetornarTipo(request.CodigoTipo);

                registroPontoRepositorio.RegistrarPonto(usuario, request.Latitude, request.Longitude, tipo, request.Observacao, request.Endereco);

                SessionSingleton.Commit();
            }
            catch
            {
                SessionSingleton.Rollback();
                throw;
            }
        }

        public PontoResponse RetornarPonto(int codigo)
        {
            SessionSingleton.BeginTransaction();

            var resultado = registroPontoRepositorio.RetornarPonto(codigo);

            PontoResponse response = new PontoResponse
            {
                Latitude = resultado.Latitude,
                Longitude = resultado.Longitude
            };

            return response;
        }
    }
}
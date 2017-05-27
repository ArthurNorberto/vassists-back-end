using VDominio.Pontos;
using VAssists.AppService.Pontos.Interfaces;
using VAssists.DataTransfer.Pontos.requests;
using VAssists.DataTransfer.Pontos.responses;
using System;
using VDominio.Painel.repositorios;
using VDominio.Usuarios.repositorios;
using System.Linq;

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
            registroPontoRepositorio.DeletarPonto(codigoPonto);
        }

        public PontosComPaginacaoResponse ListarPontos(ListarPontosRequest request)
        {
            var resultado = registroPontoRepositorio.ListarPontos(request.NomeUsuario, request.pg, request.qt);

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
                    Tipo = t.Tipo.NomeTipo
                })
            };

            return response;
        }

        public void RegistrarPonto(RegistrarPontoRequest request)
        {
            var usuario = usuarioRepositorio.RetornaUsuario(request.CodigoUsuario);
            var tipo = painelRepositorio.RetornarTipo(request.Tipo);

            registroPontoRepositorio.RegistrarPonto(usuario, request.Latitude, request.Longitude, tipo, request.Observacao);
        }

        public PontoResponse RetornarPonto(int codigo)
        {
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
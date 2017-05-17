using Domínio.Pontos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAssists.AppService.Pontos.Interfaces;
using VAssists.DataTransfer.Pontos.responses;
using VAssists.DataTransfer.Pontos.requests;

namespace VAssists.AppService.Pontos
{
    public class RegistroPontoAppServico : IRegistroPontoAppServico
    {
        private readonly IRegistroPontoRepositorio registroPontoRepositorio;

        public RegistroPontoAppServico(IRegistroPontoRepositorio registroPontoRepositorio)
        {
            this.registroPontoRepositorio = registroPontoRepositorio;
        }

        public void RegistrarPonto(RegistrarPontoRequest request)
        {
            registroPontoRepositorio.RegistrarPonto(request.CodigoUsuario, request.Latitude, request.Longitude, request.Tipo, request.Observacao);
        }

        public PontoResponse RetornarPonto(int codigo)
        {
            var resultado = registroPontoRepositorio.RetornarPonto(codigo);

            PontoResponse response = new PontoResponse
            {
                Latitude = resultado.latitude,
                Longitude = resultado.longitude
            };

            return response;
            
        }
    }
}

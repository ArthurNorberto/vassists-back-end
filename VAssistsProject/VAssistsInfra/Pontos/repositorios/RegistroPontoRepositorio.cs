using Domínio.Modelo;
using Domínio.Pontos;
using System;

namespace VAssistsInfra.Pontos.repositorios
{
    public class RegistroPontoRepositorio : IRegistroPontoRepositorio
    {
        public void RegistrarPonto(int codigoUsuario, decimal latitude, decimal longitude, int tipo, string observacao)
        {
            throw new NotImplementedException();
        }

        public Ponto RetornarPonto(int codigo)
        {
            return new Ponto
            {
                IdPonto = 1,
                Latitude = 212,
                Longitude = 231
            };
        }
    }
}
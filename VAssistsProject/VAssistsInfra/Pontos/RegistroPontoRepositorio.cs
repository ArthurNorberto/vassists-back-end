using Domínio.Pontos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domínio.Modelo;

namespace VAssistsInfra.Pontos
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
                idPonto = 1,
                latitude  = 212,
                longitude = 231
            };
        }
    }
}

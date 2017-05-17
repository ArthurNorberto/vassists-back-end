using Domínio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domínio.Pontos
{
    public interface IRegistroPontoRepositorio
    {
        Ponto RetornarPonto(int codigo);
        void RegistrarPonto(int codigoUsuario, decimal latitude, decimal longitude, int tipo, string observacao);
    }
}

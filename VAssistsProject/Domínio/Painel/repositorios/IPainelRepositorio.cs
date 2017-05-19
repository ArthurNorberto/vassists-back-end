using Domínio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domínio.Painel.repositorios
{
    public interface IPainelRepositorio
    {
        IEnumerable<Perfil> ListarPerfil();
    }
}

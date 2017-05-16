using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domínio.Modelo;

namespace Domínio.Usuarios.repositorios
{
    public interface IUsuarioRepositorio
    {
        Usuario RetornaUsuario(int codigoUsuario);
    }
}

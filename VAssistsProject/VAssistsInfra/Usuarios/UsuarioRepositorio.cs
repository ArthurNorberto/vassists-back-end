using Domínio.Usuarios.repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domínio.Modelo;

namespace VAssistsInfra.Usuarios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public Usuario RetornaUsuario(int codigoUsuario)
        {
            return new Usuario()
            {
                idUsuario = 1,
                nomeUsuario = "Arthur"
            };

        }
    }
}

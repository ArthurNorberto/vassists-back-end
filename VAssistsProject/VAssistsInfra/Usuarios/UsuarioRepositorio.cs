using Domínio.Modelo;
using Domínio.Usuarios.repositorios;
using NHibernate;
using VAssistsInfra.Conexão;

namespace VAssistsInfra.Usuarios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ISession session;

        public UsuarioRepositorio()
        {
            session = SessionFactory.OpenSession();
        }

        public Usuario RetornaUsuario(int codigoUsuario)
        {
            

            return new Usuario()
            {
                IdUsuario = 1,
                NomeUsuario = "Arthur"
            };
        }
    }
}
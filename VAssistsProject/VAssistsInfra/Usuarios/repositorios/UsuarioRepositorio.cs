using VDominio.Modelo;
using VDominio.Usuarios.repositorios;
using NHibernate;
using VAssistsInfra.Conexao;
using NHibernate.Linq;
using System.Linq;

namespace VAssistsInfra.Usuarios.repositorios
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
            var usuario = session.Query<Usuario>().Where<Usuario>(x => x.IdUsuario == codigoUsuario).FirstOrDefault();

            return usuario;
        }
    }
}
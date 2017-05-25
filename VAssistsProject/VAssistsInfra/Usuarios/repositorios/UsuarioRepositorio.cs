using VDominio.Modelo;
using VDominio.Usuarios.repositorios;
using NHibernate;
using VAssistsInfra.Conexao;

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
            return new Usuario()
            {
                IdUsuario = 1,
                NomeUsuario = "Arthur"
            };
        }
    }
}
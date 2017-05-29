using NHibernate;
using VAssistsInfra.Conexao;

namespace VAssistsInfra.Auxiliares
{
    public abstract class GenericoRepositorio
    {
        protected readonly ISession session = SessionSingleton.Session;
    }
}
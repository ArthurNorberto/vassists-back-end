using NHibernate;
using VAssistsInfra.Conexao;

namespace VAssistsInfra.Auxiliares
{
    public abstract class GenericoRepositorio
    {
        protected readonly ISession session;

        public GenericoRepositorio(ISession session)
        {
            this.session = session;
        }

    }
}
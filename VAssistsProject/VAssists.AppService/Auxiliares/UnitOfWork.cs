using NHibernate;
using VAssists.AppService.Auxiliares.Interfaces;
using VAssistsInfra.Conexoes.Interfaces;

namespace VAssists.AppService.Auxiliares
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISessionUtil sessionUtil;

        public UnitOfWork(ISessionUtil sessionUtil)
        {
            this.sessionUtil = sessionUtil;
        }

        public ISession Session
        {
            get
            {
                return sessionUtil.Session;
            }
        }

        public void BeginTransaction()
        {
            sessionUtil.BeginTransaction();
        }

        public void Commit()
        {
            sessionUtil.Commit();
        }

        public void Dispose()
        {
            sessionUtil.Dispose();
        }

        public void Rollback()
        {
            sessionUtil.Rollback();
        }
    }
}
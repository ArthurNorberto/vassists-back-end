using NHibernate;
using System;

namespace VAssists.AppService.Auxiliares.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISession Session { get; }

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
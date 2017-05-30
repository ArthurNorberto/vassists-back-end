using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAssistsInfra.Conexoes.Interfaces
{
    public interface ISessionUtil
    {
        ISession Session { get; }

        void BeginTransaction();
        void Commit();
        void Rollback();
        void Dispose();
    }
}

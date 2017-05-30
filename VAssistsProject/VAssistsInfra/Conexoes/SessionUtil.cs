using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using VAssistsInfra.Conexoes.Interfaces;
using VAssistsInfra.Modelo.Mapeamento;

namespace VAssistsInfra.Conexao
{
    public class SessionUtil : ISessionUtil
    {
        private ISessionFactory _factory;
        private ISession _session;
        private readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Producao"].ConnectionString;
  
        public ISessionFactory Factory
        {
            get
            {
                if (_factory == null)
                {
                    _factory = Fluently.Configure()
                    .Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UsuarioMap>())
                    .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false)).BuildSessionFactory();
                }

                return _factory;
            }
        }

        public ISession Session
        {
            get
            {
                if (_session == null)
                {
                    _session = Factory.OpenSession();
                }
                return _session;
            }
        }

        public void BeginTransaction()
        {
            if (!Session.Transaction.IsActive)
            {
                Session.BeginTransaction();
            }
        }

        public void Commit()
        {
            if (Session.Transaction.IsActive)
            {
                Session.Flush();
                Session.Transaction.Commit();
            }
        }

        public void Close()
        {
            Session.Close();
        }

        public void Rollback()
        {
            if (Session.Transaction.IsActive)
            {
                Session.Flush();
                Session.Transaction.Rollback();
                Session.Transaction.Dispose();
            }
        }

        public void Dispose()
        {
            if (Session.Transaction.IsActive)
            {
                Session.Transaction.Dispose();
            }
        }

        internal void CloseSession()
        {
            _session.Close();
            _session = null;
        }

        ~SessionUtil()
        {
            // One time only destructor.
            CloseSession();
        }
    }
}
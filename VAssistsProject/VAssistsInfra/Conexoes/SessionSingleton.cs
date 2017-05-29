using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using VAssistsInfra.Modelo.Mapeamento;

namespace VAssistsInfra.Conexao
{
    public static class SessionSingleton
    {
        private static ISessionFactory _factory;
        private static ISession _session;
        private static readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Producao"].ConnectionString;
        private static readonly Destructor Finalise = new Destructor();

        public static ISessionFactory Factory
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

        public static ISession Session
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

        public static void BeginTransaction()
        {
            Session.BeginTransaction();
        }

        public static void Commit()
        {
            Session.Flush();
            Session.Transaction.Commit();
        }

        public static void Close()
        {
            Session.Close();
        }

        public static void Rollback()
        {
            if (Session.Transaction.IsActive)
            {
                Session.Flush();
                Session.Transaction.Rollback();
            }
        }

        internal static void CloseSession()
        {
            _session.Close();
            _session.Connection.Close();
            _session = null;
        }

        private sealed class Destructor
        {
            ~Destructor()
            {
                // One time only destructor.
                SessionSingleton.CloseSession();
            }
        }
    }
}
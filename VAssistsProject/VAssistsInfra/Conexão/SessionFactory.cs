using Domínio.Modelo.Mapeamento;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace VAssistsInfra.Conexão
{
    public static class SessionFactory
    {
        public static ISessionFactory _factory;
        public static readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Producao"].ConnectionString;

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

        public static ISession OpenSession()
        {
            return Factory.OpenSession();
        }
    }
}
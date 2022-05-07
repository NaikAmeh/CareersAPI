using Model.Core.Interfaces;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using SimpleInjector;
using System.Web;

namespace Models.Core.Models
{
    public static class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static ISessionFactory _sessionFactory;
        private static Container Container;

        public static ISessionFactory InitializeConfiguration()
        {
            if (_sessionFactory == null)
            {
                var cfg = new Configuration();
                var connectstring = System.Configuration.ConfigurationManager.AppSettings["ConnectionStringKey"];
                cfg.DataBaseIntegration(x =>
                {
                    x.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectstring].ConnectionString;
                    x.Driver<SqlClientDriver>();
                    x.Dialect<MsSql2012Dialect>();
                    x.LogSqlInConsole = true;
                    x.BatchSize = 30;
                });

                var mapper = new ModelMapper();
                mapper.AddMappings(typeof(NHibernateHelper).Assembly.GetTypes());

                cfg.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

                _sessionFactory = cfg.BuildSessionFactory();
            }
            return _sessionFactory;

        }

        public static void RegisterResource(Container container)
        {
            if (container == null)
                container = new Container();

            Container = container;
        }

        public static ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }

        public static ISession GetCurrentSession()
        {

            var context = HttpContext.Current;
            var currentSession = context.Items[CurrentSessionKey] as ISession;

            if (currentSession == null)
            {
                currentSession = _sessionFactory.OpenSession();
                context.Items[CurrentSessionKey] = currentSession;
            }

            return currentSession;
        }

        public static void CreateSession()
        {
            CurrentSessionContext.Bind(OpenSession());
        }

        public static void CloseSession()
        {
            var context = HttpContext.Current;
            var currentSession = context.Items[CurrentSessionKey] as ISession;

            if (currentSession == null)
            {
                // No current session
                return;
            }

            currentSession.Close();
            context.Items.Remove(CurrentSessionKey);
        }

        public static void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }

        public static IRepository<T> GetRepository<T>() where T : class
        {
            return Container.GetInstance<IRepository<T>>();
        }

        public static T GetFactory<T>() where T : class
        {
            return Container.GetInstance<T>();
        }

    }
}
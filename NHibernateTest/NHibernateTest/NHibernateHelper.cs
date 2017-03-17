using NHibernate;
using NHibernate.Cfg;
using NHibernateTest.Domain;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace NHibernateTest.Repositories
{
	// This class creates a session factory only the first time a client needs a new session.
	class NHibernateHelper
	{
		private static ISessionFactory _sessionFactory = null;

		private static ISessionFactory SessionFactory
		{
			get
			{
				if (_sessionFactory == null)
				{
					return Fluently.Configure().Database(
							MySQLConfiguration.Standard.ConnectionString(
								c => c.FromConnectionStringWithKey("ConnectionString")
							)
						)
						.Mappings(m => m.FluentMappings.AddFromAssemblyOf<Product>())
						.Mappings(m => m.FluentMappings.AddFromAssemblyOf<Trademark>())
						
						.BuildSessionFactory();
				}
				return _sessionFactory;
			}
		}

		public static ISession OpenSession()
		{
			return SessionFactory.OpenSession();
		}
	}
}

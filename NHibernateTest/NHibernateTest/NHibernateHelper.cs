﻿using NHibernate;
using NHibernate.Cfg;
using NHibernateTest.Domain;

namespace NHibernateTest.Repositories
{
	// This class creates a session factory only the first time a client needs a new session.
	class NHibernateHelper
	{
		private static ISessionFactory _sessionFactory;

		private static ISessionFactory SessionFactory
		{
			get
			{
				if (_sessionFactory == null)
				{
					var configuration = new Configuration();
					configuration.Configure();
					configuration.AddAssembly(typeof(Product).Assembly);
					_sessionFactory = configuration.BuildSessionFactory();
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

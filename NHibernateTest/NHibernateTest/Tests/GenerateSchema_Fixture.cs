﻿using NHibernateTest.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
 
namespace NHibernateTest.Tests
{
	[TestFixture]
	public class GenerateSchema_Fixture
	{
		[Test]
		public void Can_generate_schema()
		{
			var cfg = new Configuration();
			cfg.Configure();
			cfg.AddAssembly(typeof(Product).Assembly);

			new SchemaExport(cfg).Execute(false, true, false);
		}
	}
}
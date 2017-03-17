using System.Collections.Generic;

using NHibernate;
using NHibernate.Criterion;

using NHibernateTest.Domain;

namespace NHibernateTest.Repositories
{
	class TrademarkRepository : IObjectRepository<Trademark>
	{
		public void Add(Trademark product)
		{
			using (ISession session = NHibernateHelper.OpenSession())
			using (ITransaction transaction = session.BeginTransaction())
			{
				session.Save(product);
				transaction.Commit();
			}
		}

		public void Update(Trademark product)
		{
			using (ISession session = NHibernateHelper.OpenSession())
			using (ITransaction transaction = session.BeginTransaction())
			{
				session.Update(product);
				transaction.Commit();
			}
		}

		public void Remove(Trademark trademark)
		{
			using (ISession session = NHibernateHelper.OpenSession())
			using (ITransaction transaction = session.BeginTransaction())
			{
				session.Delete(trademark);
				transaction.Commit();
			}
		}

		public Trademark GetById(int Id)
		{
			using (ISession session = NHibernateHelper.OpenSession())
				return session.Get<Trademark>(Id);
		}

		public Trademark GetByName(string name)
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				Trademark trademark = session
					.CreateCriteria(typeof(Product))
					.Add(Restrictions.Eq("Name", name))
					.UniqueResult<Trademark>();
				return trademark;
			}
		}

		public ICollection<Trademark> GetAll()
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				var trademarks = session
					.CreateCriteria(typeof(Trademark))
					.List<Trademark>();
				return trademarks;
			}
		}

	}
}

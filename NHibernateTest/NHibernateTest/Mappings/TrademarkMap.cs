using FluentNHibernate.Mapping;
using NHibernateTest.Domain;

namespace NHibernateTest
{
	class TrademarkMap : ClassMap<Trademark>
	{
		public TrademarkMap()
		{
			Id(x => x.Id);
			Map(x => x.Name).Not.Nullable();
			HasMany(x => x.ProductList)
			.Inverse()
			.Cascade.All().Fetch.Join();
		}
	}
}
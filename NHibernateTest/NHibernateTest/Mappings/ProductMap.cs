using FluentNHibernate.Mapping;
using NHibernateTest.Domain;

namespace NHibernateTest
{
	public class ProductMap : ClassMap<Product>
	{
		public ProductMap()
		{
			Id(x => x.Id);
			Map(x => x.Name).Not.Nullable();
			Map(x => x.Category);
			Map(x => x.Discontinued);
			References(x => x.CommercialBrand).Column("CommercialBrand");
		}
	}
}

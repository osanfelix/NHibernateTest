using System.Collections.Generic;

namespace NHibernateTest.Domain
{
	public class Trademark
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual IList<Product> ProductList { get; protected set; }

		public Trademark()
		{
			ProductList = new List<Product>();
		}

		public virtual void AddProduct(Product product)
		{
			product.CommercialBrand = this;
			ProductList.Add(product);
		}
	}
}

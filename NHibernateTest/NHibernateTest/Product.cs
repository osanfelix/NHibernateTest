﻿
namespace NHibernateTest.Domain
{
	public class Product
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Category { get; set; }
		public virtual bool Discontinued { get; set; }
		public virtual Trademark CommercialBrand { get; set; }
	}
}
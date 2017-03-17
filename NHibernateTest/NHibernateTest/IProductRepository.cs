using System.Collections.Generic;

namespace NHibernateTest.Domain
{
	public interface IObjectRepository<T>
	{
		void Add(T product);
		void Update(T product);
		void Remove(T product);
		T GetById(int productId);
		T GetByName(string name);
		//ICollection<Product> GetByCategory(string category);
		ICollection<T> GetAll();
	}
}

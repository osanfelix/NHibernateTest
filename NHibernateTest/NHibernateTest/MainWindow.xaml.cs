using System.Windows;
using System.Collections.Generic;
using NHibernateTest.Domain;
using NHibernateTest.Repositories;

namespace NHibernateTest
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Trademark cocacola = null;

		public MainWindow()
		{
			InitializeComponent();

			updateGrid();
			populateTrademarkCombo();
		}

		void populateTrademarkCombo()
		{
			IObjectRepository<Trademark> repository = new TrademarkRepository();
			TrademakCombo.Items.Clear();
			ICollection<Trademark> listt = repository.GetAll();
			IList<int> idx = new List<int>();
			foreach (Trademark t in repository.GetAll())
			{
				if (!idx.Contains(t.Id))
				{
					TrademakCombo.Items.Add(t.Name);
					idx.Add(t.Id);
				}
			}
		}
		

		private void button_Click(object sender, RoutedEventArgs e)
		{
			IObjectRepository<Trademark> repository = new TrademarkRepository();

			Product product = new Product { Name = NameBox.Text, Category = CategoryBox.Text };
			Trademark trademark = repository.GetByName(TrademakCombo.SelectedItem.ToString());

			// Add the product into trademark
			trademark.AddProduct(product);

			// Update Trademark into DDBB
			repository.Update(trademark);

			updateGrid();
		}

		private void updateGrid()
		{
			IObjectRepository<Product> repository = new ProductRepository();
			dataGrid.ItemsSource = repository.GetAll();
		}

		private void getTrademark()
		{
			IObjectRepository<Trademark> repository = new TrademarkRepository();
			cocacola = repository.GetByName("Burguer");

			if(cocacola == null)
			{
				cocacola = new Trademark { Name = "Burguer" };
				repository.Add(cocacola);
			}
		}

		private void button_Click_AddTrademark(object sender, RoutedEventArgs e)
		{
			IObjectRepository<Trademark> repository = new TrademarkRepository();
			string trademark = TrademarkBox.Text;
			if (trademark != "")
			{
				repository.Add(new Trademark { Name = trademark });
				populateTrademarkCombo();
				TrademarkBox.Clear();
			}
		}
	}
}

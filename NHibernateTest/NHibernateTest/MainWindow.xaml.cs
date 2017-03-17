using System.Windows;

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

			//getTrademark();

			updateGrid();


		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			// Insert a product into DDBB
			Product product = new Product { Name = NameBox.Text, Category = CategoryBox.Text };
			//cocacola.AddProduct(product);
			IObjectRepository<Product> repository = new ProductRepository();

			repository.Add(product);

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
			cocacola = repository.GetByName("CocaCola");

			if(cocacola == null)
			{
				cocacola = new Trademark { Name = "CocaCola" };
			}
		}
	}
}

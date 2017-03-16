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
		public MainWindow()
		{
			InitializeComponent();

			updateGrid();
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			// Insert a product into DDBB
			Product product = new Product { Name = NameBox.Text, Category = CategoryBox.Text };
			IProductRepository repository = new ProductRepository();
			repository.Add(product);

			updateGrid();
		}

		private void updateGrid()
		{
			IProductRepository repository = new ProductRepository();
			dataGrid.ItemsSource = repository.GetAll();
		}
	}
}

using Infrastructure.Services;
using System.Windows;
using WpfApplication.Models;
using WpfApplication.Views;


namespace WpfApplication
{
    public partial class MainWindow : Window
    {
        List<Product> _productList = new List<Product>();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Product_Click(object sender, RoutedEventArgs e)
        {
            string name = ProductNameTextBox.Text;
            decimal price = decimal.TryParse(ProductPriceTextBox.Text, out var p) ? p : 0;
            string category = CategoryTextBox.Text;
            string manufacturer = ManufacturerTextBox.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Product name cannot be empty!");
                return;
            }

            if (price <= 0)
            {
                MessageBox.Show("Price must be greater than 0!");
                return;
            }

            if (_productList.Any(x => x.ProductName == name))
            {
                MessageBox.Show("This product already exists!");
                return;
            }

            var product = new Product
            {
                ProductName = name,
                ProductPrice = price,
                Category = category,
                Manufacturer = manufacturer
            };

            _productList.Add(product);

            ProductsListView.Items.Clear();
            foreach (var productItem in _productList)
            {
                ProductsListView.Items.Add($"{productItem.ProductName} | {productItem.Category} | {productItem.Manufacturer} | {productItem.ProductPrice}");
            }

            ProductNameTextBox.Text = null!;
            ProductPriceTextBox.Text = null!;
            CategoryTextBox.Text = null!;
            ManufacturerTextBox.Text = null!;
        }

        private void ShowProductListView_Click(object sender, RoutedEventArgs e)
        {
            var view = new ProductViewList(_productList);
            view.BackRequested += () => MainContent.Content = null; 
            MainContent.Content = view;
        }

        private FileService _fileService = new FileService();

        private void SaveProducts_Click(object sender, RoutedEventArgs e)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(_productList, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            _fileService.SaveJsonContentToFile(json);
            MessageBox.Show("Products saved!");
        }

        private void LoadProducts_Click(object sender, RoutedEventArgs e)
        {
            var json = _fileService.GetJsonContentFromFile();
            if (!string.IsNullOrWhiteSpace(json))
            {
                _productList = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
                ProductsListView.Items.Clear();
                foreach (var productItem in _productList)
                {
                    ProductsListView.Items.Add($"{productItem.ProductName} | {productItem.Category} | {productItem.Manufacturer} | {productItem.ProductPrice}");
                }
            }
        }
    }
}
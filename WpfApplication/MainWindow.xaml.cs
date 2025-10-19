using Infrastructure.Models;
using System.Windows;

namespace WpfApplication;

public partial class MainWindow : Window
{
    List<Product> _productList = new List<Product>();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Add_Product_Click(object sender, RoutedEventArgs e)
    {
        Product product = new Product
        {
            ProductName = ProductNameTextBox.Text,
            ProductPrice = decimal.TryParse(ProductPriceTextBox.Text, out var price) ? price : 0,
            Category = CategoryTextBox.Text,
            Manufacturer = ManufacturerTextBox.Text,
        };

        _productList.Add(product);

        ProductsListView.Items.Clear();
        foreach (var p in _productList)
        {
            ProductsListView.Items.Add($"{product.ProductName} | {product.Category} | {product.Manufacturer} | {product.ProductPrice}");
        }

        ProductNameTextBox.Text = "";
        ProductPriceTextBox.Text = "";
        CategoryTextBox.Text = "";
        ManufacturerTextBox.Text = "";
    }
}

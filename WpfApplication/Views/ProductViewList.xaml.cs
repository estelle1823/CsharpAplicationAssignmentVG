using System.Windows;
using System.Windows.Controls;
using WpfApplication.Models;

namespace WpfApplication.Views
{
    public partial class ProductViewList : UserControl
    {
        private List<Product> _productList;

        public ProductViewList(List<Product> productList)
        {
            InitializeComponent();
            _productList = productList;
            RefreshList();
        }

        private void RefreshList()
        {
            ProductsViewList.Items.Clear();
            foreach (var product in _productList)
            {
                ProductsViewList.Items.Add($"{product.ProductName} | {product.Category} | {product.Manufacturer} | {product.ProductPrice}");
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainContent.Content = null!;
        }
    }
}


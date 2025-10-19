using WpfApplication.Models;
using System.Windows;
using System.Windows.Controls;


namespace WpfApplication.Views;

    public partial class ProductViewList : UserControl
    {
        private List<Product> _productList;
        public event Action? BackRequested;

        public ProductViewList(List<Product> productList)
        {
            InitializeComponent();
            _productList = productList;
            ProductsViewList.ItemsSource = _productList;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            BackRequested?.Invoke();
        }

        private void RemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is Product product)
            {
                _productList.Remove(product);
                ProductsViewList.Items.Refresh();
            }
        }
    }

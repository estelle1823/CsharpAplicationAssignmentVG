using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
namespace WpfApplication;


public partial class MainWindow : Window
{
    private ObservableCollection<string> _productList = ["Product List"];
    public MainWindow()
    {
        InitializeComponent();
        Products.ItemsSource = _productList;
   
    }
    
    private void Add_Product_Clcik(object sender, RoutedEventArgs e)
    {
        var btn = (Button)sender;
        btn.Content = "Added";
        Products.Items.Add("Product Added");
        _productList.Add("Product Added");
    }

}


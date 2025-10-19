using System.Collections.ObjectModel;
using WpfApplication.Models;

public class MainViewModel
{
    public ObservableCollection<Product> Products { get; } = new ObservableCollection<Product>();

    public void Add_Product_Click(string name, string category, string manufacturer, string price)
    {
        Products.Add(new Product
        {
            ProductName = name,
            Category = category,
            Manufacturer = manufacturer,
            ProductPrice = decimal.TryParse(price, out var p) ? p : 0

        });
     
    }
}

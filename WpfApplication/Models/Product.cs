namespace WpfApplication.Models;

public class Product
{
    public string ProductName { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public decimal ProductPrice { get; set; }
}
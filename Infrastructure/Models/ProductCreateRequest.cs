namespace Infrastructure.Models;

public class ProductCreateRequest
{
    public string ProductName { get; set; } = null!;
    public decimal ProductPrice { get; set; }
    public string CategoryName { get; set; } = null!;
    public string ManufacturerName { get; set; } = null!;
}
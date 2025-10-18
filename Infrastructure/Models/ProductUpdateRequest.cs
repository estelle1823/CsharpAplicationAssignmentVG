namespace Infrastructure.Models;

public class ProductUpdateRequest
{
    public string Id { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public decimal ProductPrice { get; set; }
    public string CategoryId { get; set; } = null!;
    public string ManufacturerId { get; set; } = null!;
}
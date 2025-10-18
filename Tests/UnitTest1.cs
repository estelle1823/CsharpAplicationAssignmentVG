namespace Tests;
using Infrastructure.Models;
using Infrastructure.Services;

public class ProductServiceTests
{
    private readonly string _testFilePath = "test_products.json";

    // Generated with ChatGpt
    [Fact]
    public void CreateProduct_ShouldAddProductToList()
    {
        if (File.Exists(_testFilePath))
            File.Delete(_testFilePath);

        // Arrange
        var fileService = new FileService(_testFilePath);
        var productService = new ProductService(fileService);

        var productRequest = new ProductCreateRequest
        {
            ProductName = "Testproduct",
            ProductPrice = 99.99m
        };

        // Act
        productService.CreateProduct(productRequest);
        var products = productService.GetAllProducts().ToList();

        // Assert
        Assert.Single(products);
        Assert.Equal("Testproduct", products[0].ProductName);
        Assert.Equal(99.99m, products[0].ProductPrice);
    }
}
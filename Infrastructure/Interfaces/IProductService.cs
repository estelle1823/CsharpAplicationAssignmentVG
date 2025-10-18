using Infrastructure.Models;
namespace Infrastructure.Interfaces;

public interface IProductService
{
    bool CreateProduct(ProductCreateRequest product);

    IEnumerable<Product> GetAllProducts();
    Product GetProductById(Guid id);
    Product GetProductByArticleNumber(string articleNumber);
    Product GetProductByTitle(string productTitle);
    Product GetProductByUnitPrice(decimal unitPrice);
    Product SaveJsonContentToFile();
    bool AddProductsToList(ProductCreateRequest product);

    bool UpdateProduct(Guid id, ProductUpdateRequest product);
    bool DeleteProduct(Guid productId);

}
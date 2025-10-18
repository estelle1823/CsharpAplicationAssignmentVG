using Infrastructure.Models;
namespace Infrastructure.Interfaces;

public interface IProductService
{
    bool CreateProduct(ProductCreateRequest product);

    IEnumerable<Product> GetAllProducts();
    Product GetProductById(Guid id);
    Product GetProductByArticleNumber(string articleNumber);
    Product GetProductByProductName(string productName);
    Product GetProductByProductPrice(decimal productPrice);
    bool SaveJsonContentToFile();
    bool AddProductsToList(ProductCreateRequest product);
    bool UpdateProduct(Guid id, ProductUpdateRequest product);
    bool DeleteProduct(Guid productId);

}
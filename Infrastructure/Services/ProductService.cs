using Infrastructure.Interfaces;
using Infrastructure.Models;
using System.Text.Json;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private List<Product> _productList = new();
    private readonly FileService _fileService;

    public ProductService(FileService fileService)
    {
        _fileService = fileService;

        var json = _fileService.GetJsonContentFromFile();
        if (!string.IsNullOrWhiteSpace(json))
        {
            var loaded = JsonSerializer.Deserialize<List<Product>>(json);
            if (loaded is not null)
                _productList = loaded;
        }
    }
        public void SaveToFile()
    {
        var json = JsonSerializer.Serialize(_productList, new JsonSerializerOptions { WriteIndented = true });
        _fileService.SaveJsonContentToFile(json);
    
    }
    public bool CreateProduct(ProductCreateRequest productRequest)
    {
        if (string.IsNullOrWhiteSpace(productRequest.ProductName) || productRequest.ProductPrice <= 0)
            return false;

        if (_productList.Any(p => p.ProductName == productRequest.ProductName))
            return false;

        var newProduct = new Product
        {
            Id = Guid.NewGuid().ToString(),
            ProductName = productRequest.ProductName,
            ProductPrice = productRequest.ProductPrice,
            Category = productRequest.CategoryName,
            Manufacturer = productRequest.ManufacturerName
        };

        _productList.Add(newProduct);
        SaveToFile();
        return true;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _productList;
    }

    public Product GetProductById(Guid id)
    {
        string productId = id.ToString();
        foreach (var product in _productList)
        {
            if (product.Id == productId)
                return product;
        }
        return null!;
    }

    public Product GetProductByArticleNumber(string articleNumber)
    {
        foreach (var product in _productList)
        {
            if (product.ArticleNumber == articleNumber)
                return product;
        }
        return null!;
    }

    public Product GetProductByProductName(string productName)
    {
        foreach (var product in _productList)
        {
            if (product.ProductName == productName)
                return product;
        }
        return null!;
    }

    public Product GetProductByProductPrice(decimal productPrice)
    {
        foreach (var product in _productList)
        {
            if (product.ProductPrice == productPrice)
                return product;
        }
        return null!;
    }

    public bool SaveJsonContentToFile()
    {
        var json = JsonSerializer.Serialize(_productList, new JsonSerializerOptions { WriteIndented = true });
        return _fileService.SaveJsonContentToFile(json);
    }

    public bool AddProductsToList(ProductCreateRequest productRequest)
    {
        if (string.IsNullOrWhiteSpace(productRequest.ProductName))
            return false;

        var newProduct = new Product
        {
            Id = Guid.NewGuid().ToString(),
            ProductName = productRequest.ProductName,
            ProductPrice = productRequest.ProductPrice
        };

        _productList.Add(newProduct);
        SaveToFile();
        return true;
    }


    public bool UpdateProduct(Guid id, ProductUpdateRequest productUpdate)
    {
        string idString = id.ToString();
        foreach (var product in _productList)
        {
            if (product.Id == idString)
            {
                if (string.IsNullOrWhiteSpace(productUpdate.ProductName))
                    return false;

                product.ProductName = productUpdate.ProductName;
                product.ProductPrice = productUpdate.ProductPrice;

                SaveToFile();
                return true;
            }
        }
        return false;
    }

    public bool DeleteProduct(Guid productId)
    {
        string idString = productId.ToString();

        foreach (var product in _productList)
        {
            if (product.Id == idString)
            {
                _productList.Remove(product);

                SaveToFile();

                return true;
            }
        }

        return false;
    }
}


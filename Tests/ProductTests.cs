using Infrastructure.Models;
using Infrastructure.Services;

namespace Tests;

//Tests generated with ChatGPT
    public class ProductTests
    {
        private readonly string _testFilePath = Path.Combine(Path.GetTempPath(), "test_products.json");

        private ProductService GetService()
        {
            if (File.Exists(_testFilePath))
                File.Delete(_testFilePath);

            return new ProductService(new FileService(_testFilePath));
        }

        [Fact]
        public void CreateProduct_ShouldAddProductToList()
        {
            var service = GetService();
            var request = new ProductCreateRequest { ProductName = "TestProduct", ProductPrice = 99.99m };
            var result = service.CreateProduct(request);

            var products = service.GetAllProducts().ToList();
            Assert.True(result);
            Assert.Single(products);
            Assert.Equal("TestProduct", products[0].ProductName);
            Assert.Equal(99.99m, products[0].ProductPrice);
        }

        [Fact]
        public void UpdateProduct_ShouldChangeProduct()
        {
            var service = GetService();
            var request = new ProductCreateRequest { ProductName = "UpdateTest", ProductPrice = 50m };
            service.CreateProduct(request);

            var product = service.GetAllProducts().First();
            var updateRequest = new ProductUpdateRequest { ProductName = "Updated", ProductPrice = 75m };
            var updated = service.UpdateProduct(Guid.Parse(product.Id), updateRequest);

            var updatedProduct = service.GetAllProducts().First();
            Assert.True(updated);
            Assert.Equal("Updated", updatedProduct.ProductName);
            Assert.Equal(75m, updatedProduct.ProductPrice);
        }

        [Fact]
        public void DeleteProduct_ShouldRemoveProduct()
        {
            var service = GetService();
            var request = new ProductCreateRequest { ProductName = "DeleteTest", ProductPrice = 30m };
            service.CreateProduct(request);

            var product = service.GetAllProducts().First();
            var deleted = service.DeleteProduct(Guid.Parse(product.Id));

            var products = service.GetAllProducts().ToList();
            Assert.True(deleted);
            Assert.Empty(products);
        }

        [Fact]
        public void DuplicateProduct_ShouldNotBeAdded()
        {
            var service = GetService();
            var request = new ProductCreateRequest { ProductName = "DuplicateTest", ProductPrice = 10m };
            var first = service.CreateProduct(request);
            var second = service.CreateProduct(request);

            var products = service.GetAllProducts().ToList();
            Assert.True(first);
            Assert.False(second);
            Assert.Single(products);
        }

        [Fact]
        public void SaveAndLoad_ShouldPersistProducts()
        {
            var service = GetService();
            service.CreateProduct(new ProductCreateRequest { ProductName = "Load1", ProductPrice = 100m });
            service.CreateProduct(new ProductCreateRequest { ProductName = "Load2", ProductPrice = 200m });

            var newService = new ProductService(new FileService(_testFilePath));
            var products = newService.GetAllProducts().ToList();

            Assert.Equal(2, products.Count);
            Assert.Equal("Load1", products[0].ProductName);
            Assert.Equal("Load2", products[1].ProductName);
        }

        [Fact]
        public void InvalidProduct_ShouldNotBeAdded()
        {
            var service = GetService();
            var result1 = service.CreateProduct(new ProductCreateRequest { ProductName = "", ProductPrice = 10m });
            var result2 = service.CreateProduct(new ProductCreateRequest { ProductName = "Valid", ProductPrice = -5m });

            var products = service.GetAllProducts().ToList();
            Assert.False(result1);
            Assert.False(result2);
            Assert.Empty(products);
        }
    }

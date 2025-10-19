﻿
using Infrastructure.Models;
using Infrastructure.Services;

var fileService = new FileService();
var productService = new ProductService(fileService);

while (true)
{
    Console.Clear();
    Console.WriteLine("=== Product Menu ===");
    Console.WriteLine("1. Add new product");
    Console.WriteLine("2. Show all products");
    Console.WriteLine("3. Save products to file");
    Console.WriteLine("4. Exit");
    Console.Write("Choose option (1-4): ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter product name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter product price: ");
            string? priceInput = Console.ReadLine();

            Console.Write("Enter category: ");
            string? category = Console.ReadLine();

            Console.Write("Enter manufacturer: ");
            string? manufacturer = Console.ReadLine();


            if (!string.IsNullOrWhiteSpace(name) && decimal.TryParse(priceInput, out decimal price))
            {
                var newProduct = new ProductCreateRequest
                {
                    ProductName = name,
                    ProductPrice = price,
                    ManufacturerName = manufacturer,
                    CategoryName= category,
                };

                productService.CreateProduct(newProduct);
                Console.WriteLine("Product added!");
            }
            else
            {
                Console.WriteLine("Invalid name or price.");
            }
            break;

        case "2":
            var products = productService.GetAllProducts();
            Console.WriteLine("\n--- Product List ---");
            foreach (var p in products)
            {
                Console.WriteLine($"ID: {p.Id} | Name: {p.ProductName} | Price: {p.ProductPrice} SEK");
            }

            if (!products.Any())
            {
                Console.WriteLine("No products found.");
            }
            break;

        case "3":
            productService.SaveToFile();
            Console.WriteLine("Products saved to file.");
            break;

        case "4":
            Console.WriteLine("Exiting...");
            return;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }

    Console.WriteLine("\nPress Enter to continue...");
    Console.ReadLine();
}
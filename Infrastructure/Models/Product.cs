﻿namespace Infrastructure.Models;

public class Product
{
 public string Id { get; set; } = Guid.NewGuid().ToString();
public string ProductName { get; set; } = null!;
public decimal ProductPrice { get; set; }
public string ArticleNumber { get; set; } = null!;
public ProductCategory Category { get; set; } = null!;
public ProductManufacturer Manufacturer { get; set; } = null!;
   
}
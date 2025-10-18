﻿namespace Infrastructure.Models;

public class ProductCategory
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = null!;
}
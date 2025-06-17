using ProductsInventory.Api.Models;

namespace ProductsInventory.Api.Data.DTOs;

//Data Transfer Object
public class ProductDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; }

    public List<Category>? Categories { get; set; }
}
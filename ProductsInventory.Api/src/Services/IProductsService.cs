using ProductsInventory.Api.Data.DTOs;
using ProductsInventory.Api.Models;
using ProductsInventory.Api.Models.Requests;

namespace ProductsInventory.Api.Services;

public interface IProductsService
{
    // public Product AddProduct(Product product);

    // public Product GetProduct(string id);

    // public List<Product> GetAllProduct();

    // public Product UpdateProduct(Product product,string id);

    // public void DeleteProduct(string id);

    Task<ProductDto> CreateProduct(CreateProductRequest createProduct);
    Task<IEnumerable<ProductDto>> GetAll();
    Task<ProductDto> GetById(Guid id);

     Task<ProductDto> UpdateProduct(Guid id, CreateProductRequest request);
    void DeleteProduct(Guid id);
    // Task<ProductDto> UpdateProduct(Guid id, UpdateProductRequest request);
    // Task<bool> DeleteProductAsync(Guid id);
}
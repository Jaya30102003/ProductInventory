using ProductsInventory.Api.Models;

namespace ProductsInventory.Api.Services;

public interface IProductsService
{
    public Product AddProduct(Product product);

    public Product GetProduct(string id);

    public List<Product> GetAllProduct();

    public Product UpdateProduct(Product product,string id);

    public void DeleteProduct(string id);
}
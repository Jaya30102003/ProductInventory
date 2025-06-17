using ProductsInventory.Api.Models;

namespace ProductsInventory.Api.Repositories;

public interface IProductsRepository
{
    public Product Add(Product product);

    public Product Get(string id);

    public List<Product> GetAll();

    public Product Update(Product product,string id);

    public void Delete(string id);
}
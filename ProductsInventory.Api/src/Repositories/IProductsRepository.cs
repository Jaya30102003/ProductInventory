using ProductsInventory.Api.Models;

namespace ProductsInventory.Api.Repositories;

public interface IProductsRepository
{
    // public Product Add(Product product);

    // public Product Get(string id);

    // public List<Product> GetAll();

    // public Product Update(Product product,string id);

    // public void Delete(string id);

    public Task<Product> Add(Product product);

    public Task<Product> Get(Guid id);
    public Task<IEnumerable<Product>> GetAll();

    public void Delete(Guid id);

    public Task Update(Product product);
}
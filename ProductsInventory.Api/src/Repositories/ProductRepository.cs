using System.Collections.Generic;
using ProductsInventory.Api.Data;
using ProductsInventory.Api.Models;

namespace ProductsInventory.Api.Repositories;

public class ProductsRepository : IProductsRepository
{
    // List<Product> products;
    public ApplicationDbContext _appDbContext;
    public ProductsRepository(ApplicationDbContext appDbContext)
    {
        _appDbContext = appDbContext;   
    }
    public Product Add(Product product)
    {
        _appDbContext.Products.Add(product);
        _appDbContext.SaveChanges();
        return product;
    }

    public void Delete(string id)
    {
        var product = Get(id);
        _appDbContext.Products.Remove(product);
        _appDbContext.SaveChanges();
    }

    public Product Get(string id)
    {
        var product = _appDbContext.Products.Find(id);
        return product;
    }

    public List<Product> GetAll()
    {
        return _appDbContext.Products.ToList<Product>();
    }

    public Product Update(Product product, string id)
    {
        _appDbContext.Products.Update(product);
        _appDbContext.SaveChanges();
        return product;
    }
}
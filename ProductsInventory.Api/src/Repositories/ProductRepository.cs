using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
    public async Task<Product> Add(Product product)
    {
        await _appDbContext.Products.AddAsync(product);
        await _appDbContext.SaveChangesAsync();
        return product;
    }

    // public async void Delete(Guid id)
    // {
    //     var product = Get(id);
    //     _appDbContext.Products.RemoveAsync(product);
    //     _appDbContext.SaveChanges();
    // }

    public async void Delete(Guid id)
    {
        var product = await _appDbContext.Products.FindAsync(id);
        if (product == null)
        {
            return;
        }
        _appDbContext.Products.Remove(product);
        _appDbContext.SaveChanges();
    }

    public async Task<Product> Get(Guid id)
    {
        var product = await _appDbContext.Products.FindAsync(id);
        return product;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _appDbContext.Products.ToListAsync<Product>();
    }

    // public Product Update(Product product, Guid id)
    // {
    //     _appDbContext.Products.Update(product);
    //     _appDbContext.SaveChanges();
    //     return product;
    // }

     public async Task Update(Product product)
    {
        var existingProduct = await _appDbContext.Products.FindAsync(product.Id);
        if (existingProduct is null)
        {
            throw new KeyNotFoundException("Product not found");
        }

        _appDbContext.Entry(existingProduct).CurrentValues.SetValues(product);
        await _appDbContext.SaveChangesAsync();
    }

   
}
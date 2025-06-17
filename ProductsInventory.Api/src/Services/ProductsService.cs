
using ProductsInventory.Api.Models;
using ProductsInventory.Api.Repositories;

namespace ProductsInventory.Api.Services;

public class ProductsService : IProductsService
{
    private IProductsRepository _productRepository;

    public ProductsService(IProductsRepository productsRepository)
    {
        _productRepository = productsRepository;
    }
    public Product AddProduct(Product product)
    {
        Product newProduct = _productRepository.Add(product);
        return newProduct;
    }

    public void DeleteProduct(string id)
    {
        Product product = _productRepository.Get(id);
        if(product == null) {
            throw new Exception("Product Not Found");
        }
        _productRepository.Delete(id);
    }

    public List<Product> GetAllProduct()
    {
        return _productRepository.GetAll();
    }

    public Product GetProduct(string id)
    {
        return _productRepository.Get(id);
    }

    public Product UpdateProduct(Product product, string id)
    {
        Product dbproduct = _productRepository.Get(id);
        if (dbproduct == null)
        {
            throw new Exception("Product Not Found");
        }
        if (product.Name != "")
        {
            dbproduct.Name = product.Name;
        }

        return _productRepository.Update(dbproduct, id);
    }
}
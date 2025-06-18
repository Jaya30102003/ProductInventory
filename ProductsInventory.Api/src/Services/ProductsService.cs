
using AutoMapper;
using ProductsInventory.Api.Data.DTOs;
using ProductsInventory.Api.Models;
using ProductsInventory.Api.Models.Requests;
using ProductsInventory.Api.Repositories;

namespace ProductsInventory.Api.Services;

public class ProductsService : IProductsService
{
    private IProductsRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductsService(IProductsRepository productsRepository, IMapper mapper)
    {
        _productRepository = productsRepository;
        _mapper = mapper;
    }
    // public Product AddProduct(Product product)
    // {
    //     Product newProduct = _productRepository.Add(product);
    //     return newProduct;
    // }
    public async Task<ProductDto> CreateProduct(CreateProductRequest createProduct)
    {
        var product = _mapper.Map<Product>(createProduct);
        await _productRepository.Add(product);
        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }

    // public List<Product> GetAllProduct()
    // {
    //     return _productRepository.GetAll();
    // }

    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        var products = await _productRepository.GetAll();
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        return productDtos;
    }

    // public Product GetProduct(string id)
    // {
    //     return _productRepository.Get(id);
    // }

    public async Task<ProductDto> GetById(Guid id)
    {
        var product = await _productRepository.Get(id);
        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }

    // public void DeleteProduct(Guid id)
    // {
    //     Product product = await _productRepository.Get(id);
    //     if (product == null)
    //     {
    //         throw new Exception("Product Not Found");
    //     }
    //     _productRepository.Delete(id);
    // }

    public async void DeleteProduct(Guid id)
    {
        Product product = await _productRepository.Get(id);
        if (product == null)
        {
            throw new Exception("Product Not Found");
        }
        _productRepository.Delete(id);
    }

    // public Product UpdateProduct(Product product, string id)
    // {
    //     Product dbproduct = _productRepository.Get(id);
    //     if (dbproduct == null)
    //     {
    //         throw new Exception("Product Not Found");
    //     }
    //     if (product.Name != "")
    //     {
    //         dbproduct.Name = product.Name;
    //     }

    //     return _productRepository.Update(dbproduct, id);
    // }

    // public async Task<ProductDto> UpdateProduct(CreateProductRequest createProduct, Guid id)
    // {
    //     var dbproduct = _productRepository.Get(id);
    //     if (dbproduct == null)
    //     {
    //         throw new Exception("Product Not Found");
    //     }
    //     _mapper.Map(createProduct, dbproduct);

    //     await _productRepository.Update(dbproduct);

    //     var productDto = _mapper.Map<ProductDto>(dbproduct);
    //     return productDto;
    // }

    public async Task<ProductDto> UpdateProduct(Guid id, CreateProductRequest request)
    {
        var product = await _productRepository.Get(id);
        if (product == null)
        {
            return null;
        }

        _mapper.Map(request, product);
        await _productRepository.Update(product);

        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }
}

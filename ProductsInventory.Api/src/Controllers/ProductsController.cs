using Microsoft.AspNetCore.Mvc;
using ProductsInventory.Api.Models;
using ProductsInventory.Api.Services;

namespace ProductsInventory.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductsController : ControllerBase
{
    private readonly IProductsService _productsService;

    public ProductsController(IProductsService productsService)
    {
        _productsService = productsService;
    }

    [HttpPost]
    public ActionResult CreateProduct([FromBody] Product product)
    {
        Product newProduct = _productsService.AddProduct(product);
        return Ok(newProduct);
    }

    [HttpGet]
    public ActionResult GetAllProduct()
    {
        IEnumerable<Product> products = _productsService.GetAllProduct();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult GetProduct(string id)
    {
        Product newProduct = _productsService.GetProduct(id);
        return Ok(newProduct);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateProduct(Product product, string id)
    {
        Product newProduct = _productsService.UpdateProduct(product, id);
        return Ok(newProduct);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(string id)
    {
        _productsService.DeleteProduct(id);
        return NoContent();
    }

}
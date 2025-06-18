using Microsoft.AspNetCore.Mvc;
using ProductsInventory.Api.Data.DTOs;
using ProductsInventory.Api.Data.Responses;
using ProductsInventory.Api.Models;
using ProductsInventory.Api.Models.Requests;
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
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
    {
        var result = await _productsService.CreateProduct(request);
        if (result == null)
        {
            return BadRequest(new ApiResponse<ProductDto>(false, "Product Creation Failed", null));
        }
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, new ApiResponse<ProductDto>(true, "Product Created Successfully", result));
    }

    // public ActionResult CreateProduct([FromBody] Product product)
    // {
    //     Product newProduct = _productsService.AddProduct(product);
    //     return Ok(newProduct);
    // }

    // [HttpGet]
    // public ActionResult GetAllProduct()
    // {
    //     IEnumerable<Product> products = _productsService.GetAllProduct();
    //     return Ok(products);
    // }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _productsService.GetAll();
        return Ok(new ApiResponse<IEnumerable<ProductDto>>(true, "Products Fetched Successfully", result));
    }


    // [HttpGet("{id}")]
    // public ActionResult GetProduct(string id)
    // {
    //     Product newProduct = _productsService.GetProduct(id);
    //     return Ok(newProduct);
    // }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _productsService.GetById(id);
        if (result == null)
        {
            return NotFound(new ApiResponse<ProductDto>(false, "Product Not Found", null));
        }
        return Ok(new ApiResponse<ProductDto>(true, "Product Fetched Successfully", result));
    }

    // [HttpPut("{id}")]
    // public ActionResult UpdateProduct(Product product, string id)
    // {
    //     var newProduct = await _productsService.Update(product, id);
    //     return Ok(newProduct);
    // }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> UpdateProduct(Product product, string id)
    // {
    //     var newProduct = await _productsService.Update(product, id);
    //     return Ok(newProduct);
    // }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id,[FromBody]CreateProductRequest createProductRequest)
    {

        var newProduct = await _productsService.UpdateProduct(id,createProductRequest);
        if (newProduct == null)
        {
            return BadRequest(new ApiResponse<ProductDto>(false, "Product Updation Failed", null));
        }
        return Ok(newProduct);
    }

    // [HttpDelete("{id}")]
    // public ActionResult DeleteProduct(string id)
    // {
    //     _productsService.DeleteProduct(id);
    //     return NoContent();
    // }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        _productsService.DeleteProduct(id);
        return NoContent();
    }

}
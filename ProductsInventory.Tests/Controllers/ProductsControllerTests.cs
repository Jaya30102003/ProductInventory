using ProductsInventory.Api.Controllers;
using ProductsInventory.Api.Models;
using Microsoft.AspNetCore.Mvc;

public class ProductControllerTests
{
    [Fact]
    public void ProductAdd_ShouldReturnOk()
    {
        ProductsController productController = new ProductsController();
        var result = productController.CreateProduct(new Product{Id = "123", Name = "Godumai",Quantity = 10, Price = 250.00});
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void ProductGet_ShouldReturnOk(){
        ProductsController productController = new ProductsController();
        var result = productController.GetProduct("123");
        Assert.IsType<OkResult>(result);
    }
}

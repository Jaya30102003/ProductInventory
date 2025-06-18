using ProductsInventory.Api.Models;

namespace ProductsInventory.Api.Data.DTOs;

public class UserDto
{
    public required string Username {get; set;}
    public required string Password { get; set;}

    public required string Role { get; set;}
}
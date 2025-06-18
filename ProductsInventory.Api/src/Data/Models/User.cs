using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
namespace ProductsInventory.Api.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(50)]
    public required string Username { get; set; }
    [Required]
    public string PasswordHash { get; set; }

    public string Role { get; set; }
}
using Microsoft.EntityFrameworkCore;
using ProductsInventory.Api.Models;

namespace ProductsInventory.Api.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
}
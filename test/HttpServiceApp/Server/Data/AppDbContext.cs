using HttpServiceApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpServiceApp.Server.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "C# Book",
                Description = "Best resource for learning C#",
                Price = 15000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "ASP.NET Core Book",
                Description = "Best resource for learning ASP.NET Core",
                Price = 12000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Entity Framework Core Book",
                Description = "Best resource for learning Entity Framework Core",
                Price = 14000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Blazor Book",
                Description = "Best resource for learning Blazor",
                Price = 12000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "RESTful Api Book",
                Description = "Best resource for learning about RESTful Api's",
                Price = 20000
            }
        );
    }
}
using HttpService.Web.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpService.Web.Server.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
}
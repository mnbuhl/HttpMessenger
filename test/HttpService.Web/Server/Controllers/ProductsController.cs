using HttpService.Web.Server.Data;
using HttpService.Web.Server.Dtos;
using HttpService.Web.Server.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HttpService.Web.Server.Controllers;

public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IList<ProductDto>>> Index()
    {
        var products = await _context.Products.Select(p => p.ToDto()).ToListAsync();
        return Ok(products);
    }
}
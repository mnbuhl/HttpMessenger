using HttpServiceApp.Server.Data;
using HttpServiceApp.Server.Extensions;
using HttpServiceApp.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HttpServiceApp.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IList<ProductDto>>> Index()
    {
        var products = await _context.Products.Select(p => p.ToDto()).ToListAsync();
        return Ok(products);
    }
}
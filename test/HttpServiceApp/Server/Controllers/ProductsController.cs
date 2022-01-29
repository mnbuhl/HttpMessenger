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

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> Show(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        
        if (product == null)
            return NotFound();
        

        return Ok(product.ToDto());
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Store(CreateProductDto productDto)
    {
        var product = productDto.FromCreateDto();
        _context.Products.Add(product);

        bool success = await _context.SaveChangesAsync() > 0;
        
        if (!success)
            return BadRequest("Could not create product");
        
        return CreatedAtAction("Show", new { id = product.Id }, product.ToDto());
    }
}
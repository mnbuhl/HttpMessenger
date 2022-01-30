using System.Reflection;
using HttpMessengerApp.Server.Data;
using HttpMessengerApp.Server.Extensions;
using HttpMessengerApp.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HttpMessengerApp.Server.Controllers;

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

    [HttpPut("put/{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateProductDto productDto)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        
        if (product == null)
            return NotFound();

        product.MapFromUpdateDto(productDto);

        bool success = await _context.SaveChangesAsync() > 0;
        
        if (!success)
            return BadRequest("Could not update product");

        return NoContent();
    }
    
    [HttpPatch("patch/{id}")]
    public async Task<IActionResult> Edit(Guid id, UpdateProductDto productDto)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        
        if (product == null)
            return NotFound();
        
        foreach (PropertyInfo prop in productDto.GetType().GetProperties())
        {
            if (prop.GetValue(productDto) != null)
            {
                product.GetType().GetProperty(prop.Name)?.SetValue(product, prop.GetValue(productDto));               
            }
        }
        
        product.UpdatedAt = DateTime.Now;

        bool success = await _context.SaveChangesAsync() > 0;
        
        if (!success)
            return BadRequest("Could not update product");

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            return NotFound();
        
        _context.Products.Remove(product);
        bool success = await _context.SaveChangesAsync() > 0;
        
        if (!success)
            return BadRequest("Could not delete product");
        
        return NoContent();
    }
}
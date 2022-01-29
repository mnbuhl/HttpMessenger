using HttpService.Web.Server.Dtos;
using HttpService.Web.Server.Models;

namespace HttpService.Web.Server.Extensions;

public static class ProductExtensions
{
    public static ProductDto ToDto(this Product product)
    {
        return new ProductDto(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.CreatedAt,
            product.UpdatedAt
        );
    }
    
    public static Product FromDto(this ProductDto product)
    {
        return new Product
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Name,
            Price = product.Price,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt
        };
    }
}
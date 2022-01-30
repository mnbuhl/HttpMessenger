using HttpServiceApp.Server.Models;
using HttpServiceApp.Shared.Dtos;

namespace HttpServiceApp.Server.Extensions;

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
    
    public static Product FromCreateDto(this CreateProductDto product)
    {
        return new Product
        {
            Name = product.Name,
            Description = product.Name,
            Price = product.Price,
        };
    }

    public static Product MapFromUpdateDto(this Product product, UpdateProductDto updateProductDto)
    {
        product.Name = updateProductDto.Name;
        product.Description = updateProductDto.Description;
        product.Price = updateProductDto.Price;
        product.UpdatedAt = DateTime.UtcNow;
        return product;
    }
}
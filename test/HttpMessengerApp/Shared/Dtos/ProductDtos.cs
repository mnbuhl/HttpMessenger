using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HttpMessengerApp.Shared.Dtos;

public record ProductDto(
    Guid Id,
    string? Name,
    string? Description,
    long Price,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public class CreateProductDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public long Price { get; set; }
}

public class UpdateProductDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public long Price { get; set; }
}
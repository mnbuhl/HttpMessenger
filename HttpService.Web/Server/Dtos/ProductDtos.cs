namespace HttpService.Web.Server.Dtos;

public record ProductDto(
    Guid Id,
    string? Name,
    string? Description,
    long Price,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record CreateProductDto(
    string? Name,
    string? Description,
    long Price
);

public record UpdateProductDto(
    Guid Id,
    string? Name,
    string? Description,
    long Price
);
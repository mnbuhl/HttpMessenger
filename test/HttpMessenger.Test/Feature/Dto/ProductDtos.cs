using System;

namespace HttpMessenger.Test.Feature.Dto;

public record CreateProductDto(string Name, string Description, decimal Price);
public record UpdateProductDto(string Id, string Name, string Description, decimal Price);
public record ProductDto(string Id, string Name, string Description, decimal Price, DateTime CreatedAt);
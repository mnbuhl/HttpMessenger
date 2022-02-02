using System;

namespace HttpMessenger.Test.Models;

public class Product
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public long Price { get; set; }
    public DateTime CreatedAt { get; set; }
}
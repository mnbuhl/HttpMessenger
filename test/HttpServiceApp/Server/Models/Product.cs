namespace HttpServiceApp.Server.Models;

public class Product : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public long Price { get; set; }
}
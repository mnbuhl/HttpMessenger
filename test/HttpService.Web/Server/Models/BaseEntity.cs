using System.ComponentModel.DataAnnotations.Schema;

namespace HttpService.Web.Server.Models;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    
    [Column(Order = int.MaxValue)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    [Column(Order = int.MaxValue)]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
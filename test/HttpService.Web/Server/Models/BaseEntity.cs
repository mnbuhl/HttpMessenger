﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HttpService.Web.Server.Models;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
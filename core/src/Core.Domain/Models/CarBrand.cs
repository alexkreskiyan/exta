using System;
using Core.Domain.Interfaces;

namespace Core.Domain.Models;

public sealed record CarBrand : IIdEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
}

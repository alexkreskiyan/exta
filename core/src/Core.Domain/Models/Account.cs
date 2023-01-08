using System;
using Core.Domain.Interfaces;

namespace Core.Domain.Models;

public sealed record Account : IIdEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;
    public decimal Sum { get; set; }
}

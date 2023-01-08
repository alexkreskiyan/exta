using System;
using Core.Domain.Enums;
using Core.Domain.Interfaces;

namespace Core.Domain.Models;

public sealed record Category : IIdEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public PaymentCategoryDirection Direction { get; set; }
    public PaymentCategoryType Type { get; set; }
    public string Name { get; set; } = string.Empty;
    public uint Order { get; set; }
}

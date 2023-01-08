using System;
using Core.Domain.Interfaces;

namespace Core.Domain.Models;

public sealed record CarDriver : IIdEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Car Car { get; set; } = default!;
    public Driver Driver { get; set; } = default!;
}

using System;
using Core.Domain.Interfaces;
using NodaTime;

namespace Core.Domain.Models;

public abstract record EntityBase : IIdEntity
{
    public Guid Id { get; protected init; }
    public Instant CreatedAt { get; protected init; }
    public Instant UpdatedAt { get; protected set; }
}

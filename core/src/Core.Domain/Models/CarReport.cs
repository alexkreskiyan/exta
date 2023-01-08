using System;
using Core.Domain.Interfaces;

namespace Core.Domain.Models;

public sealed record CarReport : IIdEntity
{
    public Guid Id { get; private init; }
}

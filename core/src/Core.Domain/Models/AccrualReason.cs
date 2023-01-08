using System;
using Core.Domain.Enums;
using Core.Domain.Interfaces;

namespace Core.Domain.Models;

public sealed record AccrualReason : IIdEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public AccrualReasonType Type { get; set; }
    public string Name { get; set; } = string.Empty;
}

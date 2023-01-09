using System;
using Annium.Serialization.Abstractions.Attributes;
using Core.Domain.Enums;
using NodaTime;

namespace Core.Domain.Models;

public sealed record AccrualReason : EntityBase
{
    public AccrualReasonType Type { get; private set; }
    public string Name { get; private set; } = string.Empty;

    public AccrualReason(
        AccrualReasonType type,
        string name,
        Instant moment
    )
    {
        Id = Guid.NewGuid();
        Type = type;
        Name = name;
        CreatedAt = moment;
    }

    [DeserializationConstructor]
    internal AccrualReason()
    {
    }

    public void Update(
        AccrualReasonType type,
        string name,
        Instant moment
    )
    {
        Type = type;
        Name = name;
        UpdatedAt = moment;
    }
}

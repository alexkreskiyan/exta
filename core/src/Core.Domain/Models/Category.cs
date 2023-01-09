using System;
using Annium.Serialization.Abstractions.Attributes;
using Core.Domain.Enums;
using NodaTime;

namespace Core.Domain.Models;

public sealed record Category : EntityBase
{
    public PaymentCategoryDirection Direction { get; private set; }
    public PaymentCategoryType Type { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public uint Order { get; private set; }

    public Category(
        PaymentCategoryDirection direction,
        PaymentCategoryType type,
        string name,
        uint order,
        Instant moment
    )
    {
        Id = Guid.NewGuid();
        Direction = direction;
        Type = type;
        Name = name;
        Order = order;
        CreatedAt = moment;
    }

    [DeserializationConstructor]
    internal Category()
    {
    }

    public void Update(
        PaymentCategoryDirection direction,
        PaymentCategoryType type,
        string name,
        uint order,
        Instant moment
    )
    {
        Direction = direction;
        Type = type;
        Name = name;
        Order = order;
        UpdatedAt = moment;
    }
}

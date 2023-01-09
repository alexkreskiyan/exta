using System;
using Annium.Serialization.Abstractions.Attributes;
using NodaTime;

namespace Core.Domain.Models;

public sealed record CarBrand : EntityBase
{
    public string Name { get; private set; } = string.Empty;

    public CarBrand(
        string name,
        Instant moment
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = moment;
    }

    [DeserializationConstructor]
    internal CarBrand()
    {
    }

    public void Update(
        string name,
        Instant moment
    )
    {
        Name = name;
        UpdatedAt = moment;
    }
}

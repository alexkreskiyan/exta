using System;
using Annium.Serialization.Abstractions.Attributes;
using NodaTime;

namespace Core.Domain.Models;

public sealed record CarReport : EntityBase
{
    public Guid CarId { get; private set; }
    public Car Car { get; private set; } = default!;
    public uint Mileage { get; private set; }

    public CarReport(
        Car car,
        uint mileage,
        Instant moment
    )
    {
        Id = Guid.NewGuid();
        CarId = car.Id;
        Car = car;
        Mileage = mileage;
        CreatedAt = moment;
    }

    [DeserializationConstructor]
    internal CarReport()
    {
    }

    public void Update(
        Car car,
        uint mileage,
        Instant moment
    )
    {
        CarId = car.Id;
        Car = car;
        Mileage = mileage;
        UpdatedAt = moment;
    }
}

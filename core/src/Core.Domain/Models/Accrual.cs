using System;
using Annium.Serialization.Abstractions.Attributes;
using NodaTime;

namespace Core.Domain.Models;

public sealed record Accrual : EntityBase
{
    public DateOnly Date { get; private set; }
    public Guid ReasonId { get; private set; }
    public AccrualReason Reason { get; private set; } = default!;
    public Guid? CarId { get; private set; }
    public Car? Car { get; private set; }
    public Guid DriverId { get; private set; }
    public Driver Driver { get; private set; } = default!;
    public decimal Sum { get; private set; }
    public string Comment { get; private set; } = string.Empty;

    public Accrual(
        DateOnly date,
        AccrualReason reason,
        Car car,
        Driver driver,
        decimal sum,
        string comment,
        Instant moment
    )
    {
        Id = Guid.NewGuid();
        Date = date;
        ReasonId = reason.Id;
        Reason = reason;
        CarId = car.Id;
        Car = car;
        DriverId = driver.Id;
        Driver = driver;
        Sum = sum;
        Comment = comment;
        CreatedAt = moment;
    }

    public Accrual(
        DateOnly date,
        AccrualReason reason,
        Driver driver,
        decimal sum,
        string comment,
        Instant moment
    )
    {
        Id = Guid.NewGuid();
        Date = date;
        ReasonId = reason.Id;
        Reason = reason;
        DriverId = driver.Id;
        Driver = driver;
        Sum = sum;
        Comment = comment;
        CreatedAt = moment;
    }

    [DeserializationConstructor]
    internal Accrual()
    {
    }

    public void Update(
        DateOnly date,
        AccrualReason reason,
        Car car,
        Driver driver,
        decimal sum,
        string comment,
        Instant moment
    )
    {
        Date = date;
        ReasonId = reason.Id;
        Reason = reason;
        CarId = car.Id;
        Car = car;
        DriverId = driver.Id;
        Driver = driver;
        Sum = sum;
        Comment = comment;
        UpdatedAt = moment;
    }
}

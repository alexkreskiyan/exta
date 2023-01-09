using System;
using Annium.Serialization.Abstractions.Attributes;
using NodaTime;

namespace Core.Domain.Models;

public sealed record Payment : EntityBase
{
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; } = default!;
    public Guid? CarId { get; private set; }
    public Car? Car { get; private set; }
    public decimal Sum { get; private set; }
    public string Comment { get; private set; } = string.Empty;

    public Payment(
        Category category,
        Car? car,
        decimal sum,
        string comment,
        Instant moment
    )
    {
        Id = Guid.NewGuid();
        CategoryId = category.Id;
        Category = category;
        CarId = car?.Id;
        Car = car;
        Sum = sum;
        Comment = comment;
        CreatedAt = moment;
    }

    [DeserializationConstructor]
    internal Payment()
    {
    }

    public void Update(
        Category category,
        Car? car,
        decimal sum,
        string comment,
        Instant moment
    )
    {
        CategoryId = category.Id;
        Category = category;
        CarId = car?.Id;
        Car = car;
        Sum = sum;
        Comment = comment;
        UpdatedAt = moment;
    }
}

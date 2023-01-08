using System;
using Core.Domain.Interfaces;

namespace Core.Domain.Models;

public sealed record Payment : IIdEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = default!;
    public Guid AccountId { get; set; }
    public Account Account { get; set; } = default!;
    public Guid? CarId { get; set; }
    public Car Car { get; set; } = default!;
    public DateTime Date { get; set; }
    public decimal Sum { get; set; }
    public string Comment { get; set; } = string.Empty;
}

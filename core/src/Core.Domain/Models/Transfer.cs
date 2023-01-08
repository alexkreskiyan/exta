using System;
using Core.Domain.Interfaces;

namespace Core.Domain.Models;

public sealed record Transfer : IIdEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Date { get; set; }
    public Guid FromId { get; set; }
    public Account From { get; set; } = default!;
    public Guid ToId { get; set; }
    public Account To { get; set; } = default!;
    public decimal Sum { get; set; }
    public string Comment { get; set; } = string.Empty;
}

using System;
using Core.Domain.Interfaces;

namespace Core.Domain.Models;

public sealed record DayOff : IIdEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Date { get; set; }
    public Guid ReasonId { get; set; }
    public AccrualReason Reason { get; set; } = default!;
    public Guid DriverContractId { get; set; }
    public DriverContract DriverContract { get; set; } = default!;
    public string Comment { get; set; } = string.Empty;
}

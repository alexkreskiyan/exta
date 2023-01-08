using System;
using Core.Domain.Interfaces;

namespace Core.Domain.Models;

public sealed record DriverContract : IIdEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid DriverId { get; set; }
    public Driver Driver { get; set; } = default!;
    public Guid CarId { get; set; }
    public Car Car { get; set; } = default!;
    public bool IsBuyout { get; set; }
    public DateTime SignDate { get; set; }
    public uint Duration { get; set; }
    public DateTime? TerminationDate { get; set; }
    public decimal RentPerDay { get; set; }
    public decimal BuyoutPerDay { get; set; }
    public bool SundayOff { get; set; }
    public decimal CarPledgePrice { get; set; }
    public decimal CarBuyoutPrice { get; set; }
    public decimal Pledge { get; set; }
    public decimal CarBuyoutLeft { get; set; }
    public decimal GeneralDebt { get; set; }
    public decimal RentDebt { get; set; }
    public decimal BuyoutDebt { get; set; }
    public bool IsActive => TerminationDate is null;
}

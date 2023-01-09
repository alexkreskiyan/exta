using System;
using Annium.Serialization.Abstractions.Attributes;
using NodaTime;

namespace Core.Domain.Models;

public sealed record DriverContract : EntityBase
{
    public Guid DriverId { get; private set; }
    public Driver Driver { get; private set; } = default!;
    public Guid CarId { get; private set; }
    public Car Car { get; private set; } = default!;
    public bool IsBuyout { get; private set; }
    public DateOnly SignDate { get; private set; }
    public uint Duration { get; private set; }
    public DateOnly? TerminationDate { get; private set; }
    public decimal RentPerDay { get; private set; }
    public decimal BuyoutPerDay { get; private set; }
    public bool SundayOff { get; private set; }
    public decimal CarPledgePrice { get; private set; }
    public decimal CarBuyoutPrice { get; private set; }
    public decimal Pledge { get; private set; }
    public decimal CarBuyoutLeft { get; private set; }
    public decimal GeneralDebt { get; private set; }
    public decimal RentDebt { get; private set; }
    public decimal BuyoutDebt { get; private set; }
    public bool IsActive => TerminationDate is null;

    public DriverContract(
        Driver driver,
        Car car,
        bool isBuyout,
        DateOnly signDate,
        uint duration,
        DateOnly? terminationDate,
        decimal rentPerDay,
        decimal buyoutPerDay,
        bool sundayOff,
        decimal carPledgePrice,
        decimal carBuyoutPrice,
        decimal pledge,
        decimal carBuyoutLeft,
        decimal generalDebt,
        decimal rentDebt,
        decimal buyoutDebt,
        Instant moment
    )
    {
        Id = Guid.NewGuid();
        DriverId = driver.Id;
        Driver = driver;
        CarId = car.Id;
        Car = car;
        IsBuyout = isBuyout;
        SignDate = signDate;
        Duration = duration;
        TerminationDate = terminationDate;
        RentPerDay = rentPerDay;
        BuyoutPerDay = buyoutPerDay;
        SundayOff = sundayOff;
        CarPledgePrice = carPledgePrice;
        CarBuyoutPrice = carBuyoutPrice;
        Pledge = pledge;
        CarBuyoutLeft = carBuyoutLeft;
        GeneralDebt = generalDebt;
        RentDebt = rentDebt;
        BuyoutDebt = buyoutDebt;
        CreatedAt = moment;
    }

    [DeserializationConstructor]
    internal DriverContract()
    {
    }

    public void Update(
        Driver driver,
        Car car,
        bool isBuyout,
        DateOnly signDate,
        uint duration,
        DateOnly? terminationDate,
        decimal rentPerDay,
        decimal buyoutPerDay,
        bool sundayOff,
        decimal carPledgePrice,
        decimal carBuyoutPrice,
        decimal pledge,
        decimal carBuyoutLeft,
        decimal generalDebt,
        decimal rentDebt,
        decimal buyoutDebt,
        Instant moment
    )
    {
        DriverId = driver.Id;
        Driver = driver;
        CarId = car.Id;
        Car = car;
        IsBuyout = isBuyout;
        SignDate = signDate;
        Duration = duration;
        TerminationDate = terminationDate;
        RentPerDay = rentPerDay;
        BuyoutPerDay = buyoutPerDay;
        SundayOff = sundayOff;
        CarPledgePrice = carPledgePrice;
        CarBuyoutPrice = carBuyoutPrice;
        Pledge = pledge;
        CarBuyoutLeft = carBuyoutLeft;
        GeneralDebt = generalDebt;
        RentDebt = rentDebt;
        BuyoutDebt = buyoutDebt;
        UpdatedAt = moment;
    }
}

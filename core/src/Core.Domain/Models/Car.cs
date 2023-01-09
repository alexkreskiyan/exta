using System;
using Annium.Serialization.Abstractions.Attributes;
using NodaTime;

namespace Core.Domain.Models;

public sealed record Car : EntityBase
{
    public Guid BrandId { get; private set; }
    public CarBrand Brand { get; private set; } = default!;
    public bool IsActive { get; private set; }

    public decimal CarPledgePrice { get; private set; }
    public decimal CarBuyoutPrice { get; private set; }
    public decimal Pledge { get; private set; }
    public decimal RentPerDay { get; private set; }
    public decimal BuyoutPerDay { get; private set; }
    public bool SundayOff { get; private set; }

    public uint InitialMileage { get; private set; }
    public string Type { get; private set; } = string.Empty;
    public string Color { get; private set; } = string.Empty;
    public uint BuiltYear { get; private set; }
    public string GovernmentNumber { get; private set; } = string.Empty;
    public string Vin { get; private set; } = string.Empty;
    public string EngineNumber { get; private set; } = string.Empty;
    public string EngineType { get; private set; } = string.Empty;
    public string EnginePower { get; private set; } = string.Empty;
    public string BodyNumber { get; private set; } = string.Empty;
    public string PassportNumber { get; private set; } = string.Empty;
    public string PassportIssuer { get; private set; } = string.Empty;
    public DateOnly PassportIssueDate { get; private set; }
    public string RegistrationNumber { get; private set; } = string.Empty;
    public string RegistrationIssuer { get; private set; } = string.Empty;
    public DateOnly RegistrationIssueDate { get; private set; }

    public Car(
        CarBrand brand,
        bool isActive,
        decimal carPledgePrice,
        decimal carBuyoutPrice,
        decimal pledge,
        decimal rentPerDay,
        decimal buyoutPerDay,
        bool sundayOff,
        uint initialMileage,
        string type,
        string color,
        uint builtYear,
        string governmentNumber,
        string vin,
        string engineNumber,
        string engineType,
        string enginePower,
        string bodyNumber,
        string passportNumber,
        string passportIssuer,
        DateOnly passportIssueDate,
        string registrationNumber,
        string registrationIssuer,
        DateOnly registrationIssueDate,
        Instant moment
    )
    {
        Id = Guid.NewGuid();
        BrandId = brand.Id;
        Brand = brand;
        IsActive = isActive;
        CarPledgePrice = carPledgePrice;
        CarBuyoutPrice = carBuyoutPrice;
        Pledge = pledge;
        RentPerDay = rentPerDay;
        BuyoutPerDay = buyoutPerDay;
        SundayOff = sundayOff;
        InitialMileage = initialMileage;
        Type = type;
        Color = color;
        BuiltYear = builtYear;
        GovernmentNumber = governmentNumber;
        Vin = vin;
        EngineNumber = engineNumber;
        EngineType = engineType;
        EnginePower = enginePower;
        BodyNumber = bodyNumber;
        PassportNumber = passportNumber;
        PassportIssueDate = passportIssueDate;
        PassportIssuer = passportIssuer;
        RegistrationNumber = registrationNumber;
        RegistrationIssuer = registrationIssuer;
        RegistrationIssueDate = registrationIssueDate;
        CreatedAt = moment;
    }

    [DeserializationConstructor]
    internal Car()
    {
    }

    public void Update(
        CarBrand brand,
        bool isActive,
        decimal carPledgePrice,
        decimal carBuyoutPrice,
        decimal pledge,
        decimal rentPerDay,
        decimal buyoutPerDay,
        bool sundayOff,
        uint initialMileage,
        string type,
        string color,
        uint builtYear,
        string governmentNumber,
        string vin,
        string engineNumber,
        string engineType,
        string enginePower,
        string bodyNumber,
        string passportNumber,
        string passportIssuer,
        DateOnly passportIssueDate,
        string registrationNumber,
        string registrationIssuer,
        DateOnly registrationIssueDate,
        Instant moment
    )
    {
        BrandId = brand.Id;
        Brand = brand;
        IsActive = isActive;
        CarPledgePrice = carPledgePrice;
        CarBuyoutPrice = carBuyoutPrice;
        Pledge = pledge;
        RentPerDay = rentPerDay;
        BuyoutPerDay = buyoutPerDay;
        SundayOff = sundayOff;
        InitialMileage = initialMileage;
        Type = type;
        Color = color;
        BuiltYear = builtYear;
        GovernmentNumber = governmentNumber;
        Vin = vin;
        EngineNumber = engineNumber;
        EngineType = engineType;
        EnginePower = enginePower;
        BodyNumber = bodyNumber;
        PassportNumber = passportNumber;
        PassportIssueDate = passportIssueDate;
        PassportIssuer = passportIssuer;
        RegistrationNumber = registrationNumber;
        RegistrationIssuer = registrationIssuer;
        RegistrationIssueDate = registrationIssueDate;
        UpdatedAt = moment;
    }
}

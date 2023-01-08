using System;
using Core.Domain.Interfaces;

namespace Core.Domain.Models;

public sealed record Car : IIdEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid BrandId { get; set; }
    public CarBrand Brand { get; set; } = default!;
    public string GovernmentNumber { get; set; } = string.Empty;
    public string Vin { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public uint BuiltYear { get; set; }
    public string EngineNumber { get; set; } = string.Empty;
    public string EngineType { get; set; } = string.Empty;
    public string EnginePower { get; set; } = string.Empty;
    public string BodyNumber { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string PassportNumber { get; set; } = string.Empty;
    public DateTime PassportIssueDate { get; set; }
    public string PassportIssuer { get; set; } = string.Empty;
    public string RegistrationNumber { get; set; } = string.Empty;
    public DateTime RegistrationIssueDate { get; set; }
    public string RegistrationIssuer { get; set; } = string.Empty;
    public uint Mileage { get; set; }
    public bool IsActive { get; set; }
}

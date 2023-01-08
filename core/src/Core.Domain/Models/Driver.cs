using System;
using Core.Domain.Interfaces;

namespace Core.Domain.Models;

public sealed record Driver : IIdEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public User User { get; set; } = default!;
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
    public string PassportNumber { get; set; } = string.Empty;
    public string RegistrationAddress { get; set; } = string.Empty;
    public string LiveAddress { get; set; } = string.Empty;
    public string LicenseNumber { get; set; } = string.Empty;
    public DateTime LicenseIssueDate { get; set; }
    public string LicenseIssuer { get; set; } = string.Empty;
}

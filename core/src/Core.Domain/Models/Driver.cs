using System;
using Annium.Serialization.Abstractions.Attributes;
using NodaTime;

namespace Core.Domain.Models;

public sealed record Driver : EntityBase
{
    public Guid UserId { get; private set; }
    public User User { get; private set; } = default!;
    public string LastName { get; private set; } = string.Empty;
    public string FirstName { get; private set; } = string.Empty;
    public string MiddleName { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public DateOnly Birthday { get; private set; }
    public string PassportNumber { get; private set; } = string.Empty;
    public string RegistrationAddress { get; private set; } = string.Empty;
    public string LiveAddress { get; private set; } = string.Empty;
    public string LicenseNumber { get; private set; } = string.Empty;
    public string LicenseIssuer { get; private set; } = string.Empty;
    public DateOnly LicenseIssueDate { get; private set; }

    public Driver(
        User user,
        string lastName,
        string firstName,
        string middleName,
        string phone,
        DateOnly birthday,
        string passportNumber,
        string registrationAddress,
        string liveAddress,
        string licenseNumber,
        string licenseIssuer,
        DateOnly licenseIssueDate,
        Instant moment
    )
    {
        Id = Guid.NewGuid();
        UserId = user.Id;
        User = user;
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
        Phone = phone;
        Birthday = birthday;
        PassportNumber = passportNumber;
        RegistrationAddress = registrationAddress;
        LiveAddress = liveAddress;
        LicenseNumber = licenseNumber;
        LicenseIssuer = licenseIssuer;
        LicenseIssueDate = licenseIssueDate;
        CreatedAt = moment;
    }

    [DeserializationConstructor]
    internal Driver()
    {
    }

    public void Update(
        User user,
        string lastName,
        string firstName,
        string middleName,
        string phone,
        DateOnly birthday,
        string passportNumber,
        string registrationAddress,
        string liveAddress,
        string licenseNumber,
        string licenseIssuer,
        DateOnly licenseIssueDate,
        Instant moment
    )
    {
        UserId = user.Id;
        User = user;
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
        Phone = phone;
        Birthday = birthday;
        PassportNumber = passportNumber;
        RegistrationAddress = registrationAddress;
        LiveAddress = liveAddress;
        LicenseNumber = licenseNumber;
        LicenseIssuer = licenseIssuer;
        LicenseIssueDate = licenseIssueDate;
        UpdatedAt = moment;
    }
}

using System;
using Annium.Serialization.Abstractions.Attributes;
using Core.Domain.Enums;
using NodaTime;

namespace Core.Domain.Models;

public sealed record User : EntityBase
{
    public UserType Type { get; private set; }
    public string Login { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }

    public User(
        UserType type,
        string login,
        string password,
        bool isActive,
        Instant moment
    )
    {
        Id = Guid.NewGuid();
        Type = type;
        Login = login;
        Password = password;
        IsActive = isActive;
        CreatedAt = moment;
    }

    [DeserializationConstructor]
    internal User()
    {
    }

    public void Update(
        UserType type,
        string login,
        string password,
        bool isActive,
        Instant moment
    )
    {
        Type = type;
        Login = login;
        Password = password;
        IsActive = isActive;
        UpdatedAt = moment;
    }
}

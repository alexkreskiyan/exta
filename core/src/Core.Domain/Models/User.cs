using System;
using Core.Domain.Enums;
using Core.Domain.Interfaces;

namespace Core.Domain.Models;

public sealed record User : IIdEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public UserType Type { get; set; }
    public int UserId { get; set; }
}

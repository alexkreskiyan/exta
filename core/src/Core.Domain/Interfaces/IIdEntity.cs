using System;

namespace Core.Domain.Interfaces;

public interface IIdEntity : IEntity
{
    public Guid Id { get; }
}
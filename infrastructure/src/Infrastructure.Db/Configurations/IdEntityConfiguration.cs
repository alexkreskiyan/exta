using Annium.linq2db.Extensions.Configuration;
using Core.Domain.Interfaces;
using LinqToDB.Mapping;

namespace Infrastructure.Db.Configurations;

public abstract class IdEntityConfiguration<TEntity> : IEntityConfiguration<TEntity>
    where TEntity : class, IIdEntity
{
    public virtual void Configure(EntityMappingBuilder<TEntity> builder)
    {
        builder.HasPrimaryKey(x => x.Id);
        builder.Property(x => x.Id).IsColumn();
    }
}
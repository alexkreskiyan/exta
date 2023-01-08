using System;
using Annium.Configuration.Abstractions;
using Annium.Core.DependencyInjection;
using Annium.linq2db.Extensions.Models;
using Annium.Logging.Abstractions;
using Npgsql;

namespace Infrastructure.Db;

public static class ServiceContainerExtensions
{
    public static IServiceContainer AddDbConfiguration(this IServiceContainer container, string path)
    {
        return container.AddConfiguration<ConnectionConfiguration>(x => x
            .AddYamlFile(path)
        );
    }

    public static IServiceContainer AddDataConnection<TConnection>(this IServiceContainer container, IServiceProvider sp)
        where TConnection : DataConnectionBase, ILogSubject<TConnection>
    {
        NpgsqlConnection.GlobalTypeMapper.UseNodaTime();

        return container.AddPostgreSql<TConnection>(sp.Resolve<ConnectionConfiguration>());
    }
}
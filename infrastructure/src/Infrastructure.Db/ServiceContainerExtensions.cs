using System;
using Annium.Configuration.Abstractions;
using Annium.Core.DependencyInjection;
using Annium.linq2db.Extensions.Models;
using Annium.Logging.Abstractions;

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
        return container.AddPostgreSql<TConnection>(sp.Resolve<ConnectionConfiguration>());
    }
}

using System;
using System.IO;
using Annium.Core.DependencyInjection;
using Infrastructure.Db;

namespace Server.Db;

public class ServicePack : ServicePackBase
{
    public override void Configure(IServiceContainer container)
    {
        container.AddDbConfiguration(Path.Combine("configuration", "db.yml"));
    }

    public override void Register(IServiceContainer container, IServiceProvider provider)
    {
        container.AddDataConnection<ServerConnection>(provider);
    }
}

using System;
using Annium.Core.DependencyInjection;

namespace Server.Db.Migrator;

internal class ServicePack : ServicePackBase
{
    public override void Configure(IServiceContainer container)
    {
        // register configurations
    }

    public override void Register(IServiceContainer container, IServiceProvider provider)
    {
        // register and setup services
    }

    public override void Setup(IServiceProvider provider)
    {
        // setup post-configured services
    }
}
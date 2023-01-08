using System;
using Annium.Core.DependencyInjection;

namespace Server.Host;

internal class TestServicePack : ServicePackBase
{
    public TestServicePack()
    {
        Add<BaseServicePack>();
    }

    public override void Configure(IServiceContainer container)
    {
        container.AddConfiguration(new Configuration());
    }

    public override void Register(IServiceContainer container, IServiceProvider provider)
    {
        container.AddHttpRequestFactory().SetDefault();
    }
}

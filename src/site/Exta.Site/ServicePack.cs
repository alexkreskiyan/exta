using System;
using Annium.Core.DependencyInjection;

namespace Exta.Site;

public class ServicePack : ServicePackBase
{
    public override void Register(IServiceContainer container, IServiceProvider provider)
    {
        // core
        container.AddRuntime(GetType().Assembly);
        container.AddTime().WithRealTime().SetDefault();
        container.AddMapper();
        container.AddHttpRequestFactory();
        container.AddComponentFormStateFactory();
        container.AddValidation();
        container.AddLocalization(opts => opts.UseInMemoryStorage(Locale.Data));
        container.AddCss();
        container.AddHostHttpRequestFactory();
        // services.AddLogging(route => route.UseConsole());

        // app
        container.AddAntDesign();
        container.AddSerializers()
            .WithJson(opts =>
            {
                opts.ConfigureForOperations();
                opts.ConfigureForNodaTime();
                opts.UseCamelCaseNamingPolicy();
            }, isDefault: true);
        container.Add<Theme>().AsSelf().Singleton();
        container.AddStorages();
        container.AddApiServices();
    }
}

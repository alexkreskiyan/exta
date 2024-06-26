using System;
using System.Collections.Immutable;
using System.Linq;
using Annium.Core.DependencyInjection;
using Annium.Core.Mediator;
using Annium.Core.Runtime.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Server.Host;

internal class BaseServicePack : ServicePackBase
{
    private static readonly ImmutableHashSet<string> Ignore = ImmutableHashSet.Create(
        "ChainBuilder",
        "PipeHandler"
    );

    public override void Configure(IServiceContainer container)
    {
        container.AddRuntime(GetType().Assembly);
    }

    public override void Register(IServiceContainer container, IServiceProvider provider)
    {
        container.AddTime().WithRealTime().SetDefault();
        container.AddResourceLoader();
        container.AddLogging();
        container.AddMediator();
        container.AddMediatorConfiguration(ConfigureMediator);
        container.AddValidation();
        container.AddComposition();
        container.AddLocalization(opts => opts.UseYamlStorage());
        container.AddMapper();
        container.AddSerializers()
            .WithJson(opts => opts.ConfigureForOperations().ConfigureForNodaTime());

        // server
        container.Collection.AddCors();
        container.Collection.AddControllers()
            .AddDefaultJsonOptions();
        container.AddXRest();
    }

    public override void Setup(IServiceProvider provider)
    {
        provider.UseLogging(route => route
            .For(m => !Ignore.Any(m.Source.Contains))
            .UseConsole());
    }

    private void ConfigureMediator(MediatorConfiguration cfg, ITypeManager tm)
    {
        cfg.AddLoggingHandler();
        cfg.AddHttpStatusPipeHandler();
        cfg.AddExceptionHandler();
        cfg.AddValidationHandler();
        cfg.AddViewMappingHandlers();
        cfg.AddCompositionHandler();

        cfg.AddCommandQueryHandlers(tm);
    }
}

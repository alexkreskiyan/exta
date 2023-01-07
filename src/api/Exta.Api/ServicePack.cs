using System;
using System.Collections.Immutable;
using System.Linq;
using Annium.Core.DependencyInjection;
using Annium.Core.Mediator;
using Annium.Core.Runtime.Types;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;

namespace Exta.Api;

internal class ServicePack : ServicePackBase
{
    private static readonly ImmutableHashSet<string> Ignore = ImmutableHashSet.Create(
        "ChainBuilder",
        "PipeHandler"
    );

    public override void Configure(IServiceCollection services)
    {
        services.AddRuntimeTools(GetType().Assembly, true);
    }

    public override void Register(IServiceCollection services, IServiceProvider provider)
    {
        services.AddSingleton<Func<Instant>>(SystemClock.Instance.GetCurrentInstant);
        services.AddResourceLoader();
        services.AddLogging(route => route
            .For(m => !Ignore.Any(m.Source.Name.Contains))
            .UseConsole());
        services.AddMediator();
        services.AddMediatorConfiguration(ConfigureMediator);
        services.AddValidation();
        services.AddComposition();
        services.AddLocalization(opts => opts.UseYamlStorage());
        services.AddMapper();
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

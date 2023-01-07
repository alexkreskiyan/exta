using Annium.Core.DependencyInjection;

namespace Exta.Api;

public class Configuration
{
    public WebHostConfiguration Host { get; set; } = new();
}

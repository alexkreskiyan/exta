using Annium.Core.DependencyInjection;

namespace Exta.Api;

public class HostConfiguration
{
    public WebHostConfiguration Host { get; set; } = new();
}

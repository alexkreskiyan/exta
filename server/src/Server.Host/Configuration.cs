using Annium.Core.DependencyInjection;

namespace Server.Host;

public class Configuration
{
    public WebHostConfiguration Host { get; set; } = new();
}

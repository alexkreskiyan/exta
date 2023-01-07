using System.Threading.Tasks;
using Annium.Blazor.Core.Extensions;
using Annium.Core.DependencyInjection;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Exta.Site;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("app");
        builder.UseServicePack<ServicePack>();
        // builder.ConfigureContainer(new ServiceProviderFactory(x => x.UseServicePack<ServicePack>()));
        // await builder.Services.AddConfiguration<Shared.Configuration>(cfg => cfg.AddRemoteYaml($"{builder.HostEnvironment.BaseAddress}site.yml"));
        builder.Logging.ConfigureLoggingBridge();
        await builder.Build().RunAsync();
    }
}

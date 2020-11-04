using System.Threading.Tasks;
using Annium.Core.DependencyInjection;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Exta.Site
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.ConfigureContainer(new ServiceProviderFactory(x => x.UseServicePack<ServicePack>()));
            await builder.Build().RunAsync();
        }
    }
}
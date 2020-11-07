using System.IO;
using Annium.Configuration.Abstractions;
using Annium.Core.DependencyInjection;
using Exta.Api.Configurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Exta.Api
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostConfiguration = Configurator.Get<HostConfiguration>(x => x.AddCommandLineArgs(), true);

            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new ServiceProviderFactory(b => b.UseServicePack<ServicePack>()))
                .ConfigureLoggingBridge()
                .ConfigureWebHostDefaults(builder =>
                {
                    builder
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseKestrel(server =>
                        {
                            server.AddServerHeader = false;
                            server.ListenAnyIP(hostConfiguration.Port, listen =>
                            {
                                var certFile = Path.GetFullPath(Path.Combine("certs", "cert.pfx"));
                                if (File.Exists(certFile))
                                    listen.UseHttps(certFile);
                            });
                        })
                        .UseStartup<Startup>();
                });
        }
    }
}
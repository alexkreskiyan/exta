using System;
using Annium.Core.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Exta.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers()
                .AddDefaultJsonOptions();
            services.AddXRest();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseExceptionMiddleware();
            app.UseXRest();

            app.UseRouting();
            app.UseCors(builder => builder
                .SetIsOriginAllowed(o => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .SetPreflightMaxAge(TimeSpan.FromDays(7)));
            app.UseRequestLocalization("en", "ru");
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
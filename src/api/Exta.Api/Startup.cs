using System;
using System.Linq;
using Annium.Core.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace Exta.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers()
                .AddDefaultJsonOptions();
            services.AddOpenApiDocument(doc =>
            {
                var securityScheme = new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                };
                doc.AddSecurity("JWT", Enumerable.Empty<string>(), securityScheme);

                doc.OperationProcessors
                    .Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseExceptionMiddleware();
            if (env.IsDevelopment())
            {
                app.UseStaticFiles();
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }
            app.UseRouting();
            app.UseCors(builder => builder
                .SetIsOriginAllowed(o => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .SetPreflightMaxAge(TimeSpan.FromDays(7)));
            app.UseRequestLocalization("en", "ru");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
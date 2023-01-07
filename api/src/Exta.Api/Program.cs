using Annium.Core.DependencyInjection;
using Exta.Api;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServicePack<ServicePack>();
builder.Logging.ConfigureLoggingBridge();
builder.WebHost.UseKestrelDefaults();

var app = builder.Build();

app.UseExceptionMiddleware();
app.UseXRest();
app.UseRouting();
app.UseCorsDefaults();
app.UseRequestLocalization("en", "ru");
app.MapControllers();

await app.RunAsync();

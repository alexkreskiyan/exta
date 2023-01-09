using System.Threading.Tasks;
using Annium.AspNetCore.IntegrationTesting;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Server.Host;
using Xunit;

namespace Server.IntegrationTests;

public abstract class IntegrationTestBase : IntegrationTest, IAsyncLifetime
{
    protected IWebApplicationFactory AppFactory => GetAppFactory<Program>(
        builder => builder.UseServicePack<TestServicePack>()
    );

    private readonly TestcontainerDatabase _postgres = new TestcontainersBuilder<PostgreSqlTestcontainer>()
        .WithDatabase(new PostgreSqlTestcontainerConfiguration("registry.annium.com/postgres:15")
        {
            Database = "db",
            Username = "postgres",
            Password = "postgres",
        })
        .Build();

    public async Task InitializeAsync()
    {
        await _postgres.StartAsync();
    }

    public new async Task DisposeAsync()
    {
        await base.DisposeAsync();
        await _postgres.DisposeAsync();
    }
}

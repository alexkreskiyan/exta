using Annium.AspNetCore.IntegrationTesting;
using Server.Host;

namespace Server.IntegrationTests;

public abstract class IntegrationTestBase : IntegrationTest
{
    protected IWebApplicationFactory AppFactory => GetAppFactory<Program>(
        builder => builder.UseServicePack<TestServicePack>()
    );
}

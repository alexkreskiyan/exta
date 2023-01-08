using System.Net;
using System.Threading.Tasks;
using Annium.Net.Http;
using Annium.Testing;
using Xunit;

namespace Server.IntegrationTests;

public class IndexControllerTest : IntegrationTestBase
{
    private IHttpRequest Http => AppFactory.GetHttpRequest();

    [Fact]
    public async Task True_IsTrue()
    {
        // act
        var response = await Http.Get("/").RunAsync();

        // assert
        response.StatusCode.Is(HttpStatusCode.OK);
    }
}

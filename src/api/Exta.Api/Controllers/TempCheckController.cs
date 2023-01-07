using System.Threading.Tasks;
using Annium.AspNetCore.Extensions;
using Annium.Core.Mediator;
using Exta.Api.ViewModels.Requests.Checks;
using Exta.Api.ViewModels.Responses.Checks;
using Microsoft.AspNetCore.Mvc;

namespace Exta.Api.Controllers;

[Route("/temp-check")]
public class TempCheckController : ServerController
{
    public TempCheckController(
        IMediator mediator
    ) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<FileResult> Get([FromQuery] CreateTempCheckRequest request)
    {
        var response = await HandleAsync<CreateTempCheckRequest, TempCheckResponse>(request);
        var result = File(response.Data.Data, response.Data.ContentType);

        return result;
    }
}

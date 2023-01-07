using System;
using System.Threading.Tasks;
using Annium.AspNetCore.Extensions;
using Annium.Core.Mediator;
using Microsoft.AspNetCore.Mvc;
using Server.ViewModels.Requests.Checks;
using Server.ViewModels.Responses.Checks;

namespace Server.Host.Controllers;

[Route("/temp-check")]
public class TempCheckController : ServerController
{
    public TempCheckController(
        IMediator mediator,
        IServiceProvider sp
    ) : base(mediator, sp)
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

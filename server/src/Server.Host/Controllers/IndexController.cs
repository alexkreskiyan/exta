using System;
using System.Threading.Tasks;
using Annium.AspNetCore.Extensions;
using Annium.Core.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Server.Host.Controllers;

[Route("/")]
public class IndexController : ServerController
{
    public IndexController(
        IMediator mediator,
        IServiceProvider sp
    ) : base(mediator, sp)
    {
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // var response = await HandleAsync<CreateTempCheckRequest, TempCheckResponse>(request);
        // var result = File(response.Data.Data, response.Data.ContentType);

        return Ok();
    }
}

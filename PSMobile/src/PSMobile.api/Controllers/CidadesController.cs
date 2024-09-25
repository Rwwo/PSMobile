using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSMobile.core.Interfaces;
using PSMobile.application.Queries.Cidades;
using System.Net;

namespace PSMobile.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CidadesController : MainController
{
    private readonly IMediator _mediator;

    public CidadesController(IMediator mediator, INotificador notificador)
        : base(notificador)
    {
        _mediator = mediator;
    }

    // Rota para buscar todas as cidades
    [HttpGet("all")]
    public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10000)
    {
        var query = new GetAllCidadesQuery(pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }
}

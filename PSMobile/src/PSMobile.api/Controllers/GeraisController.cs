using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSMobile.core.Interfaces;
using System.Net;
using PSMobile.application.Queries.Gerais;

namespace PSMobile.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GeraisController : MainController
{
    private readonly IMediator _mediator;

    public GeraisController(IMediator mediator, INotificador notificador)
        : base(notificador)
    {
        _mediator = mediator;
    }

    // Rota para buscar todas as cidades
    [HttpGet("all")]
    public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1)
    {
        var query = new GetAllGeraisQuery(pageNumber, pageNumber);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }
}
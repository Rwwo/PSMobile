using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.application.Queries.Cidades;
using System.Net;

namespace PSMobile.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CidadesController : MainController
{
    private readonly IMediator _mediator;

    public CidadesController(IMediator mediator, INotify notificador)
        : base(notificador)
    {
        _mediator = mediator;
    }

    // Rota para buscar todas as cidades
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllCidadesQuery();
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }
}

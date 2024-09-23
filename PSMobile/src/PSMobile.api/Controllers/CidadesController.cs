using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.application.Queries.Cidades;
using System.Net;
using PSMobile.application.Queries.Funcionarios;

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
    public async Task<IActionResult> GetAll([FromQuery] GetAllCidadesQuery query)
    {
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }
}

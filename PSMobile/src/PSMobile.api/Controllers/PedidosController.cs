using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSMobile.core.Interfaces;
using System.Net;
using PSMobile.application.Queries.Pedidos;
using PSMobile.application.Queries.Cadastros;

namespace PSMobile.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : MainController
{
    private readonly IMediator _mediator;

    public PedidosController(IMediator mediator, INotificador notificador)
        : base(notificador)
    {
        _mediator = mediator;
    }

    // Rota para buscar todas as cidades
    [HttpGet("all/{empKey}")]
    public async Task<IActionResult> GetAll(int empKey, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllPedidosQuery(empKey, pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    [HttpGet("all/{empKey}/custom/{custom}")]
    public async Task<IActionResult> GetByCustomColumn(int empKey, string custom, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllCustomColumnPedidosQuery(empKey, custom, pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }
}

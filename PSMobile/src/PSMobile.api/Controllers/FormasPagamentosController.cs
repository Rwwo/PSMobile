using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSMobile.core.Interfaces;
using System.Net;
using PSMobile.application.Queries.FormasPagamentos;

namespace PSMobile.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FormasPagamentosController : MainController
{
    private readonly IMediator _mediator;

    public FormasPagamentosController(IMediator mediator, INotificador notificador)
        : base(notificador)
    {
        _mediator = mediator;
    }

    // Rota para buscar todas as cidades
    [HttpGet("all")]
    public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100)
    {
        var query = new GetAllFormasPagamentosQuery(pageSize, pageNumber);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    [HttpGet("{forPagCodigo:int}")]
    public async Task<IActionResult> GetById(int forPagCodigo, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetFormasPagamentosByCodigoQuery(forPagCodigo, pageSize, pageNumber);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }
}

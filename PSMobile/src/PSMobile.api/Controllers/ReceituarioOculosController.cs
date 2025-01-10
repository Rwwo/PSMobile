using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSMobile.core.Interfaces;
using System.Net;
using PSMobile.application.Queries.ReceituarioOtico;
using PSMobile.core.InputModel;
using PSMobile.application.Commands.ReceituarioOculos;

namespace PSMobile.api.Controllers;

[ApiController]
[Route("api/v1/receituario-oculos")]
public class ReceituarioOculosController : MainController
{
    private readonly IMediator _mediator;

    public ReceituarioOculosController(IMediator mediator, INotificador notificador)
        : base(notificador)
    {
        _mediator = mediator;
    }

    // Rota para buscar todas as cidades
    [HttpGet("all/{EmpKey}")]
    public async Task<IActionResult> GetAll(int EmpKey, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllReceituariosOticosQuery(EmpKey, pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    [HttpGet("os/{numos}")]
    public async Task<IActionResult> Get(int numos, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetReceituarioOculosByNumOSQuery(numos, pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    [HttpPost("gravar")]
    public async Task<IActionResult> PostGravar([FromBody] ReceituarioOculosInputModel entity)
    {
        if (!ModelState.IsValid)
        {
            var messages = ModelState
                .SelectMany(ms => ms.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(messages);
        }

        var command = new ReceituarioOculosCommand(entity);
        var result = await _mediator.Send(command);
        return CustomResponse(HttpStatusCode.OK, result);
    }
}
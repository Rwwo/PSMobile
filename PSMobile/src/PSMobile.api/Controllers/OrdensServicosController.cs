using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSMobile.core.Interfaces;
using System.Net;
using PSMobile.core.InputModel;
using PSMobile.application.Queries.OrdensServico;
using PSMobile.application.Commands.OrdensServicos;

namespace PSMobile.api.Controllers;

[ApiController]
[Route("api/v1/ordens-servicos")]
public class OrdensServicosController : MainController
{
    private readonly IMediator _mediator;

    public OrdensServicosController(IMediator mediator, INotificador notificador)
        : base(notificador)
    {
        _mediator = mediator;
    }

    // Rota para buscar todas as cidades
    [HttpGet("all/{empKey}")]
    public async Task<IActionResult> GetAll(int empKey, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllOrdensServicosQuery(empKey, pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    [HttpGet("all/{empKey}/ordserkey/{ordSerKey}")]
    public async Task<IActionResult> GetByOrdSerKey(int empKey, int ordSerKey, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllByKeyOrdensServicosQuery(empKey, ordSerKey, pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    [HttpGet("all/{empKey}/custom/{custom}")]
    public async Task<IActionResult> GetByCustomColumn(int empKey, string custom, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllCustomColumnOrdensServicosQuery(empKey, custom, pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    [HttpGet("all/{empKey}/{ordSerNum}/items")]
    public async Task<IActionResult> GetByOrdSerNumColumn(int empKey, int ordSerNum, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllByKeyOrdensServicosQuery(empKey, ordSerNum, pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    [HttpPost("gravar-os")]
    public async Task<IActionResult> PostGravar([FromBody] OrdensServicosInputModel entity)
    {
        if (!ModelState.IsValid)
        {
            var messages = ModelState
                .SelectMany(ms => ms.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(messages);
        }

        var command = new GravarOrdemServicoCommand(entity);
        var result = await _mediator.Send(command);
        return CustomResponse(HttpStatusCode.OK, result);
    }



    [HttpDelete("deletar-item-os/{ordSerIteKey:int}")]
    public async Task<IActionResult> DeleteItemOS(int ordSerIteKey)
    {

        var command = new DeletarOrdemServicoItemCommand(ordSerIteKey);
        var result = await _mediator.Send(command);
        return CustomResponse(HttpStatusCode.OK, result);
    }




    [HttpPost("gravar-item-os")]
    public async Task<IActionResult> Post([FromBody] OrdensServicosItensInputModel entity)
    {
        if (!ModelState.IsValid)
        {
            var messages = ModelState
                .SelectMany(ms => ms.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(messages);
        }

        var command = new GravarOrdensServicosItemCommand(entity);
        var result = await _mediator.Send(command);
        return CustomResponse(HttpStatusCode.OK, result);
    }
}
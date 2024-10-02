using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSMobile.core.Interfaces;
using System.Net;
using PSMobile.application.Queries.Pedidos;
using PSMobile.application.Commands.Pedidos;
using PSMobile.core.InputModel;

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

    [HttpGet("all/{empKey}/pedkey/{pedKey}")]
    public async Task<IActionResult> GetByPedKey(int empKey, int pedKey, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllByKeyPedidosQuery(empKey, pedKey, pageNumber, pageSize);
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

    [HttpGet("all/{empKey}/{pedNum}/items")]
    public async Task<IActionResult> GetByPedNumColumn(int empKey, int pedNum, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllByPedNumPedidosQuery(empKey, pedNum, pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    [HttpPost("gravar-pedido")]
    public async Task<IActionResult> PostGravar([FromBody] PedidoInputModel entity)
    {
        if (!ModelState.IsValid)
        {
            var messages = ModelState
                .SelectMany(ms => ms.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(messages);
        }

        var command = new GravarPedidoCommand(entity);
        var result = await _mediator.Send(command);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    [HttpPost("atualizar-pedido")]
    public async Task<IActionResult> Post([FromBody] PedidoAtualizarInputModel entity)
    {
        if (!ModelState.IsValid)
        {
            var messages = ModelState
                .SelectMany(ms => ms.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(messages);
        }

        var command = new AtualizarPedidoCommand(entity);
        var result = await _mediator.Send(command);
        return CustomResponse(HttpStatusCode.OK, result);
    }


    [HttpPost("gravar-pedido-item")]
    public async Task<IActionResult> Post([FromBody] PedidoItemInputModel entity)
    {
        if (!ModelState.IsValid)
        {
            var messages = ModelState
                .SelectMany(ms => ms.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(messages);
        }

        var command = new GravarPedidoItemCommand(entity);
        var result = await _mediator.Send(command);
        return CustomResponse(HttpStatusCode.OK, result);
    }
}

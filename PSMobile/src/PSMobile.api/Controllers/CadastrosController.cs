using System.Net;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using PSMobile.application.Commands.Cadastros;
using PSMobile.application.Queries.Cadastros;
using PSMobile.core.Entities;
using PSMobile.core.Interfaces;

namespace PSMobile.api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CadastrosController : MainController
{
    private readonly IMediator _mediator;
    public CadastrosController(IMediator mediator, INotify notificador)
        : base(notificador)
    {
        _mediator = mediator;
    }


    [HttpGet]
    public async Task<ActionResult<List<Cadastros>>> GetAll()
    {

        var query = new GetAllCadastrosQuery();
        var result = await _mediator.Send(query);

        return CustomResponse(HttpStatusCode.OK, result);
    }

    [HttpGet("{custom}")]
    public async Task<ActionResult<List<Cadastros>>> GetByCustomColumn(string custom)
    {
        var query = new GetAllCustomColumnCadastrosQuery(custom);
        var result = await _mediator.Send(query);

        return CustomResponse(HttpStatusCode.OK, result);
    }


    [HttpPost()]
    public async Task<ActionResult<List<Cadastros>>> Post([FromBody] Cadastros entity)
    {
        if (!ModelState.IsValid)
        {
            var messages = ModelState
                .SelectMany(ms => ms.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(messages);
        }

        var command = new CreateCadastroCommand(entity);
        var result = await _mediator.Send(command);

        return CustomResponse(HttpStatusCode.OK, result);
    }


    [HttpPut("{cad_key:int}")]
    public async Task<ActionResult<Cadastros>> Put(int cad_key, [FromBody] Cadastros entity)
    {
        if (cad_key != entity.cad_key)
            return BadRequest();

        if (!ModelState.IsValid)
        {
            var messages = ModelState
                .SelectMany(ms => ms.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(messages);
        }

        var command = new UpdateCadastroCommand(cad_key, entity);
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("{cad_key:int}")]
    public async Task<ActionResult<Cadastros>> Delete(int cad_key)
    {

        if (!ModelState.IsValid)
        {
            var messages = ModelState
                .SelectMany(ms => ms.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(messages);
        }

        var atendimentosDTOR = await _mediator.Send(new DeleteCadastroCommand(cad_key));

        return Ok(atendimentosDTOR);
    }
}


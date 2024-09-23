using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.application.Queries.Funcionarios;
using System.Net;

namespace PSMobile.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FuncionariosController : MainController
{
    private readonly IMediator _mediator;

    public FuncionariosController(IMediator mediator, INotify notificador)
        : base(notificador)
    {
        _mediator = mediator;
    }

    // Rota para buscar todos os funcionários
    [HttpGet("all")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllFuncionariosQuery query)
    {
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    // Rota para buscar funcionários por nome
    [HttpGet("search-by-name")]
    public async Task<IActionResult> GetFuncionariosByName([FromQuery] GetFuncionariosByNomeQuery query)
    {
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    // Rota para buscar funcionário por ID
    [HttpGet("{funKey:int}")]
    public async Task<IActionResult> GetFuncionariosById(int funKey)
    {
        var query = new GetFuncionarioByKeyQuery(funKey);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }
}

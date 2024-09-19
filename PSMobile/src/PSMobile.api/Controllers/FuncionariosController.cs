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
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllFuncionariosQuery();
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    // Rota para buscar funcionários por nome
    [HttpGet("search-by-name")]
    public async Task<IActionResult> GetFuncionariosByName([FromQuery] string name)
    {
        var query = new GetFuncionariosByNomeQuery(name);
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

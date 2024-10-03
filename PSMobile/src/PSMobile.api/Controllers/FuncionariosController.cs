using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSMobile.core.Interfaces;
using PSMobile.application.Queries.Funcionarios;
using System.Net;

namespace PSMobile.api.Controllers;

[ApiController]
[Route("api/v1/funcionarios")]
public class FuncionariosController : MainController
{
    private readonly IMediator _mediator;

    public FuncionariosController(IMediator mediator, INotificador notificador)
        : base(notificador)
    {
        _mediator = mediator;
    }

    // Rota para buscar todos os funcionários
    [HttpGet("all")]
    public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50)
    {
        var query = new GetAllFuncionariosQuery(pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    // Rota para buscar funcionários por nome
    [HttpGet("search-by-name/{partialName}")]
    public async Task<IActionResult> GetFuncionariosByName(string partialName, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetFuncionariosByNomeQuery(partialName, pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    // Rota para buscar funcionário por ID
    [HttpGet("{funKey}")]
    public async Task<IActionResult> GetFuncionariosById(int funKey, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetFuncionarioByKeyQuery(funKey, pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSMobile.core.Interfaces;
using System.Net;
using PSMobile.application.Queries.Prescritor;
using PSMobile.application.Queries.Funcionarios;

namespace PSMobile.api.Controllers;

[ApiController]
[Route("api/v1/prescritores")]
public class PrescritoresController : MainController
{
    private readonly IMediator _mediator;

    public PrescritoresController(IMediator mediator, INotificador notificador)
        : base(notificador)
    {
        _mediator = mediator;
    }

    // Rota para buscar todos os prescritores
    [HttpGet("all")]
    public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllPrescritoresQuery(pageSize, pageNumber);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    // Rota para buscar prescritores por nome
    [HttpGet("nome/{nome}")]
    public async Task<IActionResult> GetByCustomColumn(string nome, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllPrescritoresForNameQuery(nome, pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    [HttpGet("{preKey}")]
    public async Task<IActionResult> GetPrescritorById(int preKey, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetPrescritorByKeyQuery(preKey, pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }
}

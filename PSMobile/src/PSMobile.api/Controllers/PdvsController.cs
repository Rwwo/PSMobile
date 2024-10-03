using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSMobile.core.Interfaces;
using System.Net;
using PSMobile.application.Queries.Pdvs;

namespace PSMobile.api.Controllers;

[ApiController]
[Route("api/v1/pdvs")]
public class PdvsController : MainController
{
    private readonly IMediator _mediator;

    public PdvsController(IMediator mediator, INotificador notificador)
        : base(notificador)
    {
        _mediator = mediator;
    }

    // Rota para buscar todas as cidades
    [HttpGet("all/{EmpKey}")]
    public async Task<IActionResult> GetAll(int EmpKey, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllPdvsByEmpKeyQuery(EmpKey,  pageSize, pageNumber);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }
}
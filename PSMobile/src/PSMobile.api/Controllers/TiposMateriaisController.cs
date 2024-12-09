using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSMobile.core.Interfaces;
using System.Net;
using PSMobile.application.Queries.TiposMateriais;
using PSMobile.application.Queries.Funcionarios;

namespace PSMobile.api.Controllers;

[ApiController]
[Route("api/v1/tipos-materiais")]
public class TiposMateriaisController : MainController
{
    private readonly IMediator _mediator;

    public TiposMateriaisController(IMediator mediator, INotificador notificador)
        : base(notificador)
    {
        _mediator = mediator;
    }

    // Rota para buscar todos os prescritores
    [HttpGet("all")]
    public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllTiposMateriais(pageSize, pageNumber);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    [HttpGet("{tipmatKey}")]
    public async Task<IActionResult> GetTipoMaterialById(int tipmatKey, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetTipoMaterialByKeyQuery(tipmatKey, pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }


}
using MediatR;

using System.Net;
using Microsoft.AspNetCore.Mvc;

using PSMobile.core.Entities;

using PSMobile.core.Interfaces;
using PSMobile.application.Queries.Cidades;

namespace PSMobile.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CidadesController : MainController
{
    private readonly IMediator _mediator;
    public CidadesController(IMediator mediator, INotify notificador)
        : base(notificador)
    {
        _mediator = mediator;
    }


    [HttpGet()]
    public async Task<ActionResult<List<Cidades>>> GetAll()
    {
        var query = new GetAllCidadesQuery();
        var result = await _mediator.Send(query);

        return CustomResponse(HttpStatusCode.OK, result);
    }
}

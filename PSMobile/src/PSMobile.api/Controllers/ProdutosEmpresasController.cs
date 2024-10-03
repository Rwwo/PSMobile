using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSMobile.core.Interfaces;
using System.Net;
using PSMobile.application.Queries.ProdutosEmpresas;

namespace PSMobile.api.Controllers;

[ApiController]
[Route("api/v1/produtosempresas")]
public class ProdutosEmpresasController : MainController
{
    private readonly IMediator _mediator;

    public ProdutosEmpresasController(IMediator mediator, INotificador notificador)
        : base(notificador)
    {
        _mediator = mediator;
    }

    // Rota para buscar todas as cidades
    [HttpGet("all/{empKey}")]
    public async Task<IActionResult> GetAll(int empKey, int pageNumber = 1, int pageSize = 10)
    {
        var query = new GetProdutosEmpresasByEmpKeyQuery(empKey, pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    [HttpGet("all/{empKey}/custom/{custom}")]
    public async Task<IActionResult> GetAll(int empKey, string custom, int pageNumber = 1, int pageSize = 10)
    {
        var query = new GetProdutosEmpresasByEmpKeyAndCustomQuery(empKey, custom, pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }
}

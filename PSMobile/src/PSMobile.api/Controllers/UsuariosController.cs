using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSMobile.core.Interfaces;
using System.Net;
using PSMobile.application.Queries.Usuarios;
using PSMobile.application.Commands.Usuarios;
using Microsoft.AspNetCore.Authorization;

namespace PSMobile.api.Controllers;

[ApiController]
[Route("api/v1/usuarios")]
public class UsuariosController : MainController
{
    private readonly IMediator _mediator;

    public UsuariosController(IMediator mediator, INotificador notificador)
        : base(notificador)
    {
        _mediator = mediator;
    }

    // Rota para buscar todas as cidades
    [HttpGet("all")]
    public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10000)
    {
        var query = new GetAllUsuariosQuery(pageNumber, pageSize);
        var result = await _mediator.Send(query);
        return CustomResponse(HttpStatusCode.OK, result);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("login")]
    public async Task<ActionResult> Login(LoginUsuarioCommand usuario)
    {
        var result = await _mediator.Send(usuario);

        return CustomResponse(HttpStatusCode.OK, result);
    }
}

